using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public class NE_AES128EncryptImpl : INEEncrypt
    {
        private readonly NEGlobalConfigs _nEConfigs;

        /// <summary>
        /// 盐字节必须为至少8个字节
        /// </summary>
        private readonly static byte[] saltBytes = new byte[9] { 13, 34, 27, 67, 189, 255, 104, 219, 122 };

        public NE_AES128EncryptImpl(NEGlobalConfigs nEConfigs)
        {
            _nEConfigs = nEConfigs;
        }

        public byte[] Encrypt(byte[] buffer)
        {
            byte[] decryptedBytes = null;      
            using (var ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(_nEConfigs.NEEncryptKeyBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(32);
                    AES.IV = key.GetBytes(16);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(buffer, 0, buffer.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        public byte[] Eecrypt(byte[] buffer)
        {
            byte[] decryptedBytes = null;
            using (var ms = new MemoryStream())
            {
                using (var AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(_nEConfigs.NEEncryptKeyBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(32);
                    AES.IV = key.GetBytes(16);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(buffer, 0, buffer.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }
    }
}
