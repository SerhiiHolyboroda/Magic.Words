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
    internal class ShopItemRepository : Repository<ShopItem> , IShopItemRepository {
        private ApplicationDbContext _db;
        public ShopItemRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        

       // public void Save() {
     //       _db.SaveChanges();
    //   }

        public void Update(ShopItem entity) {
            throw new NotImplementedException();
        }
    }
}
