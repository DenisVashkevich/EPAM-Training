using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsWarehouse
{
    public interface IPart
    {
        string PartNumber { get; }
        string Name { get; }
        string Description { get; }
        int Stock { get; }
    }
}
