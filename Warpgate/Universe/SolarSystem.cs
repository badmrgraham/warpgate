using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Warpgate.Universe
{
    public class SolarSystem
    {
        private List<Station> mStations = new List<Station>();

        public string Name { get; set; }
        [XmlIgnore]
        public Faction Faction 
        { 
            get
            {
                var firstStation = Stations.FirstOrDefault();
                if (firstStation != null)
                {
                    var firstFaction = firstStation.Faction;
                    return Stations.All(station => station.Faction == firstFaction) ? firstFaction : Faction.Contested;
                }
                else
                {
                    return Faction.Neutral;
                }
            }
        }
        public List<Station> Stations
        {
            get { return mStations; }
            set { mStations = value; }
        }
    }
}
