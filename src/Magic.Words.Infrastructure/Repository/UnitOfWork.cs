using Magic.Words.Core.IRepository;
using Magic.Words.Core.Repositories;
using Magic.Words.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Magic.Words.Core.Repository;

namespace Magic.Words.Core.Repository {
    public class UnitOfWork : IUnitOfWork {

        private ApplicationDbContext _db;

        public ISubscriptionRepository SubscriptionRepository { get; private set; }
        public IShoppingCartRepository ShoppingCartRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IOrderHeaderRepository OrderHeaderRepository { get; private set; }

        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
            SubscriptionRepository = new SubscriptionRepository(_db);
            ApplicationUserRepository = new ApplicationUserRepository(_db);
            ShoppingCartRepository = new ShoppingCartRepository(_db);
            OrderDetailRepository = new OrderDetailRepository(_db);
            OrderHeaderRepository = new OrderHeaderRepository(_db);
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}

/*

private readonly ApplicationDbContext _db;
private readonly IServiceProvider _serviceProvider;

private readonly Lazy<ISubscriptionRepository> _subscriptionRepository;
private readonly Lazy<IShoppingCartRepository> _shoppingCartRepository;
private readonly Lazy<IApplicationUserRepository> _applicationUserRepository;
private readonly Lazy<IOrderHeaderRepository> _orderHeaderRepository;
private readonly Lazy<IOrderDetailRepository> _orderDetailRepository;

public ISubscriptionRepository SubscriptionRepository => _subscriptionRepository.Value;
public IShoppingCartRepository ShoppingCartRepository => _shoppingCartRepository.Value;
public IApplicationUserRepository ApplicationUserRepository => _applicationUserRepository.Value;
public IOrderHeaderRepository OrderHeaderRepository => _orderHeaderRepository.Value;
public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository.Value;

public UnitOfWork(ApplicationDbContext db, IServiceProvider serviceProvider) {
    _db = db;
    _serviceProvider = serviceProvider;

    _subscriptionRepository = new Lazy<ISubscriptionRepository>(() => serviceProvider.GetService<ISubscriptionRepository>());
    _shoppingCartRepository = new Lazy<IShoppingCartRepository>(() => serviceProvider.GetService<IShoppingCartRepository>());
    _applicationUserRepository = new Lazy<IApplicationUserRepository>(() => serviceProvider.GetService<IApplicationUserRepository>());
    _orderDetailRepository = new Lazy<IOrderDetailRepository>(() => serviceProvider.GetService<IOrderDetailRepository>());
    _orderHeaderRepository = new Lazy<IOrderHeaderRepository>(() => serviceProvider.GetService<IOrderHeaderRepository>());
}

public void Save() {
    _db.SaveChanges();
}
    }
}
*/