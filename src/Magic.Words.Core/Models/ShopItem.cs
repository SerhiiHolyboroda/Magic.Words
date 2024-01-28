using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class ShopItem {


        public int ShopItemId { get; set; }
        //    [Required]
        public string ShopItemName { get; set; }
        public double ShopItemDiscount { get; set; }
        public double ShopItemPrice { get; set; }

        public int ShopItemCount {  get; set; }
        public string ShopItemDescription { get; set;}
        public string ShopItemTitle { get; set;}

    }
}
