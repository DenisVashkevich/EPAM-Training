using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10UniDemo.Helpers
{
    public static class FillCollection
    {
        public static List<Models.Movie> GetItems(int itemsNumber)
        {
            List<Models.Movie> movList = new List<Models.Movie>();
            Random rnd = new Random();
            for (int i = 0; i < itemsNumber; i++) 
            {
                movList.Add(new Models.Movie
                {
                    DateCreated = new DateTime(2015, rnd.Next(1, 12), rnd.Next(1, 25)),
                    Duration = new TimeSpan(rnd.Next(1, 2), rnd.Next(1, 59), rnd.Next(1, 59)),
                    Name = "Movie_" + i.ToString(),
                    ProductionStudio = new Models.FilmProductionStudio { Name = "Studio_" + rnd.Next(1, itemsNumber).ToString() }
                });
            }
            return movList;
        }

        
    }
}
