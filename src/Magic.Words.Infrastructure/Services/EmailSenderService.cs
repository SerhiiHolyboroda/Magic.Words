using Azure.Core;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
 
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
 
using MailKit.Security;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Mail;

namespace Magic.Words.Infrastructure.Services {
  //  [Route("api/[controller]")]
 //   [ApiController]
    public class EmailSenderService   : IEmailSender
        
        {
        public Task SendEmailAsync(string email, string subject, string message) {
     //   [HttpPost]
        //    public async void SendEmailAsync(string email, string subject, string message) {
                try
            {
            
                  var mail = "my122tes6eoleg@outlook.com";
                   var pw = "SF5r7f76464y";

                //     var mail = "olega3550@gmail.com";
                //    var pw = "olega3550@gmail.com1";

                var client = new SmtpClient("domain-com.mail.protection.outlook.com")
                    // var client = new SmtpClient("smtp.gmail.com", 465)
                    {
                        EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mail, pw),
                    DeliveryMethod = SmtpDeliveryMethod.Network

                };
            return client.SendMailAsync(
                new MailMessage(from: mail,
                to: email,
                subject, message));
             /*


                var emaill = new MimeMessage();
                emaill.From.Add(MailboxAddress.Parse("traymundo.gleason@ethereal.email"));
                emaill.To.Add(MailboxAddress.Parse("traymundo.gleason@ethereal.email")); 
                emaill.Subject = "Test Email Subject";
                emaill.Body = new TextPart(TextFormat.Html) { Text = message };
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 465, SecureSocketOptions.StartTls);
                smtp.Authenticate("traymundo.gleason@ethereal.email", "YuBzjHtScud3w2yAsn");
                smtp.Send(emaill);
                smtp.Disconnect(true);

                */

            }
            catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            Console.WriteLine($"An error occurred while sending email: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
}

       
    }
    }

