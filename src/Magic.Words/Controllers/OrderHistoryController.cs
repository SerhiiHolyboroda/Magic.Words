using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class OrderHistoryController : Controller {
        private readonly IUnitOfWork _unitOfWork;
        public OrderHistoryController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {
            List<OrderHeader> objOrderHeaderList = _unitOfWork.OrderHeaderRepository.GetAll().ToList();
            List<OrderDetail> objOrderDetailList = _unitOfWork.OrderDetailRepository.GetAll().ToList();
            return View(objSubscriptionList);
        }

    }
}