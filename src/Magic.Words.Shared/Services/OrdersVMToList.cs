using Magic.Words.Core.Models;
using Magic.Words.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
 
 

namespace Magic.Words.Shared.Services {
    public class OrdersVMToList {
        public static List<OrderVM> MapToOrderVMList(List<OrderDetail> orderDetails, List<OrderHeader> orderHeaders) {
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
