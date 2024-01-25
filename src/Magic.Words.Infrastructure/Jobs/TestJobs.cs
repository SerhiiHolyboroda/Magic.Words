using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Infrastructure.Jobs {
    public class TestJobs {
        private readonly ILogger _logger;

        public TestJobs(ILogger<TestJobs> logger ) => _logger = logger;

        public void WriteLog(string logMessage) {
            _logger.LogInformation($"{DateTime.Now:yyyy-MM-dd hh:mm:ss tt} {logMessage}");
        }

    }
}
