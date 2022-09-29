using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupTelFV
{
    public partial class groupclosed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { /*check if the user logged in and if not, redirect to login page*/
            if (Session["Login"] == null)
            {

                Response.Redirect("login.aspx");

            }

            int i;
            int Pid = (int)Session["Pid"];

            /*check if the number of orders made for a product is the same as the quantity of the product that is allowed to sell and create a variable that holds that info*/
            string Connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GroupTelDBNEW.mdf; Integrated Security=True;Connect Timeout=30";
            string Sql = $"select count(*) as total from T_order where pid = {Pid}";
            SqlConnection Conn = new SqlConnection(Connstr);
            Conn.Open();
            SqlCommand Cmd = new SqlCommand(Sql, Conn);
            int totalOrders = (int)Cmd.ExecuteScalar();

            Conn.Close();


            List<ProdList> tmp1 = (List<ProdList>)Application["LstProd"];
            List<OrderList> tmp3 = (List<OrderList>)Application["Lstorder"];
            List<ProdList> tmp2 = new List<ProdList>();
            for (i = 0; i < tmp1.Count; i++)
            {

                /*create a display of the product*/

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
                    

                   
                    Session["Pquantity"] = tmp1[i].Pquantity;
                    tmp2.Add(pr1);
                   
                }
                
            }
            RptProd.DataSource = tmp2;
            RptProd.DataBind();
            int quant = (int)Session["Pquantity"];
            LtlMsg.Text = "קבוצה סגורה, בקבוצה השתתפו: " + (quant ) + "" + "אנשים";
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Session["results"] = searchBox.Text;
            Response.Redirect("results.aspx");
        }
    }
}