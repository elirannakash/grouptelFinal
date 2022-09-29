using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupTelFV
{
    public partial class categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i;
            /*check if the user logged in and if not, redirect to login page*/
            if (Session["Login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string menuCat = Request["menuCat"];
            

            //list of products from the global file that are from the same category and has the same menuCat name(electronics, furnitures, etc)
            List<ProdList> LstProd1 = (List<ProdList>)Application["LstProd"];
            List<ProdList> tmpb = new List<ProdList>();
            for (i = 0; i < LstProd1.Count; i++)
            {

                if (LstProd1[i].Cid == (int)Session["Cid"] && LstProd1[i].menuCat == menuCat )
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
                        Price = LstProd1[i].Price,
                        EndDate = LstProd1[i].EndDate
                    };
                    tmpb.Add(pr1);



                }


            }

            RptAllProds.DataSource = tmpb;
            RptAllProds.DataBind();
        }

    }
}
