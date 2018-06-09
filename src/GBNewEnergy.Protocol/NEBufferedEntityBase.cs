using System;
using System.IO;

namespace GBNewEnergy.Protocol
{
    public abstract class NEBufferedEntityBase
    {
        public byte[] Buffer { get; protected set; }

        public NEGlobalConfigs NEConfigs { get;}

        protected NEBufferedEntityBase(byte[] buffer, NEGlobalConfigs nEConfigs)
        {
            NEConfigs = nEConfigs;
            Buffer = buffer;
            InitializePropertiesFromBuffer();
        }

        protected NEBufferedEntityBase(byte[] headerBuffer, byte[] bodyBuffer, NEGlobalConfigs nEConfigs)
        {
            NEConfigs = nEConfigs;
            Buffer = new byte[headerBuffer.Length + bodyBuffer.Length];
            Array.Copy(headerBuffer, 0, Buffer, 0, headerBuffer.Length);
            Array.Copy(bodyBuffer, 0, Buffer, headerBuffer.Length, bodyBuffer.Length);
            InitializePropertiesFromBuffer();
        }

        protected NEBufferedEntityBase(INEProperties nEProperties,NEGlobalConfigs nEConfigs)
        {
            NEConfigs = nEConfigs;
            InitializeProperties(nEProperties);
            ToBuffer();
        }

        protected abstract void InitializeProperties(INEProperties nEProperties);

        protected abstract void ToBuffer();

        protected abstract void InitializePropertiesFromBuffer();
    }
}
