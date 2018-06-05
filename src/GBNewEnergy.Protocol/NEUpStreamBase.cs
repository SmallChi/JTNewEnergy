using GBNewEnergy.Protocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    public abstract class NEUpStreamBase: IBuffered, IBuffer
    {
        public DateTime Utc{ get; set; }
        public byte[] Buffer { get;protected set; }
        public abstract void ToBuffer();
    }
}
