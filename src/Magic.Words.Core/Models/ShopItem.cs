using Magic.Words.Core.Classes;
using Magic.Words.Core.Interfaces;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class ShopItem  
       // : CartItem
        {


        public int ShopItemId { get; set; }
        //    [Required]
        public string Name { get; set; }
        public double ShopItemDiscount { get; set; }
        public decimal Price { get; set; }

        public int ShopItemCount {  get; set; }
        public  string ItemDescription { get; set; }
        public string ShopItemTitle { get; set;}

    }
}
