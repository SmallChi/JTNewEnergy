using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties
{
    public class NELoginProperty : INEProperties
    {
        public string VIN { get; set; }

        public string SIM { get; set; }

        public byte BatteryCount { get; set; }

        public byte BatteryLength { get; set; }

        public IEnumerable<string> BatteryNos { get; set;}
    }
}
