using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
namespace mailSender1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SendEmail(GetUserName(), GetPassword());
            Console.ReadLine(); 
        }
        public static void SendEmail(string fromAddress, string password)
        {
             SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)
                
            };
            string subject = "ברוכים הבאים לקבוצת הרכישה גרופטל";
            string body = $"תודה רבה על הצטרפותכם לשירות. מעתה תוכלו לבצע רכישות קבוצתיות, לקבל עדכונים וכמו כן, תקבלו גישה לאיזור האישי שלכם @{DateTime.UtcNow:F} " ;
            try
            {
                Console.WriteLine("שולח מייל *************");
                email.Send(fromAddress, ToAddress(),subject, body);
                Console.WriteLine("מייל נשלח ***********");
            }
            catch (SmtpException e)
            {
                Console.Write(e.ToString());
            }
        }
        public static string GetUserName()
        {
            return "grouptelgroup@gmail.com";
        }
        public static string GetPassword()
        {
            return "";
        }
        public static string ToAddress()
        {
            return "grouptelgroup@gmail.com";
        }
    }

}
