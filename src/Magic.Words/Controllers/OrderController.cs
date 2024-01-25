using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.ViewModels;
using Magic.Words.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
   // [Area("admin")]
    public class OrderController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index() {


            List<OrderDetail> objOrderDetails = _unitOfWork.OrderDetailRepository.GetAll()
                // .GetAll(includeProperties: "OrderHeader.Subscription")
                 .ToList();
            List<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeaderRepository.GetAll()
              .ToList();


            // Assuming you have a method to map OrderHeader to OrderVM
            List<OrderVM> orderViewModels = MapToOrderVMList(objOrderDetails, objOrderHeaders);

            return View(orderViewModels);
        }
        #region APICALLS
    
        [HttpGet]
        public
            // IActionResult 
         void   GetAll(string status) {
            List<OrderDetail> objOrderDetails = _unitOfWork.OrderDetailRepository.GetAll()
                // .GetAll(includeProperties: "OrderHeader.Subscription")
                .ToList();
            List<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeaderRepository.GetAll()
              .ToList();

            // Assuming you have a method to map OrderHeader to OrderVM
            List<OrderVM> orderViewModels = MapToOrderVMList(objOrderDetails, objOrderHeaders);


            switch (status)
            {
                // case "pending":
                //  objOrderHeaders = objOrderHeaders.Where( u => u.OrderStatus == SD.PaymentStatuseDelayedPayment);
                //     break;
                case "inprocess":
                    objOrderHeaders = (List<OrderHeader>)objOrderHeaders.Where(u => u.OrderStatus == SD.StatusProcessing);
                    break;
                case "comleted":
                    objOrderHeaders = (List<OrderHeader>)objOrderHeaders.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "approved":
                    objOrderHeaders = (List<OrderHeader>)objOrderHeaders.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                default:
                    objOrderHeaders = (List<OrderHeader>)objOrderHeaders;
                    break;

            }
        }
       
        #endregion


        public IActionResult Details(int orderId) {
            OrderVM orderVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeaderRepository.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetailRepository.GetAll(u => u.OrderHeaderId == orderId, includeProperties: "Subscription")
            };
            return View(orderVM);
        }

        private List<OrderVM> MapToOrderVMList(List<OrderDetail> orderDetails, List<OrderHeader> orderHeaders ) {
            List<OrderVM> orderViewModels = new List<OrderVM>();

            foreach (var orderDetail in orderDetails)
            {
                foreach (var orderHeader in orderHeaders)
                {

                    var orderVM = new OrderVM
                    {
                        OrderDetail = new List<OrderDetail> { orderDetail },
                        OrderHeader = orderHeader
                    };

                    orderViewModels.Add(orderVM);
                }

            }

            return orderViewModels;
        }
    }
}