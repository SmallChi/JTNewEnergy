using System.IO;
using System.Security.Cryptography;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public class Default_NEAES128EncryptImpl : NEAESBase
    {
        public override string PrivateKey { get; }

        public override byte[] SaltBytes { get; }

        public Default_NEAES128EncryptImpl(string privateKey)
        {
            PrivateKey = privateKey;
            SaltBytes = new byte[9] { 13, 34, 27, 67, 189, 255, 104, 219, 122 };
        }

        public Default_NEAES128EncryptImpl(string privateKey, byte[] saltBytes)
        {
            PrivateKey = privateKey;
            SaltBytes = saltBytes;
        }

        public override byte[] Encrypt(byte[] buffer)
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

        public override byte[] Decrypt(byte[] buffer)
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
