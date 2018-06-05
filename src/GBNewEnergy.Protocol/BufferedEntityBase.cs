using System;
using System.IO;

namespace GBNewEnergy.Protocol
{
    public abstract class BufferedEntityBase : IBuffer
    {
        public byte[] Buffer { get; protected set; }

        protected BufferedEntityBase(byte[] buffer)
        {
            Buffer = buffer;
        }
    }
}
