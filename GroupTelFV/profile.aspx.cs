using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace GroupTelFV
{
    public partial class profile1 : System.Web.UI.Page
    {
        public int pidToDisplay;
        public string EndDateToDisplay;
        public string paypalPrice;
        protected void Page_Load(object sender, EventArgs e)
        {

            UserName.Text = (string)Session["UserName"];
            UserEmail.Text = (string)Session["UserEmail"];
            UserPhone.Text =('0' + (string)Session["UserPhone"]);
            UserPass.Text =(string)Session["UserPass"];

            if (Session["Login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //show recent purchases of user
            //create a list of orders to show customer purchase history
            List<OrderList> Lstorder = (List<OrderList>)Application["Lstorder"];
            List<OrderList> tmpo = new List<OrderList>();
            int j, count = 0;

            if (Session["Login"] != null)
            {
                for (j = Lstorder.Count - 1; j >= 0; j--)
                {



                    if (Lstorder[j].Email == (string)Session["UserEmail"])
                    {
                        count++;
                        if (count < 4)
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
                        }

                    }
                    RptOrder.DataSource = tmpo;
                    RptOrder.DataBind();
                   
                    if (count == 0 && j == 0)
                    {
                        LtlOrd.Text = "<span style='font-size:2rem'>לא קיימות הזמנות על שמך עדיין</span>";
                    }

                }
                //create a list of products to recommand to user as per recent searches in search engine
                List<ProdList> LstProd1 = (List<ProdList>)Application["LstProd"];
                List<ProdList> tmpb = new List<ProdList>();
                string result = (string)Session["results"];
                int i, count1 = 0;
                if (Session["results"] != null)
                {



                    for (i = 0; i < LstProd1.Count; i++)
                    {



                        if (LstProd1[i].Pdisc.Contains(result))
                        {

                            if (count1 < 3)
                            {
                                count1++;
                                ProdList pr1 = new ProdList()
                                {
                                    Cid = LstProd1[i].Cid,
                                    Pdisc = LstProd1[i].Pdisc,
                                    Pid = LstProd1[i].Pid,
                                    PfinePrint = LstProd1[i].PfinePrint,
                                    Pquantity = LstProd1[i].Pquantity,
                                    Pname = LstProd1[i].Pname,
                                    Ppic = LstProd1[i].Ppic,
                                    Price = LstProd1[i].Price,
                                    EndDate = LstProd1[i].EndDate

                                };
                                EndDateToDisplay = LstProd1[i].EndDate;

                                string date = DateTime.Now.ToString("MM-dd-yyyy");
                                string timer = $"var countDownDate = new Date('${date}')";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "timer", timer, true);


                                tmpb.Add(pr1);

                            }
                            if (count1 >= 3)
                            {
                                break;
                            }

                        }


                    }

                }
                RptRec.DataSource = tmpb;
                RptRec.DataBind();
                if (Session["results"] == null)
                {
                    LtlRec.Text = "<span style='font-size:2rem'>לא נמצאו המלצות עבורך</span>";
                }

            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("Default.aspx");
        }

        

        protected void changeInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("change.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["Login"] = null;
            Response.Redirect("default.aspx");
        }

        protected void OrdBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("allorders.aspx");
        }
    }
}