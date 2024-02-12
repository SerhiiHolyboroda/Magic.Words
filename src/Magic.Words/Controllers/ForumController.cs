using Hangfire;
using Magic.Words.Core.Data;
using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
using Magic.Words.Infrastructure.Jobs;
using Magic.Words.Shared.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Magic.Words.Web.Controllers
{

    public class ForumController : Controller
    {

        private readonly ILogger<ForumController> _logger;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TestJobs _testJobs;
        public ForumController(TestJobs testJobs, IHttpClientFactory httpClientFactory, IUnitOfWork unitOfWork, IEmailSender emailSender, ILogger<ForumController> logger, ApplicationDbContext context, IHubContext<MyHub> hubContext) {
            _hubContext = hubContext;
        
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
            _httpClientFactory = httpClientFactory;
            _testJobs = testJobs; 
        }
        public async Task<IActionResult> Index()
        {

            //      var receiver = "olega3550@gmail.com";
            //     var subject = "Test";
            //     var message = "Hello world";
            try
            {
                //  await _emailSender.SendEmailAsync(receiver, subject, message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw;
            }
            List<Topic> objSubscriptionList = _unitOfWork.TopicRepository
     .GetAll()
     .Where(a => a.isActive)
     .ToList();

            foreach (var topic in objSubscriptionList)
            {
                // Fetch comments for each topic
                topic.Comments = _unitOfWork.CommentRepository
                    .GetAll()
                    .Where(c => c.TopicId == topic.TopicId)
                    .ToList();
            }
            return View(objSubscriptionList);
        }



        [HttpPost]
        public async Task<IActionResult> CreateComment(int topicId, string commentContent)
        {
            try
            {
                var topic = _context.Topics.Find(topicId);

            if (topic == null || !topic.isActive)
            {
                return NotFound(); // or handle the error as per your requirement
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Find(userId);


            var comment = new Comment
            {
                Content = commentContent,
                CreatedAt = DateTime.Now,
                isActive = true,
                ApplicationUserId = userId,
                ApplicationUser = (ApplicationUser)user,
                TopicId = topicId,
                Topic = _context.Topics.Find(topicId)
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
                //         await _hubContext.Clients.All.SendAsync("ReceiveComment", commentContent);
                RecurringJob.AddOrUpdate("HourlyTopicCheck", () => _testJobs.CheckAndSendEmailForNewTopics(), Cron.Hourly);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                _logger.LogError($"An error occurred while creating a comment: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
                // You can customize the error handling based on your application's requirements
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateTopic(Topic topic) {
            
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                Topic topicc = new Topic
                {
                    Title = topic.Title,
                    Content = topic.Content,
                    CreatedAt = DateTime.Now,
                    isActive = false,
                    ApplicationUserId = userId
                };

                _context.Topics.Add(topicc);
                await _context.SaveChangesAsync();

                List<Topic> AA = new List<Topic>();
                AA.Add(topicc);
                // Assuming _testJobs.CheckAndSendEmailForNewTopics() returns a Task
                RecurringJob.AddOrUpdate("HourlyTopicCheck", () => _testJobs.SendEmailToAdministrator(AA), Cron.Hourly);
            RecurringJob.AddOrUpdate("HourlyTopicCheck", () => _testJobs.CheckAndSendEmailForNewTopics(), Cron.Hourly);

            //гал  



            return RedirectToAction("Index");
            // If the model state is not valid, return to the create topic view with errors
            //  return View(topic);
        }




        /*
        [HttpPost]
        [Route("TestHourlyJob")]
        public async Task<ActionResult> TestHourlyJob() {
            var client = _httpClientFactory.CreateClient();

            JobController.CreateHourlyJobToCheckTopics
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


        */





        [HttpPost]
        public async Task<IActionResult> 
            
            DeleteCommentAsync(int commentId) {
            // Implement logic to delete the comment
            var commentToDelete = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);
            await _hubContext.Clients.All.SendAsync("DeleteComment", commentId);
          
            if (commentToDelete != null)
            {
                // If you have a foreign key relationship, you might need to remove the comment from the topic's collection
                var topic = _context.Topics.FirstOrDefault(t => t.Comments.Any(c => c.CommentId == commentId));
                if (topic != null)
                {
                    topic.Comments.Remove(commentToDelete);
                }

                // Delete the comment from the database
                _context.Comments.Remove(commentToDelete);
                _context.SaveChanges();

              
                // Redirect to the forum index or wherever you want to go after deletion
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where the comment is not found
                return NotFound();
            }
        }
    }
}