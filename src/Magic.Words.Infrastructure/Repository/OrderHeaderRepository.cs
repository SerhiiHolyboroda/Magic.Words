﻿using Magic.Words.Core.IRepository;
using Magic.Words.Core.Models;
using Magic.Words.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Repository {
    internal class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }



        public void Update(OrderHeader entity) {
            _db.OrderHeaders.Update(entity);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null) {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if(orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (string.IsNullOrEmpty(orderStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId) {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }
        }
    }
}
