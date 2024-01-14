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
    internal class OrderDetailRepository : Repository<OrderDetail> , IOrderDetailRepository {
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        

       

        public void Update(OrderDetail entity) {
           _db.OrderDetails.Update(entity);
        }
    }
}
