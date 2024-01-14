using Magic.Words.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.ViewModels {
    public class ShoppingCartVM {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
         public OrderHeader OrderHeader  {  get; set; }
        // remove Order Total and change it to OrderHeader.OrderTotal in cartcontroller
       // public double OrderTotal {  get; set; }
    }
}
