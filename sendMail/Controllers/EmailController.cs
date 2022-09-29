using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace sendMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("silas25@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("silas25@ethereal.email"));
            email.Subject = "test email";
            email.Body = new TextPart(TextFormat.Html) { Text=body} ;

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("silas25@ethereal.email", "3qpGm7pstTntz4UD1Q");
            smtp.Send(email);
            smtp.Disconnect(true);
            return Ok();


        }
    }
}
