using Magic.Words.Core.Classes;
using Magic.Words.Core.Interfaces;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class Subscription   {
    //    [Key]


        public int SubscriptionId { get; set; }
    //    [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string? ItemDescription { get; set; }
    }
}
