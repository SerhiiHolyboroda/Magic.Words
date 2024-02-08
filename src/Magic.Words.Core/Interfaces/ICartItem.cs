using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Interfaces {
    public interface ICartItem {
   //     int ItemId { get; set; }
       string Name { get; set; }
        decimal Price { get; set; }
     //   int ItemCount { get; set; }
       string ItemDescription { get; set; }
   //     string ItemTitle { get; set; }
    }
}
