using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupTelFV
{
    public partial class cancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*check if the user logged in and if not, redirect to login page*/
            if(Session["Login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            /*taking the relevent order ID that needs to be canceled*/
            int Oid = int.Parse("" + Request["Oid"]);
            int i;
            Session["Oid"] = Oid;
            Session["Oid1"] = "" + Oid;

            /*creating lists of poducts and orders from the GLOBAL file to compare in order to cancel order and delete from DB*/
            List<ProdList> tmp1 = (List<ProdList>)Application["LstProd"];
           
            List<OrderList> Lstorder = (List<OrderList>)Application["Lstorder"];
            List<OrderList> tmpo = new List<OrderList>();
           
            int j;
            /*creating the product presentation that needs to be canceled*/
            if (Session["Login"] != null)
            {
                for (j = 0 ; j< Lstorder.Count; j++)
                {
                    if (Lstorder[j].Oid == Oid)
                    {
                       

                        OrderList pr1 = new OrderList()
                            {
                                Pname = Lstorder[j].Pname,
                                Ppic = Lstorder[j].Ppic,
                                Email = Lstorder[j].Email,
                                Oid = Lstorder[j].Oid,
                                pid = Lstorder[j].pid,
                                Odate = Lstorder[j].Odate
                                
                            };
                            tmpo.Add(pr1);
                        Session["name"] = pr1.Pname;
                        /*a check to see if the group is closed or not. if yes, then customer can't cancel and if not, customer can cancel order*/
                        for (i = 0; i < tmp1.Count; i++)
                        {
                            if (tmp1[i].Pname == (string)Session["name"] )
                            {
                                Session["pquantity2"] = tmp1[i].Pquantity2;
                            }
                        }
                        
                    }
                    RptOrder.DataSource = tmpo;
                    RptOrder.DataBind();
                   
                }
            }
           
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {   /*checking if the input of the password of the customer matches the DB */
            if (cancel1.Text == (string)Session["UserPass"])
            {
                /*check if group is closed or not*/
                if((int)Session["pquantity2"] == 1)
                {
                    string scriptText = "alert('לא ניתן לבטל הזמנה זו מכיוון שהקבוצה כבר נסגרה'); window.location='" + Request.ApplicationPath + "profile.aspx'";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText , true);
                   
                }
                if((int)Session["pquantity2"] == 0)
                {
                    string Sql = $"Delete from T_order  where Oid = {Session["Oid"]}";
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


                    string FilePath = @"H:\האחסון שלי\גרסה סופית לפרויקט- עדיין צריך לעשות דף מוצר\GroupTelFV\GroupTelFV\EmailTemplates\cancelOrder.html";
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();
                    str.Close();
                    MailText = MailText.Replace("[newusername]", (string)Session["UserEmail"]);
                    MailText = MailText.Replace("[Oid]", (string)Session["Oid1"] );
                    MailText = MailText.Replace("[Pname]", (string)Session["name"]);
                    string subject = "ביטול הזמנה";
                    //Base class for sending email  
                    MailMessage _mailmsg = new MailMessage();

                    //Make TRUE because our body text is html  
                    _mailmsg.IsBodyHtml = true;

                    //Set From Email ID  
                    _mailmsg.From = new MailAddress(emailSender);

                    //Set To Email ID  
                    _mailmsg.To.Add((string)Session["UserEmail"]);

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
                    string scriptText = "alert('הזמנה בוטלה בהצלחה,לא תראו אותה בכניסתכם הבאה בפרופיל שלכם'); window.location='" + Request.ApplicationPath + "profile.aspx'";

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", scriptText, true);
                   

                }
                

            }
            else

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('הסיסמה שהוכנסה שגויה, נא להכניס את סיסמתכם.')", true);


        }
    }
}