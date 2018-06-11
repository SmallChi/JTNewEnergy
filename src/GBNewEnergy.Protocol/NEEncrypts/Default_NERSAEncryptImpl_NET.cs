using System;
using System.Security.Cryptography;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public class Default_NERSAEncryptImpl_NET : NERSABase
    {
        private readonly Encoding _encoding;

        public Default_NERSAEncryptImpl_NET(Encoding encoding,string hashAlgorithmStr, string publicKey, string privateKey)
        {
            _encoding = encoding;
            HashAlgorithmStr = hashAlgorithmStr;
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

#if NETSTANDARD2_0
        public override HashAlgorithmName HashAlgorithmName => throw new NotImplementedException();
#endif
        public override string HashAlgorithmStr { get;}

        public override string PublicKey { get;  }

        public override string PrivateKey { get;}

        public override byte[] Decrypt(byte[] buffer)
        {
            using (RSACryptoServiceProvider provider=new RSACryptoServiceProvider())
            {
                provider.FromXmlString(PrivateKey);
                return provider.Decrypt(buffer, false);
            }
        }

        public override byte[] Encrypt(byte[] buffer)
        {
            using (RSACryptoServiceProvider provider = new RSACryptoServiceProvider())
            {
                provider.FromXmlString(PublicKey);
                return provider.Encrypt(buffer, false);
            }
        }

        /// <summary>
        /// 使用私钥签名
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns></returns>
        public override string Sign(string data)
        {
            byte[] dataBytes = _encoding.GetBytes(data);
            byte[] rgbHash = HashAlgorithm.Create(HashAlgorithmStr).ComputeHash(dataBytes);
            using (RSACryptoServiceProvider key = new RSACryptoServiceProvider())
            {
                key.FromXmlString(PrivateKey);
                RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
                formatter.SetHashAlgorithm(HashAlgorithmStr);
                byte[] inArray = formatter.CreateSignature(rgbHash);
                return Convert.ToBase64String(inArray);
            }
        }

        /// <summary>
        /// 使用公钥验证签名
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        public override bool Verify(string data, string sign)
        {
            byte[] dataBytes = _encoding.GetBytes(data);
            byte[] signBytes = Convert.FromBase64String(sign);
            byte[] rgbHash = HashAlgorithm.Create(HashAlgorithmStr).ComputeHash(dataBytes);
            using (RSACryptoServiceProvider key = new RSACryptoServiceProvider())
            {
                key.FromXmlString(PublicKey);
                RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm(HashAlgorithmStr);
                byte[] rgbSignature = Convert.FromBase64String(sign);
                if (deformatter.VerifySignature(rgbHash, rgbSignature))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
