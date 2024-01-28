using Hangfire;
using Magic.Words.Infrastructure.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase {

        public ActionResult CreateBackhroundJob() {
            //  BackgroundJob.Enqueue( () => Console.WriteLine("Background Job Triggered"));
            BackgroundJob.Enqueue<TestJobs>(x => x.WriteLog("Background Job Triggered"));
            return Ok();
        }

        [HttpPost]
        [Route("CreateScheduledJob")]
        public ActionResult CreateScheduleddJob() {

            var scheduleDateTime = DateTime.UtcNow.AddSeconds(5);
            var dateTimeOffset = new DateTimeOffset(scheduleDateTime);
            //  BackgroundJob.Schedule(() => Console.WriteLine("Scheduled Job Triggered"), dateTimeOffset );
            BackgroundJob.Schedule<TestJobs>(x => x.WriteLog("Background Job Triggered"), dateTimeOffset);
            return Ok();
        }

        [HttpPost]
        [Route("CreateContinuationJob")]
        public ActionResult CreateContinuationJob() {
            var scheduleDateTime = DateTime.UtcNow.AddSeconds(5);
            var dateTimeOffset = new DateTimeOffset(scheduleDateTime);
            // var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Scheduled Job 2 Triggered"), dateTimeOffset);
            var jobId = BackgroundJob.Schedule<TestJobs>(x  => x.WriteLog("Scheduled Job 2Triggered"), dateTimeOffset);

            //  var job2Id = BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuation Job 1 Triggered"));
            // var job3Id = BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuation Job 2 Triggered"));
            //  var job4Id = BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continuation Job 3 Triggered"));
            var job2Id = BackgroundJob.ContinueJobWith<TestJobs>(jobId, x => x.WriteLog("Scheduled Job 1 Triggered"));
            var job3Id = BackgroundJob.ContinueJobWith<TestJobs>(job2Id, x => x.WriteLog("Scheduled Job 2 Triggered"));
            var job4Id = BackgroundJob.ContinueJobWith<TestJobs>(job3Id, x => x.WriteLog("Scheduled Job 3 Triggered"));

            return Ok();
        }

        [HttpPost]
        [Route("CreateRecurringJob")]
        public ActionResult CreateRecurringJob() {
            //  RecurringJob.AddOrUpdate("RecuringJob1", () => Console.WriteLine("Recurring Job Triggered"), "* * * * *");
            RecurringJob.AddOrUpdate<TestJobs>("RecuringJob1", x => x.WriteLog("Recurring Job Triggered"), "* * * * *");
            return Ok();
        }



    }
}
