using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Warpgate.Item;
using Warpgate.Panels;
using Warpgate.Pawn;
using Warpgate.Universe;

namespace Warpgate.Player
{
    public class State
    {
        public Captain Captain { get; set; }
        public Ship Ship { get; set; }
        public List<Equipment> Equipment { get; set; }
        public Location.Location Location { get; set; }
        public List<Commodity> Commodities { get; set; }
        public int Money { get; set; }
        public List<IPanel> Panels { get; set; }
    }
}