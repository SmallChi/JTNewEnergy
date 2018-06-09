using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol
{
    public interface INEEncrypt
    {
        byte[] Encrypt(byte[] buffer);
        byte[] Eecrypt(byte[] buffer);
    }
}
