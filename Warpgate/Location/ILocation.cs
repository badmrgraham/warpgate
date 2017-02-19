using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warpgate.Location
{
    public interface ILocation
    {
        Hub StationHub { get; set; }
    }
}
