using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Sales
    {
        public DateTime Date { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Client ClientId { get; set; }
        public double Cost { get; set; }
    }
}
