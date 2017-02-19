using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Warpgate.Location;

namespace Warpgate.Universe
{
    [XmlInclude(typeof(Planet))]
    [XmlInclude(typeof(SpaceStation))]
    public abstract class Station
    {
        private Faction mFaction = Faction.Neutral;
        public string Name { get; set; }
        public Hub Hub { get; set; }
        public Faction Faction
        {
            get { return mFaction; }
            set { mFaction = value; }
        }
    }
}
