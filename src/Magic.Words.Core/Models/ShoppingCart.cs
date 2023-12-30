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
   //   [ForeignKey("ProductId")]
  //   [ValidateNever]
        public int ProductId { get; set; }
        public int Count { get; set; } = 1;
    //   [ForeignKey("ApplicationUserId")]
      //  [ValidateNever]
        public string ApplicationUserId { get; set; }
    }
}
