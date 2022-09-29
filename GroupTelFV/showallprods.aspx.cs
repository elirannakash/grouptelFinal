using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GroupTelFV

{
    public partial class showallprods : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int i;
            /*check if the user logged in and if not, redirect to login page*/
            if (Session["Login"] == null)
            {
                Response.Redirect("login.aspx");
            }

            int Cid = int.Parse("" + Request["Cid"]);
            Session["Cid"] = Cid;
            //list of products from the global file that are from the same category(electronics, furnitures, etc)
            List<ProdList> LstProd1 = (List<ProdList>)Application["LstProd"];
            List<ProdList> tmpb = new List<ProdList>();
            List<ProdList> tmpc = new List<ProdList>();
            


            for (i = 0; i < LstProd1.Count; i++)
            {

                if (LstProd1[i].Cid == Cid)
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
                        EndDate = LstProd1[i].EndDate,
                        
                    };
                    tmpb.Add(pr1);
                }
                if(LstProd1[i].Cid == Cid)
                {
                    ProdList pr2 = new ProdList()
                    {
                        menuCat = LstProd1[i].menuCat
                    };
                    tmpc.Add(pr2);
                }
               
             

            }
            /*create a non duplicate list of categories for customer convenience in searching for correct product */
            List<ProdList> tmpd = tmpc.OrderBy(x => x.menuCat).ToList();
            for(int w=1; w<tmpd.Count; w++)
            {
                if(tmpd[w].menuCat == tmpd[w-1].menuCat)
                {
                    tmpd[w-1] = null;
                }
            }
            for(int q=0;q<tmpd.Count; q++)
            {
                if (tmpd[q] == null)
                {
                    tmpd.RemoveAt(q);
                    --q;
                }
                else
                    continue;
            }

            RptAllProds.DataSource = tmpb;
            RptAllProds.DataBind();
            RptCat.DataSource = tmpd;
            RptCat.DataBind();
        }
    }
}