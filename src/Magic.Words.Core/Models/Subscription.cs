using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class Subscription //: Product
        {
    //    [Key]


        public int SubscriptionId { get; set; }
    //    [Required]
        public string SubscriptionName { get; set; }
        public decimal SubscriptionPrice { get; set; }

       
    }
}
