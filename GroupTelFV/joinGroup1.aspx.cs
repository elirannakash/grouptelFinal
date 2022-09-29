using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Configuration;
using System.IO;
using System.Net.Mail;

namespace GroupTelFV
{
    public partial class joinGroup1 : System.Web.UI.Page
    {
        public int pidToDisplay;
        public string EndDateToDisplay;
        public string paypalPrice;

        protected void Page_Load(object sender, EventArgs e)
        { /*check if the user logged in and if not, redirect to login page*/
            if (Session["Login"] == null)
            {

                Response.Redirect("login.aspx");

            }

            int i;
            /*create a product display according to the data received from previous page*/
            int Pid = int.Parse("" + Request["Pid"]);
            Session["Pid"] = Pid;
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            /*create a variable that holds the number of orders made for the product*/
            string Sql = $"select count(*) as total from T_order where pid = {Pid}";
            SqlConnection Conn = new SqlConnection(Connstr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            int totalOrders = (int)Cmd.ExecuteScalar();

            Conn.Close();

            /*create a list of orders and products from the GLOBAL file*/
            List<ProdList> tmp1 = (List<ProdList>)Application["LstProd"];
            List<OrderList> tmp3 = (List<OrderList>)Application["Lstorder"];
            List<ProdList> tmp2 = new List<ProdList>();
            for (i = 0; i < tmp1.Count; i++)
            {



                if (tmp1[i].Pid == Pid)
                {
                    ProdList pr1 = new ProdList()
                    {
                        Cid = tmp1[i].Cid,
                        Pdisc = tmp1[i].Pdisc,
                        Pid = tmp1[i].Pid,
                        PfinePrint = tmp1[i].PfinePrint,
                        Pname = tmp1[i].Pname,
                        Ppic = tmp1[i].Ppic,
                        Price = tmp1[i].Price,
                        Pquantity = tmp1[i].Pquantity,
                        Pquantity2 = tmp1[i].Pquantity2,
                        EndDate = tmp1[i].EndDate



                    };
                    int quantCheck;
                    pidToDisplay = tmp1[i].Pid;
                    paypalPrice = tmp1[i].Price;
                    EndDateToDisplay = pr1.EndDate;
                    Session["Price"] = tmp1[i].Price;
                    Session["EndDate"] = tmp1[i].EndDate;
                    Session["Pname"] = tmp1[i].Pname;
                    Session["Ppic"] = tmp1[i].Ppic;
                    Session["Pid"] = tmp1[i].Pid;
                    Session["Pdisc"] = tmp1[i].Pdisc;
                    Session["Pfineprint"] = tmp1[i].PfinePrint;
                    Session["Pquantity2"] = tmp1[i].Pquantity2;
                    quantCheck = tmp1[i].Pquantity;
                    tmp2.Add(pr1);
                    string price = tmp1[i].Price;
                    //check if the quantity of orders is exactly the amount of the quantity of the product and if so, send an email to 
                    //the users in the purchace group, show a message that the group is closed, delete the pypal button and remove countdown
                    DateTime end = DateTime.Parse(tmp1[i].EndDate);
                    if (tmp1[i].Pquantity > totalOrders && end < DateTime.Today && tmp1[i].Pquantity2 == 0)
                    {
                        string Sql1 = $"Update  T_Prod Set Pquantity2 = REPLACE( Pquantity2, 0, 1) WHERE Pid = {Pid}";
                        string Connstr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";

                        SqlConnection Conn1 = new SqlConnection(Connstr1);
                        Conn1.Open();
                        SqlCommand Cmd1 = new SqlCommand(Sql1, Conn1);
                        Cmd1.ExecuteNonQuery();

                        Conn1.Close();
                        for (int q = 0; q < tmp3.Count; q++)
                        {
                            if (Pid == tmp3[q].pid)
                            {
                                string UserMail = tmp3[q].Email;
                                /*for mail NEW*/
                                string emailSender = "grouptelgroup@gmail.com".ToString();
                                string emailSenderPassword = "jwditjrajoropslw".ToString();
                                string emailSenderHost = "smtp.gmail.com".ToString();
                                int emailSenderPort = Convert.ToInt16("587");
                                Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


                                string FilePath = @"H:\האחסון שלי\גרסה סופית לפרויקט- עדיין צריך לעשות דף מוצר\GroupTelFV\GroupTelFV\EmailTemplates\orderCancelNoBuyers.html";
                                StreamReader str = new StreamReader(FilePath);
                                string MailText = str.ReadToEnd();
                                str.Close();
                                MailText = MailText.Replace("[newusername]", UserMail);
                                MailText = MailText.Replace("[Pname]", (string)Session["Pname"]);
                                MailText = MailText.Replace("[Price]", (string)Session["Price"]);
                                MailText = MailText.Replace("[Ppic]", (string)Session["Ppic"]);
                                MailText = MailText.Replace("[Pdisc]", (string)Session["Pdisc"]);
                                MailText = MailText.Replace("[Pfineprint]", (string)Session["Pfineprint"]);
                                string subject = "ביטול רכישה עקב מחסור ברוכשים";
                                //Base class for sending email  
                                MailMessage _mailmsg = new MailMessage();

                                //Make TRUE because our body text is html  
                                _mailmsg.IsBodyHtml = true;

                                //Set From Email ID  
                                _mailmsg.From = new MailAddress(emailSender);

                                //Set To Email ID  
                                _mailmsg.To.Add(UserMail);

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

                            }
                            if (q == tmp3.Count - 1)
                            {
                                Response.Redirect("groupclosed.aspx?Pid=Pid");
                            }
                        }
                    }      

                            if (tmp1[i].Pquantity == totalOrders && tmp1[i].Pquantity2 == 0)
                            {

                                string Sql2 = $"Update  T_Prod Set Pquantity2 = REPLACE( Pquantity2, 0, 1) WHERE Pid = {Pid}";
                                string Connstr2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";

                                SqlConnection Conn2 = new SqlConnection(Connstr2);
                                Conn2.Open();
                                SqlCommand Cmd2 = new SqlCommand(Sql2, Conn2);
                                Cmd2.ExecuteNonQuery();

                                Conn2.Close();
                                for (int r = 0; r < tmp3.Count; r++)
                                {
                                    if (Pid == tmp3[r].pid)
                                    {
                                        string UserMail = tmp3[r].Email;
                                        /*for mail NEW*/
                                        string emailSender = "grouptelgroup@gmail.com".ToString();
                                        string emailSenderPassword = "jwditjrajoropslw".ToString();
                                        string emailSenderHost = "smtp.gmail.com".ToString();
                                        int emailSenderPort = Convert.ToInt16("587");
                                        Boolean emailIsSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSSL"]);


                                        string FilePath = @"H:\האחסון שלי\גרסה סופית לפרויקט- עדיין צריך לעשות דף מוצר\GroupTelFV\GroupTelFV\EmailTemplates\GroupClosed.html";
                                        StreamReader str = new StreamReader(FilePath);
                                        string MailText = str.ReadToEnd();
                                        str.Close();
                                        MailText = MailText.Replace("[newusername]", UserMail);
                                        MailText = MailText.Replace("[Pname]", (string)Session["Pname"]);
                                        MailText = MailText.Replace("[Price]", (string)Session["Price"]);
                                        MailText = MailText.Replace("[Ppic]", (string)Session["Ppic"]);
                                        MailText = MailText.Replace("[Pdisc]", (string)Session["Pdisc"]);
                                        MailText = MailText.Replace("[Pfineprint]", (string)Session["Pfineprint"]);
                                        string subject = "הקבוצה נסגרה! ברכות על רכישתכם";
                                        //Base class for sending email  
                                        MailMessage _mailmsg = new MailMessage();

                                        //Make TRUE because our body text is html  
                                        _mailmsg.IsBodyHtml = true;

                                        //Set From Email ID  
                                        _mailmsg.From = new MailAddress(emailSender);

                                        //Set To Email ID  
                                        _mailmsg.To.Add(UserMail);

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

                                    }
                                    if (r == tmp3.Count)
                                    {
                                        Response.Redirect("groupclosed.aspx?Pid=Pid");
                                    };
                                }
                            }




                            if (tmp1[i].Pquantity > totalOrders && tmp1[i].Pquantity2 == 0)
                            {
                                LtlMsg.Text = "נותרו עוד:" + (tmp1[i].Pquantity - totalOrders) + " לרכישה " + " מתוך: " + tmp1[i].Pquantity;
                            }



                            else
                            {

                                Response.Redirect("groupclosed.aspx?Pid=Pid");



                            }


                        

                    }

                


                

            
                    RptProd.DataSource = tmp2;
                    RptProd.DataBind();


                    //getting today date for timer

                    string date = DateTime.Now.ToString("MM-dd-yyyy");
                    string timer = $"var countDownDate = new Date('${date}')";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "timer", timer, true);

            }
        }
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Session["results"] = searchBox.Text;
            Response.Redirect("results.aspx");
        }

        protected void searchBtn_Click1(object sender, EventArgs e)
        {
            Session["results"] = searchBox.Text;
            Response.Redirect("results.aspx");
        }
    }

      

       
}
