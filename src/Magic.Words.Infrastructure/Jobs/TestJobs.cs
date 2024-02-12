using Magic.Words.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Magic.Words.Core.Data;

namespace Magic.Words.Infrastructure.Jobs {
    public class TestJobs {
        private readonly ILogger _logger;

 

        private readonly ApplicationDbContext _context;

        public TestJobs(ApplicationDbContext context, ILogger<TestJobs> logger) {
            _logger = logger;
            _context = context;
        }
        public void WriteLog(string logMessage) {
            _logger.LogInformation($"{DateTime.Now:yyyy-MM-dd hh:mm:ss tt} {logMessage}");
        }

        public  void CheckAndSendEmailForNewTopics() {
       
            var lastHour = DateTime.UtcNow.AddHours(-1);
            var newTopics = _context.Topics
                                    .Where(t => t.CreatedAt >= lastHour && t.isActive)
                                    .ToList();

            if (newTopics.Any())
            {

                SendEmailToAdministrator(newTopics);
            }
        }





        public  void SendEmailToAdministrator(List<Topic> newTopics) {
      
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("admin@example.com", "password"),
                EnableSsl = true,
            };

    
            var mailMessage = new MailMessage
            {
                From = new MailAddress("admin@example.com"),
                Subject = "New topics created",
                Body = $"New topics created in the last hour:\n\n{string.Join("\n", newTopics.Select(t => $"{t.Title} - {t.Content}"))}",
                IsBodyHtml = false
            };
            mailMessage.To.Add("admin@example.com");
 
          smtpClient.Send(mailMessage);
        }
    }
}