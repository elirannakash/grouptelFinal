using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupTelFV
{
    public class ProdList
    {
        public int Pid { get; set; }
        public int Cid { get; set; }
        public string Price { get; internal set; }
        public string Pname { get; set; }
        public string Ppic { get; set; }
        public string Pdisc { get; set; }
        public int Pquantity { get; set; }
        public string PfinePrint { get; set; }
        public string menuCat { get; set; }
        public string EndDate { get; set; }
        public int Pquantity2 { get; set; }
    }
}