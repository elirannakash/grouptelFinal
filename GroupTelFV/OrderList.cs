using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupTelFV
{
    public class OrderList
    {
        public int Oid { get; set; }
        public int pid { get; set; }
        public string Email { get; set; }
        public string Pname { get; set; }
        public string Ppic { get; set; }
        public DateTime Odate { get; set; }
    }
}