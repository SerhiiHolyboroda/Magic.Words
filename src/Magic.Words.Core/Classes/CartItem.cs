using Magic.Words.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Classes {
    [NotMapped]
    public class CartItem : ICartItem {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }
    }
}
