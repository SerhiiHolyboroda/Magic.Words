using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.ViewModels;
using Magic.Words.Shared.Hubs;
using Magic.Words.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Stripe.Checkout;
using System.Security.Claims;

namespace Magic.Words.Web.Controllers {
    public class ShoppingCartItemController : Controller {
        //   [Area("customer")]
        //    [Authorize]
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ILogger<ShoppingCartItemController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public ShoppingCartItemController(ILogger<ShoppingCartItemController> logger, IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext) {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }

        public IActionResult Index() {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == userId, includeProperties: "ShopItem"),
                OrderHeader = new()
            };
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                double price = GetPriceBasedOnSomething(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (price * cart.Count);

            }
            return View(ShoppingCartVM);


        }
        public IActionResult Summary() {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == userId, includeProperties: "ShopItem"),
                OrderHeader = new()
            };
            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userId);
            ShoppingCartVM.OrderHeader.Email = ShoppingCartVM.OrderHeader.ApplicationUser.Email;

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                double price = GetPriceBasedOnSomething(cart);
                //change to :   ShoppingCartVM.Orderheader.OrderTotal += (price * cart.Count);
                ShoppingCartVM.OrderHeader.OrderTotal += (price * cart.Count);
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST() {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;


            //   ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == userId,
            //       includeProperties: "Subscription");
            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == userId, includeProperties: "ShopItem"),
                OrderHeader = new()
            };


            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;
            ApplicationUser applicationUser = ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == userId);
            ShoppingCartVM.OrderHeader.Email = ShoppingCartVM.OrderHeader.ApplicationUser.Email;

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                double price = GetPriceBasedOnSomething(cart);
                //change to :   ShoppingCartVM.Orderheader.OrderTotal += (price * cart.Count);
                ShoppingCartVM.OrderHeader.OrderTotal += (price * cart.Count);
            }


            //  if(applicationUser.CompanyId.GetValueOrDefault() == 0){
            // regular customer account we need payment
            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
            //   }else{
            // it's company user
            //   ShoppingCartVM.OrderHeader.PaymentsStatus = SD.PaymentStatusDelayedPayment;
            //    ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;
            //   }

            _unitOfWork.OrderHeaderRepository.Add(ShoppingCartVM.OrderHeader);
            _unitOfWork.Save();
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    ShopItemId = (int)cart.ShopItemId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    //  Price = cart.Price,
                    Price = ShoppingCartVM.OrderHeader.OrderTotal,

                    Count = cart.Count
                };
                _unitOfWork.OrderDetailRepository.Add(orderDetail);
                _unitOfWork.Save();
            }

            //    if(applicationUser.CompanyId.GetValueOrDefault() == 0){
            // regular customer account we need payment

            //    }
            var domain = "https://localhost:7054/";
            var options = new SessionCreateOptions
            {
                //   SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                SuccessUrl = domain + $"ShoppingCart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                CancelUrl = domain + "customer/cart/index",
                LineItems = new List<SessionLineItemOptions>(),


                Mode = "payment",

            };
            foreach (var item in ShoppingCartVM.ShoppingCartList)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {

                        // UnitAmount = (long)(item.Price * 100)
                        UnitAmount = (long)(ShoppingCartVM.OrderHeader.OrderTotal * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ShopItem.Name
                        }
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(sessionLineItem);


                var service = new SessionService();
                Session session = service.Create(options);
                _unitOfWork.OrderHeaderRepository.UpdateStripePaymentId(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.Save();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }
            //  return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
            return RedirectToAction(nameof(OrderConfirmation), new { id = ShoppingCartVM.OrderHeader.Id });
        }

        public IActionResult OrderConfirmation(int id) {


            OrderHeader orderHeader = _unitOfWork.OrderHeaderRepository.Get(u => u.Id == id, includeProperties: "ApplicationUser");
            if (orderHeader.PaymentStatus != SD.PaymentApprovedForDelayedPayment)
            {
                var service = new SessionService();
                Session session = service.Get(orderHeader.SessionId);
                if (session.PaymentStatus.ToLower() == "paid")
                {
                    _unitOfWork.OrderHeaderRepository.UpdateStripePaymentId(id, session.Id, session.PaymentIntentId);
                    _unitOfWork.OrderHeaderRepository.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                    _unitOfWork.Save();
                }

                List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCartRepository
                    .GetAll(u => u.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
                _unitOfWork.ShoppingCartRepository.RemoveRange(shoppingCarts);
                _unitOfWork.Save();
            }

            return View(id);
        }


        public async Task<IActionResult> Plus(int cartId) {

            var userId = "UserIdHere"; // Replace with the actual user ID
            await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", "Button pressed!");

            var cartFromDb = _unitOfWork.ShoppingCartRepository.Get(u => u.Id == cartId);
            cartFromDb.Count += 1;
            _unitOfWork.ShoppingCartRepository.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int cartId) {
            var cartFromDb = _unitOfWork.ShoppingCartRepository.Get(u => u.Id == cartId);
            if (cartFromDb.Count <= 1)
            {
                _unitOfWork.ShoppingCartRepository.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShoppingCartRepository.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId) {
            var cartFromDb = _unitOfWork.ShoppingCartRepository.Get(u => u.Id == cartId);
            _unitOfWork.ShoppingCartRepository.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private double GetPriceBasedOnSomething(ShoppingCart shoppingCart) {
            if (shoppingCart.Count < 50)
            {
              
               if (shoppingCart.ShopItemId != null)
                {
                    return (double)5.0m;
                }

                //change price

            }
            else
            {
                if (shoppingCart.Count <= 100)
                {
                    return (double)shoppingCart.ShopItem.Price;
                    //change price
                }
            }
            return (double)shoppingCart.ShopItem.Price;
        }


        [HttpPost]
        //   [Authorize]
        public IActionResult AddToCart(ShoppingCart shoppingCart, int shopItemId) {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            
           
         if (shopItemId != null)
            {
                shoppingCart.ShopItemId = shopItemId;
            }

            _unitOfWork.ShoppingCartRepository.Add(shoppingCart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}