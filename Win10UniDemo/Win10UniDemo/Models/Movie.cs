using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10UniDemo.Models
{
    public class Movie : IMovieItem
    {
        public DateTime DateCreated { get; set; }
        public TimeSpan Duration { get; set; }
        public string Name { get; set; }
        public FilmProductionStudio ProductionStudio { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
