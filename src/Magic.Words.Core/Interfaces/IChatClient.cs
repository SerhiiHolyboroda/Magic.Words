using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Interfaces {
    public interface IChatClient {
        Task ReceiveMessage(string message);
    }
}
