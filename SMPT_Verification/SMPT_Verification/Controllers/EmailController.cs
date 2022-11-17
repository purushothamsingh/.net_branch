using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.X500;

namespace SMPT_Verification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {

        [HttpPost]
        [Route("{requestEmail}/{subject}")]
        public IActionResult SendEmail(string requestEmail,string subject)
        {
            Random randomNumber =  new Random();
            int value = randomNumber.Next(100000, 999999);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("kpurushothamsingh@gmail.com"));
            email.To.Add(MailboxAddress.Parse(requestEmail));
            email.To.Add(MailboxAddress.Parse("kpurushothamsingh@gmail.com"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text= subject };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            smtp.Authenticate("kpurushothamsingh@gmail.com", "evqypbiaclpnrrlb");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok(value);
        }
    }
}
