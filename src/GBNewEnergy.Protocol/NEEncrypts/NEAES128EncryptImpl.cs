using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public class NEAES128EncryptImpl : INEEncrypt
    {
        private readonly NEGlobalConfigs _nEConfigs;

        /// <summary>
        /// 盐字节必须为至少8个字节
        /// </summary>
        private readonly static byte[] saltBytes = new byte[9] { 13, 34, 27, 67, 189, 255, 104, 219, 122 };

        public NEAES128EncryptImpl(NEGlobalConfigs nEConfigs)
        {
            _nEConfigs = nEConfigs;
        }

        public byte[] Encrypt(byte[] buffer)
        {
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_nEConfigs.NEEncryptKey, saltBytes);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),CryptoStreamMode.Write))
                { 
                    cs.Write(buffer, 0, buffer.Length);
                    cs.Close();
                    return ms.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] buffer)
        {
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_nEConfigs.NEEncryptKey, saltBytes);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),CryptoStreamMode.Write))
                { 
                    cs.Write(buffer, 0, buffer.Length);
                    cs.Close(); 
                    return ms.ToArray();
                }
            }
        }
    }
}
