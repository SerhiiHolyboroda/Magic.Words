using Magic.Words.Core.Data;
using Magic.Words.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.IRepository;

namespace Magic.Words.Core.Repository 
    {
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository {

        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(ShoppingCart shoppingCart) {
           _db.ShoppingCarts.Update(shoppingCart);
        }
    }
}