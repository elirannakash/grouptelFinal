using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.SqlClient;


namespace GroupTelFV
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            string sql = $"select * from T_Prod";
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            //string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\האחסון שלי\FinalProject\DB UPDATED ELIRAN\GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            SqlConnection Conn = new SqlConnection(Connstr);
            Conn.Open();
            SqlCommand cmdprod = new SqlCommand(sql, Conn);
            SqlDataReader Drprod = cmdprod.ExecuteReader();
            string tmprod = null, tmprod1 = null, tmprod2 = null, tmprod3 = null, tmprod4 = null, tmprod5 = null, tmprod6 = null, tmprod7 = null, tmprod8 = null, tmprod9 = null,tmprod10=null;
            List<ProdList> tmp = new List<ProdList>();
            Application["Prods"] = tmp;

            while (Drprod.Read())
            {
                int Pid = (int)Drprod["Pid"];
                int Cid = (int)Drprod["Cid"];
                string Price = (string)Drprod["Price"];
                string Pname = (string)Drprod["Pname"];
                string Ppic = (string)Drprod["Ppic"];
                string Pdisc = (string)Drprod["Pdisc"];
                int Pquantity = (int)Drprod["Pquantity"];
                int Pquantity2 = (int)Drprod["Pquantity2"];
                string PfinePrint = (string)Drprod["PfinePrint"];
                string EndDate = (string)Drprod["EndDate"];
                string menuCat = (string)Drprod["menuCat"];





                ProdList Plist = new ProdList() { Price = Price, Pname = Pname, Ppic = Ppic, Pdisc = Pdisc, Pquantity = Pquantity, PfinePrint = PfinePrint, Cid = Cid, Pid = Pid, EndDate = EndDate, Pquantity2 = Pquantity2, menuCat=menuCat };
                tmp.Add(Plist);
                tmprod += "Price:" + Drprod["Price"];
                tmprod1 += "Pname:" + Drprod["Pname"];
                tmprod2 += "Ppic:" + Drprod["Ppic"];
                tmprod3 += "Pdisc:" + Drprod["Pdisc"];
                tmprod4 += "Pquantity:" + Drprod["Pquantity"];
                tmprod5 += "PfinePrint:" + Drprod["PfinePrint"];
                tmprod6 += "Cid:" + Drprod["Cid"];
                tmprod7 += "Pid:" + Drprod["Pid"];
                tmprod8 += "EndDate:" + Drprod["EndDate"];
                tmprod9 += "Pquantity2:" + Drprod["Pquantity2"];
                tmprod10+="menuCat:" + Drprod["menuCat"];



            }
            Application["LstProd"] = tmp;
            Drprod.Close();



            string sql1 = $"select * from T_order";
            string Connstr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            //string Connstr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\האחסון שלי\FinalProject\DB UPDATED ELIRAN\GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            SqlConnection Conn1 = new SqlConnection(Connstr1);
            Conn1.Open();
            SqlCommand cmdorder = new SqlCommand(sql1, Conn1);
            SqlDataReader Drorder = cmdorder.ExecuteReader();
            string tmpord = null, tmpord1 = null, tmpord2 = null, tmpord3 = null, tmpord4 = null;
            DateTime tmpord5 = DateTime.Now ;
            List<OrderList> tmp1 = new List<OrderList>();
            Application["Lstorder"] = tmp1;

            while (Drorder.Read())
            {

                int Pid = (int)Drorder["Pid"];
                int Oid = (int)Drorder["Oid"];
                string Email = (string)(Drorder["Email"] + "");
                string Ppic = (string)(Drorder["Ppic"] + "");
                string Pname = (string)(Drorder["Pname"] + "");
                DateTime Odate =(DateTime)(Drorder["Odate"]);





                OrderList Olist = new OrderList() { Oid = Oid, pid = Pid, Email = Email, Pname = Pname, Ppic = Ppic,
                    Odate=Odate };
                tmp1.Add(Olist);
                tmpord += "Oid" + Drorder["Oid"];
                tmpord1 += "Pid:" + Drorder["Pid"];
                tmpord2 += "Email:" + Drorder["Email"];
                tmpord3 += "Pname" + Drorder["Pname"];
                tmpord4 += "Ppic" + Drorder["Ppic"];
                tmpord5 =  (DateTime)Drorder["Odate"];



            }
            Application["Lstorder"] = tmp1;
            Drorder.Close();





            string sql2 = $"select * from T_users";
            string Connstr2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            //string Connstr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\האחסון שלי\FinalProject\DB UPDATED ELIRAN\GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            SqlConnection Conn2= new SqlConnection(Connstr2);
            Conn2.Open();
            SqlCommand cmduser = new SqlCommand(sql2, Conn2);
            SqlDataReader Druser = cmduser.ExecuteReader();
            string tmpusr = null, tmpusr1 = null, tmpusr2 = null, tmpusr3 = null, tmpusr4 = null;
           
            List<users> tmp2 = new List<users>();
            Application["LstUsers"] = tmp2;

            while (Druser.Read())
            {

                string Email = (string)Druser["Email"] + "";
                string Phone = (string)Druser["Phone"];
                string UserPass = (string)(Druser["UserPass"]);
                string UserName = (string)(Druser["UserName"]);
                string UserPass2 = (string)(Druser["UserPass2"]);





                users ulist = new users()
                {
                    Email = Email,
                    Phone = Phone,
                    UserPass = UserPass,
                    UserName = UserName,
                    UserPass2 = UserPass2,
                };
                tmp2.Add(ulist);
                tmpusr += "Email" + Druser["Email"];
                tmpusr1 += "Phone:" + Druser["Phone"];
                tmpusr2 += "UserPass:" + Druser["UserPass"];
                tmpusr3 += "UserName" + Druser["UserName"];
                tmpusr4 += "UserPass2" + Druser["UserPass2"];



            }
            Application["LstUsers"] = tmp2;
            Druser.Close();



            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}