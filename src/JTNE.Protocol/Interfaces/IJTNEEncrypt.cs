using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.Interfaces
{
    public interface IJTNEEncrypt
    {
        byte[] Encrypt(byte[] buffer);
        byte[] Decrypt(byte[] buffer);
    }
}
