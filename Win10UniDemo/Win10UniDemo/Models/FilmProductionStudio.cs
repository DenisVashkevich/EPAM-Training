using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10UniDemo.Models
{
    public class FilmProductionStudio : IProductionStudio
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
