using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Net.Mime;
using System.Text;


namespace GroupTelFV
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class orderUpdate : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["Login"] == null)
            {
                context.Response.Redirect("Login.aspx");
            }
            string pid = context.Request["Pid"] + "";
            string email = context.Session["UserEmail"] + "";
            User tmp = (User)context.Session["Login"];

            context.Response.ContentType = "text/plain";

            string Sql1 = $"Insert into T_order (Pid, Email,Ppic,Pname) values(N'{pid}',N'{email}',N'{context.Session["Ppic"]}',N'{context.Session["Pname"]}') ";

            string Connstr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";

            SqlConnection Conn1 = new SqlConnection(Connstr1);
            Conn1.Open();
            SqlCommand Cmd1 = new SqlCommand(Sql1, Conn1);
            Cmd1.ExecuteNonQuery();
            
            /*for mail NEW*******************************************************************/
            string emailSender = "grouptelgroup@gmail.com".ToString();
            string emailSenderPassword = "jwditjrajoropslw".ToString();
            string emailSenderHost = "smtp.gmail.com".ToString();
            int emailSenderPort = Convert.ToInt16("587");
            Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


            string FilePath = @"H:\האחסון שלי\גרסה סופית לפרויקט- עדיין צריך לעשות דף מוצר\GroupTelFV\GroupTelFV\EmailTemplates\OrderConfirmation.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            MailText = MailText.Replace("[Pname]", (string)context.Session["Pname"]);
            MailText = MailText.Replace("[Price]", (string)context.Session["Price"]);
            MailText = MailText.Replace("[Ppic]", (string)context.Session["Ppic"]);
            MailText = MailText.Replace("[Pdisc]", (string)context.Session["Pdisc"]);
            MailText = MailText.Replace("[Pfineprint]", (string)context.Session["Pfineprint"]);
          

            string subject = "תודה על הזמנתך!";
            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress(emailSender);

            //Set To Email ID  
            _mailmsg.To.Add(context.Session["UserEmail"].ToString());

            //Set Subject  
            _mailmsg.Subject = subject;

            //Set Body Text of Email   
            _mailmsg.Body = MailText;


            //Now set your SMTP   
            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);


            /*for mail NEW END*/


            Conn1.Close();
            context.Response.Write("OK");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}