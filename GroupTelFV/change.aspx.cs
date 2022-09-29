using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace GroupTelFV
{
    public partial class change : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { /*check if the user logged in and if not, redirect to login page*/
            if (Session["Login"] == null)
            {
                Response.Redirect("Login.aspx");
            }


            UserName.Text = (string)Session["UserName"];
            UserEmail.Text = (string)Session["UserEmail"];
            UserPhone.Text = (string)Session["UserPhone"];
            UserPass.Text = (string)Session["UserPass"];
        }

        protected void changeInfo_Click(object sender, EventArgs e)
        {
            //changing user phone  in database
           if(NewPhone.Text == "")
            {
                LtlPass.Text = "נא להכניס טלפון תקין";
            }
            else
            {
                string sql1 = $"update T_Users set Phone={NewPhone.Text} where Phone={Session["UserPhone"]} ";
                string conn1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
                SqlConnection newonn = new SqlConnection(conn1);
                newonn.Open();
                SqlCommand Cmd = new SqlCommand(sql1, newonn);
                Cmd.ExecuteNonQuery();
                newonn.Close();

                LtlPass.Text = " טלפון שונה בהצלחה, שינויים ייכנסו לתוקף בכניסתך הבאה." +
                    "תודה :)";

            }





        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Session["results"] = searchBox.Text;
            Response.Redirect("results.aspx");
        }

        protected void changePass_Click(object sender, EventArgs e)
        {
            ////changing user password  in database
            if(NewPass.Text == "")
            {
                LtlPass.Text = "נא להכניס סיסמה תקינה";
            }
            else
            {
                string sql3 = $"update T_Users set UserPass2='{NewPass.Text}' where  UserPass2 = '{Session["UserPass"]}' AND Email =N'{Session["UserEmail"]}'";
                string sql2 = $"update T_Users set UserPass='{NewPass.Text}' where  UserPass = '{Session["UserPass"]}' AND Email =N'{Session["UserEmail"]}'";
                string conn1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
                SqlConnection newonn = new SqlConnection(conn1);
                newonn.Open();
                SqlCommand Cmd2 = new SqlCommand(sql2, newonn);
                Cmd2.ExecuteNonQuery();
                newonn.Close();
                SqlConnection newonn1 = new SqlConnection(conn1);
                newonn1.Open();
                SqlCommand Cmd3 = new SqlCommand(sql3, newonn1);
                Cmd3.ExecuteNonQuery();
                newonn1.Close();
                LtlPass.Text = " סיסמה שונתה בהצלחה, שינויים ייכנסו לתוקף בכניסתך הבאה." +
               "תודה :)";
            }

           
            //newcon1.Close();

           
        }
    }
}