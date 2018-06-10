using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public class NEAES128EncryptImpl_NetCore2 : INEEncrypt
    {
        private readonly NEGlobalConfigs _nEConfigs;

        /// <summary>
        /// 盐字节必须为至少8个字节
        /// </summary>
        private readonly static byte[] saltBytes = new byte[9] { 13, 34, 27, 67, 189, 255, 104, 219, 122 };

        public NEAES128EncryptImpl_NetCore2(NEGlobalConfigs nEConfigs)
        {
            _nEConfigs = nEConfigs;
        }

        public byte[] Decrypt(byte[] buffer)
        {
            var iv = new byte[16];
            var cipher = new byte[16];
            Buffer.BlockCopy(buffer, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(buffer, iv.Length, cipher, 0, iv.Length);
            using (var aesAlg = Aes.Create())
            using (var decryptor = aesAlg.CreateDecryptor(_nEConfigs.NEEncryptKeyBytes, iv))
            using (var msDecrypt = new MemoryStream(cipher))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                byte[] bytes = new byte[csDecrypt.Length];
                csDecrypt.Read(bytes, 0, bytes.Length);
                // 设置当前流的位置为流的开始 
                csDecrypt.Seek(0, SeekOrigin.Begin);
                return bytes;
            }
        }

        public byte[] Encrypt(byte[] buffer)
        {
            using (var aesAlg = Aes.Create())
            using (var encryptor = aesAlg.CreateEncryptor(_nEConfigs.NEEncryptKeyBytes, aesAlg.IV))
            using (var msEncrypt = new MemoryStream())
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(buffer);
                var iv = aesAlg.IV;
                var decryptedContent = msEncrypt.ToArray();
                var result = new byte[iv.Length + decryptedContent.Length];
                Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);
                return result;
            }
        }
    }
}
