using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class ShopController : Controller {
        /*
    private readonly IUnitOfWork _unitOfWork;
    public ShopController(IUnitOfWork unitOfWork) {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index() {
        List<ShopItem> objShopItemList = _unitOfWork.ShopItemRepository.GetAll().ToList();
        return View(objShopItemList);
    }

    public IActionResult Details(int shopItemId) {
        ShoppingCart cart = new()
           {
               Subscription = _unitOfWork.SubscriptionRepository.Get(u => u.SubscriptionId == subscriptionId, includeProperties: "Subscription"),
               Count = 1,
               SubscriptionId = subscriptionId
           };

           return View(cart);  
        {
            // Use lambda expression for include
            Subscription subscription = _unitOfWork.ShopItemRepository.Get(
                u => u.ShopItemId == shopItemId
            );

            ShoppingCart cart = new ShoppingCart
            {
                Subscription = shopItem,
                Count = 1,
                SubscriptionId = shopItemId
            };

            return View(cart);

    }
}
}
           */
    }
}