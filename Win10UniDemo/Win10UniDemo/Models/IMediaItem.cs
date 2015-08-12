using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10UniDemo.Models
{
    public interface IMediaItem
    {
        string Name { get; set; }
        DateTime DateCreated { get; set; }
    }
}
