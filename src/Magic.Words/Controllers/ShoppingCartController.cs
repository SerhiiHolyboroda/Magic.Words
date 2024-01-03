using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Magic.Words.Web.Controllers {
    public class ShoppingCartController : Controller {
        //   [Area("customer")]
        //    [Authorize]

        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public ShoppingCartController(ILogger<ShoppingCartController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index() {

            var claimsIdentioty = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentioty.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCartRepository.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Subscription")
            };  
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                double price = GetPriceBasedOnSomething(cart);
                ShoppingCartVM.OrderTotal += (price * cart.Count);
            }
            return View(ShoppingCartVM);
             
         
        }
        public IActionResult Summary() {
            return View();
        }

        public IActionResult Plus(int cartId) {
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
                return (double)shoppingCart.Subscription.SubscriptionPrice;
                //change price

            }
            else
            {
                if (shoppingCart.Count <= 100)
                {
                    return (double)shoppingCart.Subscription.SubscriptionPrice;
                    //change price
                }
            }
            return (double)shoppingCart.Subscription.SubscriptionPrice;
        }


        [HttpPost]
     //   [Authorize]
        public IActionResult AddToCart(ShoppingCart shoppingCart, int subscriptionId) {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;
            shoppingCart.SubscriptionId = subscriptionId;
            _unitOfWork.ShoppingCartRepository.Add(shoppingCart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}