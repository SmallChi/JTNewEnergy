using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEProperties
{
    public class NEPackageProperty : INEProperties
    {
        public string VIN { get; set; }
        public NEMsgId MsgId { get; set; }
        public NEAskId AskId { get; set; }
        public NEBodies Bodies { get; set; }
    }
}
