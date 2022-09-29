using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupTelFV
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //list of products from the global file
            List<ProdList> LstProd = (List<ProdList>)Application["LstProd"];
            //hotel list
            List<ProdList> hotels = new List<ProdList>();
            //electronics list
            List<ProdList> Electronics = new List<ProdList>();
            //furniture list
            List<ProdList> Furniture = new List<ProdList>();
            int i;
            // a loop to run on the database and insert results to repeater. needs to be configured for a limited amount of products
            for (i = 0; i < LstProd.Count; i++)
            {


                if (LstProd[i].Cid == 1)


                {


                    //a loop that checks if there are already 4 items in the specific list and if so, continues to next itteration. this is for better page vissibility and coherence. 
                    if (hotels.Count > 3)
                        continue;
                    ProdList p1 = new ProdList() { Pdisc = LstProd[i].Pdisc, PfinePrint = LstProd[i].PfinePrint, Pname = LstProd[i].Pname, Ppic = LstProd[i].Ppic, Pquantity = LstProd[i].Pquantity, Price = LstProd[i].Price, Cid = LstProd[i].Cid, Pid = LstProd[i].Pid, menuCat = LstProd[i].menuCat, EndDate = LstProd[i].EndDate, Pquantity2= LstProd[1].Pquantity2 };
                    hotels.Add(p1);
                  


                }
                else if (LstProd[i].Cid == 2)
                {
                    if (Electronics.Count > 3)
                        continue;
                    ProdList p2 = new ProdList() { Pdisc = LstProd[i].Pdisc, PfinePrint = LstProd[i].PfinePrint, Pname = LstProd[i].Pname, Ppic = LstProd[i].Ppic, Pquantity = LstProd[i].Pquantity, Price = LstProd[i].Price, Cid = LstProd[i].Cid, Pid = LstProd[i].Pid, EndDate = LstProd[i].EndDate };
                    Electronics.Add(p2);


                }
                else if (LstProd[i].Cid == 3)
                {
                    if (Furniture.Count > 3)
                        continue;
                    ProdList p3 = new ProdList() { Pdisc = LstProd[i].Pdisc, PfinePrint = LstProd[i].PfinePrint, Pname = LstProd[i].Pname, Ppic = LstProd[i].Ppic, Pquantity = LstProd[i].Pquantity, Price = LstProd[i].Price, Cid = LstProd[i].Cid, Pid = LstProd[i].Pid, EndDate = LstProd[i].EndDate };
                    Furniture.Add(p3);
                }

            }

            DataList1.DataSource = hotels;
            DataList1.DataBind();
            DataList2.DataSource = Electronics;
            DataList2.DataBind();
            DataList3.DataSource = Furniture;
            DataList3.DataBind();

            

        }
    }
}