using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    public class OrderController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {
            return View();
        }
        #region APICALLS
        [HttpGet]
        public IActionResult GetAll() {
            List<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeaderRepository.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = objOrderHeaders });
        }
      
        #endregion
    }
}
