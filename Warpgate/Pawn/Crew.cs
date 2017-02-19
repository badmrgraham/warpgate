using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Warpgate.Pawn
{
    public class Crew
    {
        #region public properties

        public string Name { get; set; }
        public int Cost { get; set; }
        public float Payment { get; set; }
        public Faction Faction { get; set; }

        #endregion
    }
}
