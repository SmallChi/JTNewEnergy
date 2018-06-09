using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.NEEncrypts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    internal class NEEncryptFactory
    {
        internal static INEEncrypt GetNEEncrypt(NEEncryptMethod nEEncryptMethod, NEGlobalConfigs nEConfigs)
        {
            switch (nEEncryptMethod)
            {
                case NEEncryptMethod.None:
                case NEEncryptMethod.Invalid:
                case NEEncryptMethod.Exception:
                    return null;
                case NEEncryptMethod.AES128:
#if NETCOREAPP2_1
                return new NE_AES128EncryptImpl_NetCore2(nEConfigs);
#else
                return new NE_AES128EncryptImpl(nEConfigs);
#endif
                case NEEncryptMethod.RSA:
                    return new NE_RSAEncryptImpl(nEConfigs);
                default:
                    return null;
            }
        }
    }
}
