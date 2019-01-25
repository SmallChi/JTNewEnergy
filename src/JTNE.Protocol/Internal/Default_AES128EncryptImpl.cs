using JTNE.Protocol.Interfaces;
using System.IO;
using System.Security.Cryptography;

namespace JTNE.Protocol.Internal
{
    public class Default_AES128EncryptImpl : IJTNEEncrypt
    {
        public string PrivateKey => "test";

        public byte[] SaltBytes => new byte[9] { 13, 34, 27, 67, 189, 255, 104, 219, 122 };

        public byte[] Encrypt(byte[] buffer)
        {
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(PrivateKey, SaltBytes);
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
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(PrivateKey, SaltBytes);
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
