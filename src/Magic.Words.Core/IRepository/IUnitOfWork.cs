﻿using Magic.Words.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Repositories {
    public interface IUnitOfWork {
        ISubscriptionRepository SubscriptionRepository { get; }
        IShoppingCartRepository ShoppingCartRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }

         IOrderHeaderRepository OrderHeaderRepository { get; }

         IOrderDetailRepository OrderDetailRepository { get;}

        IShopItemRepository ShopItemRepository { get; }

        ITopicRepository TopicRepository { get; }

        ICommentRepository CommentRepository { get; }
        void Save();
    }
}
