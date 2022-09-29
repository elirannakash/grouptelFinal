using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace GroupTelFV
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegButton_Click(object sender, EventArgs e)
        {
            if (Session["Login"] != null)
            {
                Response.Redirect("profile.aspx");
            }

        }

        protected void RegButton_Click1(object sender, EventArgs e)
        {
            /*check if the data entered in the textbox is the same as the data in database for login*/
            string sql = $"select * from T_users where Email='{identity.Text}' and UserPass='{UserPass.Text}'";
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            SqlConnection Conn = new SqlConnection(Connstr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                User tmp = new User()
                {
                    Email = identity.Text,
                    UserName = (string)Dr["UserName"]
                };
                Session["Login"] = tmp;
                Session["UserEmail"] = identity.Text;
                Session["UserPhone"] = (string)Dr["Phone"];
                Session["UserName"] = (string)Dr["UserName"];
                Session["UserPass"]=(string)Dr["UserPass"];


                Conn.Close();
                Response.Redirect("profile.aspx");

            }
            else
            {
                LtlLogin.Text = "<span style='color:red'>משתמש אינו רשום במערכת<span>";
                Conn.Close();
            }
        }
    }
}