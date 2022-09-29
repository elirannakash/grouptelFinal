using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GroupTelFV
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*create a list from the GLOBAL file and comparing it to the search input of the user and creating a list of products relevent*/
            List<ProdList> LstProd1 = (List<ProdList>)Application["LstProd"];
            List<ProdList> tmpb = new List<ProdList>();
            string result = (string)Session["results"];
            int i;
            
            


                for (i = 0; i < LstProd1.Count; i++)
                {
                    if (LstProd1[i].Pdisc.Contains(result))
                    {

                        ProdList pr1 = new ProdList()
                        {
                            Cid = LstProd1[i].Cid,
                            Pdisc = LstProd1[i].Pdisc,
                            Pid = LstProd1[i].Pid,
                            PfinePrint = LstProd1[i].PfinePrint,
                            Pquantity = LstProd1[i].Pquantity,
                            Pname = LstProd1[i].Pname,
                            Ppic = LstProd1[i].Ppic,
                            Price = LstProd1[i].Price
                        };
                        tmpb.Add(pr1);
                    }
                }
            
            RptAllProds.DataSource = tmpb;
            RptAllProds.DataBind();

            if(tmpb.Count == 0)
            {
                LtlMsg.Text = "לא קיימות תוצאות עבור החיפוש";
            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {

            Session["results"] = searchBox.Text;
            Response.Redirect("results.aspx");
        }
    }
}