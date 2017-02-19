using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warpgate.Item
{
    public class Commodity : IStorable
    {
        #region public properties

        public string Name { get; set; }
        public int Cost { get; set; }
        public int Size { get; set; }

        #endregion

    }
}
