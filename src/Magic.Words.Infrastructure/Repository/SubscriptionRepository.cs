using Magic.Words.Core.IRepository;
using Magic.Words.Core.Models;
using Magic.Words.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Repository {
    internal class SubscriptionRepository : Repository<Subscription> , ISubscriptionRepository {
        private ApplicationDbContext _db;
        public SubscriptionRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        

       // public void Save() {
     //       _db.SaveChanges();
    //   }

        public void Update(Subscription entity) {
            throw new NotImplementedException();
        }
    }
}
