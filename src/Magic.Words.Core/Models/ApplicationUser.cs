using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Models {
    public class ApplicationUser : IdentityUser {
        //   public string Name { get; set; }

        //   public string Username { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
