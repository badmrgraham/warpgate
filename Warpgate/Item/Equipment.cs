using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warpgate.Item
{
    public class Equipment : IEquipable
    {
        #region public properties

        public string Name { get; set; }
        public int Cost { get; set; }

        #endregion

    }
}
