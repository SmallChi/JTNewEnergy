using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
#warning 待加解密
    public class NERSAEncryptImpl : INEEncrypt
    {
        private readonly NEGlobalConfigs _nEConfigs;

        public NERSAEncryptImpl(NEGlobalConfigs nEConfigs)
        {
            _nEConfigs = nEConfigs;
        }

        public byte[] Decrypt(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
