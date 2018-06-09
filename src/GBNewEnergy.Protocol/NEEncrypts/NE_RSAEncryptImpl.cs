using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
#warning 待加解密
    public class NE_RSAEncryptImpl : INEEncrypt
    {
        private readonly NEGlobalConfigs _nEConfigs;

        public NE_RSAEncryptImpl(NEGlobalConfigs nEConfigs)
        {
            _nEConfigs = nEConfigs;
        }

        public byte[] Eecrypt(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}
