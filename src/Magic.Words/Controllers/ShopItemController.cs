using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {

   // [Area("Admin")]
    //  [Authorize(Roles = SD.Role_Admin)]
    public class ShopItemController : Controller {

        private readonly IUnitOfWork _unitOfWork;
        public ShopItemController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {
            List<ShopItem> objSubscriptionList = _unitOfWork.ShopItemRepository.GetAll().ToList();
            return View(objSubscriptionList);
        }

        public IActionResult Details(int shopItemId) {
             
            {

                ShopItem shopItem = _unitOfWork.ShopItemRepository.Get(
                    u => u.ShopItemId == shopItemId
                ); 

                ShoppingCart cart = new ShoppingCart
                {
                    ShopItem = shopItem,
                    Count = 1,
                    ShopItemId = shopItemId
                };

                return View(cart);
            }
        }
    }
}
