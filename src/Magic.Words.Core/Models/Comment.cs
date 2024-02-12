using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class Comment {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Boolean isActive { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }

     //   public string ApplicationUserName { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public int? TopicId { get; set; }

        [ForeignKey("TopicId")]
      
        public  Topic? Topic { get; set; }
    }
}
