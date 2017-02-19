using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warpgate.Item
{
    public class Ship
    {
        #region public properties

        public string Name { get; set; }
        public int Seats { get; set; }
        public int Hardpoints { get; set; }
        public int Speed { get; set; }
        public int Armor { get; set; }
        public int Maneuverability { get; set; }
        public int Cost { get; set; }

        #endregion
    }
}
