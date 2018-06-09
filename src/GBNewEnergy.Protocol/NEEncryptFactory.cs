using GBNewEnergy.Protocol.Enums;
using GBNewEnergy.Protocol.NEEncrypts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    internal class NEEncryptFactory
    {
        internal static INEEncrypt GetNEEncrypt(NEEncryptMethod nEEncryptMethod)
        {
            switch (nEEncryptMethod)
            {
                case NEEncryptMethod.None:
                case NEEncryptMethod.Invalid:
                case NEEncryptMethod.Exception:
                    return null;
                case NEEncryptMethod.AES128:
                    return new NE_AES128EncryptImpl();
                case NEEncryptMethod.RSA:
                    return new NE_RSAEncryptImpl();
                default:
                    return null;
            }
        }
    }
}
