using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Warpgate.Universe
{
    public class Sector
    {
        private List<SolarSystem> mSystems = new List<SolarSystem>();

        public string Name { get; set; }
        [XmlIgnore]
        public Faction Faction
        {
            get
            {
                var firstSystem = Systems.FirstOrDefault();
                if (firstSystem != null)
                {
                    var firstFaction = firstSystem.Faction;
                    return Systems.All(station => station.Faction == firstFaction) ? firstFaction : Faction.Contested;
                }
                else
                {
                    return Faction.Neutral;
                }
            }
        }
        public List<SolarSystem> Systems
        {
            get { return mSystems; }
            set { mSystems = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}]", Name, Faction.ToString());
        }
    }
}
