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
                    return new NEAES128EncryptImpl(nEConfigs);
                case NEEncryptMethod.RSA:
                    return new NERSAEncryptImpl(nEConfigs);
                default:
                    return null;
            }
        }
    }
}
