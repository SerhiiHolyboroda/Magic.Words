using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class OrderDetail {
        public int Id { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }
         
        public int? SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        [ValidateNever]
        public Subscription? Subscription { get; set; }

        public int? ShopItemId { get; set; }
        [ForeignKey("ShopItemId")]
        [ValidateNever]
        public ShopItem? ShopItem { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
      
    }
}
