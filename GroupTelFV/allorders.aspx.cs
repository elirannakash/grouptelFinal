using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupTelFV
{
    public partial class allorders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //show recent purchases of user
            //create a list of orders to show customer purchase history
            List<OrderList> Lstorder = (List<OrderList>)Application["Lstorder"];
            List<OrderList> tmpo = new List<OrderList>();
            int j, count = 0,i;
            if (Session["Login"] != null)
            {
                for (j = Lstorder.Count - 1; j >= 0; j--)
                {



                    if (Lstorder[j].Email == (string)Session["UserEmail"])
                    {
                      count++;
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
                        

                    }
                    RptOrder.DataSource = tmpo;
                    RptOrder.DataBind();

                    if (count == 0 && j == 0)
                    {
                        LtlOrd.Text = "לא קיימות הזמנות על שמך עדיין";
                    }

                }

            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Session["results"] = searchBox.Text;
            Response.Redirect("results.aspx");
        }
    }
}
