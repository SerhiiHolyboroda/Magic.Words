using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class SubscriptionController : Controller {

        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {
            List<Subscription> objSubscriptionList = _unitOfWork.SubscriptionRepository.GetAll().ToList();
            return View(objSubscriptionList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subscription subscription) {
            // if (Subscription.SubscriptionId == subscription.SubscriptionName)
            //   {
            //      ModelState.AddModelError("name", "DisplayOrder cannot exactly match Name");
            //   }
            if (ModelState.IsValid)
            {
                _unitOfWork.SubscriptionRepository.Add(subscription);
                _unitOfWork.Save();
                TempData["success"] = "Subscription created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id) {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Subscription? subscriptionFromDb = _unitOfWork.SubscriptionRepository.Get(u => u.SubscriptionId == id);
            if (subscriptionFromDb == null)
            {
                return NotFound();
            }
            return View(subscriptionFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Subscription subscription) {

            if (ModelState.IsValid)
            {
                // _unitOfWork.SubscriptionRepository.Update(subscription);
                _unitOfWork.Save();
                TempData["success"] = "Subscription updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id) {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Subscription? subscriptionFromDb = _unitOfWork.SubscriptionRepository.Get(u => u.SubscriptionId == id);
            if (subscriptionFromDb == null)
            {
                return NotFound();
            }
            return View(subscriptionFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) {
            Subscription? obj = _unitOfWork.SubscriptionRepository.Get(u => u.SubscriptionId == id);
            if (id == null)
            {
                return NotFound();
            }
            _unitOfWork.SubscriptionRepository.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Subscription deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
