using Magic.Words.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Repositories {
    public interface IUnitOfWork {
        ISubscriptionRepository SubscriptionRepository { get; }
        void Save();
    }
}
