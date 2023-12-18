using Magic.Words.Core.IRepository;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Repository {
    public class UnitOfWork : IUnitOfWork {

        private ApplicationDbContext _db;
       
        public ISubscriptionRepository SubscriptionRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
            SubscriptionRepository = new SubscriptionRepository(_db);
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}