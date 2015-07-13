using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesAnalysis.Models
{
    public class SalesFilter
    {
        public int ManagerId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime  DateTo { get; set; }

    }
}