using System;
using System.IO;

namespace GBNewEnergy.Protocol
{
    public abstract class BufferedEntityBase : IBuffered, IBuffer
    {
        public byte[] Buffer { get; protected set; }

        public virtual byte[] ToBuffer()
        {
            return Buffer;
        }

        protected BufferedEntityBase(byte[] buffer)
        {
            Buffer = buffer;
        }
    }
}
