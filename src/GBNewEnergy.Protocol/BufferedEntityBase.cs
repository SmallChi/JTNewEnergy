using System;
using System.IO;

namespace GBNewEnergy.Protocol
{
    public abstract class BufferedEntityBase : IBuffer, IBuffered
    {
        public byte[] Buffer { get; protected set; }

        protected BufferedEntityBase(byte[] buffer)
        {
            Buffer = buffer;
        }

        protected BufferedEntityBase(params object[] parameter)
        {
            
        }

        public byte[] ToBuffer()
        {
            throw new NotImplementedException();
        }
    }
}
