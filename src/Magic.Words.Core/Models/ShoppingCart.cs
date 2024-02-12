
using Magic.Words.Core.Classes;
using Magic.Words.Core.Interfaces;
 
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Magic.Words.Core.Models {
    public class ShoppingCart {
        public int Id { get; set; }
       
        public int? SubscriptionId { get; set; }
        [ForeignKey("SubscriptionId")]
        [ValidateNever]
      

        public Subscription? Subscription { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; } = 1;
        public int? ShopItemId { get; set; }
        [ForeignKey("ShopItemId")]
        [ValidateNever]
        public ShopItem? ShopItem { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}