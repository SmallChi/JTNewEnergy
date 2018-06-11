using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace GBNewEnergy.Protocol.NEEncrypts
{
#if NETSTANDARD2_0
    public class Default_NERSAEncryptImpl : NERSABase
    {
        private readonly RSA _privateKeyRsaProvider;
        private readonly RSA _publicKeyRsaProvider;
        private readonly Encoding _encoding;

        public override string HashAlgorithmStr=>throw new NotImplementedException();

        public override string PublicKey { get; }

        public override string PrivateKey { get; }

        public override HashAlgorithmName HashAlgorithmName { get; }

        public Default_NERSAEncryptImpl(Encoding encoding, HashAlgorithmName hashAlgorithmName, string publicKey, string privateKey)
        {
            _privateKeyRsaProvider = CreateRsaProviderFromPrivateKey(privateKey); 
            _publicKeyRsaProvider = CreateRsaProviderFromPublicKey(publicKey); 
            HashAlgorithmName = hashAlgorithmName;
            _encoding = encoding;
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public override byte[] Decrypt(byte[] buffer)
        {
             return _privateKeyRsaProvider.Decrypt(buffer, RSAEncryptionPadding.Pkcs1);
        }

        public override byte[] Encrypt(byte[] buffer)
        {
             return _publicKeyRsaProvider.Encrypt(buffer, RSAEncryptionPadding.Pkcs1);
        }

        /// <summary>
        /// 使用私钥签名
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns></returns>
        public override string Sign(string data)
        {
            byte[] dataBytes = _encoding.GetBytes(data);
            var signatureBytes = _privateKeyRsaProvider.SignData(dataBytes, HashAlgorithmName, RSASignaturePadding.Pkcs1);
            return Convert.ToBase64String(signatureBytes);
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
            var verify = _publicKeyRsaProvider.VerifyData(dataBytes, signBytes, HashAlgorithmName, RSASignaturePadding.Pkcs1);
            return verify;
        }

        private RSA CreateRsaProviderFromPublicKey(string publicKeyString)
        {
            var rsa = RSA.Create();
            FromXmlStringExtensions(rsa,publicKeyString);
            return rsa;
        }

        private RSA CreateRsaProviderFromPrivateKey(string privateKey)
        {
            var rsa = RSA.Create();
            FromXmlStringExtensions(rsa, privateKey);
            return rsa;
        }

        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();
            else
            if (bt == 0x82)
            {
                var highbyte = binr.ReadByte();
                var lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }

        private bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

        private static void FromXmlStringExtensions(RSA rsa, string xmlString)
        { 
            var parameters = new RSAParameters();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);
            if (xmlDoc.DocumentElement.Name.Equals("RSAKeyValue"))
            {
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "Modulus":
                            parameters.Modulus = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "Exponent":
                            parameters.Exponent = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "P":
                            parameters.P = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "Q":
                            parameters.Q = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "DP":
                            parameters.DP = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "DQ":
                            parameters.DQ = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "InverseQ":
                            parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                        case "D":
                            parameters.D = (string.IsNullOrEmpty(node.InnerText)
                                ? null
                                : Convert.FromBase64String(node.InnerText));
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid XML RSA key.");
            }
            rsa.ImportParameters(parameters);
        }
    }
#endif
}
