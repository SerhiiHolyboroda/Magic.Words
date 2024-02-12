using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Core.Classes {
    [Route("api/[controller]")]
    [ApiController]
    public class JobScheduler : ControllerBase {
        private readonly IHttpClientFactory _httpClientFactory;

        public JobScheduler(IHttpClientFactory httpClientFactory) {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [Route("TestHourlyJob")]
        public async Task<ActionResult> TestHourlyJob() {

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("http://localhost:7054/api/Job/CreateHourlyJobToCheckTopics", null);
            if (response.IsSuccessStatusCode)
            {
                return Ok("Hourly job scheduled successfully");
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Failed to schedule hourly job");
            }
        }
    }
}