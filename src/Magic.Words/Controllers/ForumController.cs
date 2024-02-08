using Magic.Words.Core.Data;
using Magic.Words.Core.Models;
using Magic.Words.Core.Repositories;
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
  
        public ForumController(IUnitOfWork unitOfWork, IEmailSender emailSender, ILogger<ForumController> logger, ApplicationDbContext context, IHubContext<MyHub> hubContext) {
            _hubContext = hubContext;
        
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
         
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
        public async Task<IActionResult> CreateTopic(Topic topic)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.Find(userId);


                topic.CreatedAt = DateTime.Now;
                topic.isActive = true;
                topic.ApplicationUserId = userId;
                topic.ApplicationUser = (ApplicationUser)user;

                _context.Topics.Add(topic);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the create topic view with errors
            return View(topic);
        }

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