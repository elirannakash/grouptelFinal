using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;

namespace GroupTelFV
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            int countMail = 0;
            List<users> LstUsers = (List<users>)Application["LstUsers"];
            List<users> Users1 = new List<users>();
            for (int i = 0; i < LstUsers.Count; i++)
            {
                users u1 = new users() { Email = LstUsers[i].Email };
                Users1.Add(u1);
                countMail++;
                Session["countMail"] = countMail;
            }

            /*check if the Email was already entered*/

            int count = (int)Session["countMail"];
            for(int y=0; y<count; y++)
            {
                if(identity.Text == Users1[y].Email)
                {
                    string scriptText1 = "alert('משתמש כבר רשום, יש להיכנס לדף התחברות '); window.location='" + Request.ApplicationPath + "login.aspx'";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText1, true);
                    break;

                }
                else if(y == count -1)
                {


                    /*create a user in the user table (T_users) after registration*/
                    string Sql = $"Insert into T_users(Email, Phone, UserPass, UserName, UserPass2) values (N'{identity.Text}',N'{Phone.Text}',N'{UserPass.Text}' ,N'{UserName.Text}',N'{UserPass2.Text}')";
                    string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";

                    SqlConnection Conn = new SqlConnection(Connstr);
                    Conn.Open();
                    SqlCommand Cmd = new SqlCommand(Sql, Conn);
                    Cmd.ExecuteNonQuery();

                    Conn.Close();
                    /*for mail NEW*/
                    string emailSender = "grouptelgroup@gmail.com".ToString();
                    string emailSenderPassword = "jwditjrajoropslw".ToString();
                    string emailSenderHost = "smtp.gmail.com".ToString();
                    int emailSenderPort = Convert.ToInt16("587");
                    Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


                    string FilePath = @"H:\האחסון שלי\גרסה סופית לפרויקט- עדיין צריך לעשות דף מוצר\GroupTelFV\GroupTelFV\EmailTemplates\confirmation-reg.html";
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();
                    str.Close();
                    MailText = MailText.Replace("[newusername]", UserName.Text.Trim());
                    MailText = MailText.Replace("[password]", UserPass.Text.Trim());
                    string subject = "ברוכים הבאים לגרופטל";
                    //Base class for sending email  
                    MailMessage _mailmsg = new MailMessage();

                    //Make TRUE because our body text is html  
                    _mailmsg.IsBodyHtml = true;

                    //Set From Email ID  
                    _mailmsg.From = new MailAddress(emailSender);

                    //Set To Email ID  
                    _mailmsg.To.Add(identity.Text.ToString());

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
                    /*show an alert window for registration success and redirecting to the main page*/
                    // Response.Redirect("login.aspx");
                    string scriptText2 = "alert('נרשמתם בהצלחה! מעתה תוכלו ליהנות מרכישות קבוצתיות, כעת אתם רק צריכים להתחבר שוב עם הפרטים שלכם '); window.location='" + Request.ApplicationPath + "login.aspx'";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText2, true);

                    break;
                    
                }
                
            }
           
              
           
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
        }
    }
}