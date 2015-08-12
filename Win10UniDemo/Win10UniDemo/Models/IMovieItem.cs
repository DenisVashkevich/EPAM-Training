using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10UniDemo.Models
{
    public interface IMovieItem : IMediaItem
    {
        FilmProductionStudio ProductionStudio { get; set; }
        TimeSpan Duration { get; set; }
    }
}
