using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sales
    {
        public DateTime Date { get; set; }
        public Manager Manager { get; set; }
        public Client Client { get; set; }
        public Goods Goodds { get; set; } 
        public double Cost { get; set; }
    }
}
