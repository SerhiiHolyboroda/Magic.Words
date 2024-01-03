using Magic.Words.Core.Data;
using Magic.Words.Core.IRepository;
using Magic.Words.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Repository {
    internal class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository {

        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        
    }
}