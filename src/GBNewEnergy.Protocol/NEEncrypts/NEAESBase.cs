using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public abstract class NEAESBase : INEEncrypt
    {
        public abstract string PrivateKey { get; }
        public abstract byte[] SaltBytes { get; }
        public abstract byte[] Decrypt(byte[] buffer);
        public abstract byte[] Encrypt(byte[] buffer);
    }
}
