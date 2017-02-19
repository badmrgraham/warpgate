using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warpgate.Location
{
    public class Hub : Location
    {
        #region public properties

        public List<Location> Locations { get; set; }

        #endregion
    }
}
