using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GBNewEnergy.Protocol.NEEncrypts
{
    public abstract class NERSABase : INEEncrypt
    {
        public abstract byte[] Decrypt(byte[] buffer);
        public abstract byte[] Encrypt(byte[] buffer);

#if NETSTANDARD2_0
        /// <summary>
        /// dotnet core 使用
        /// </summary>
        public abstract HashAlgorithmName HashAlgorithmName { get; }
#endif
        /// <summary>
        /// .net framework 使用
        /// 哈希算法
        /// MD5 new MD5CryptoServiceProvider()
        /// SHA1 new SHA1CryptoServiceProvider()
        /// SHA256 new SHA256CryptoServiceProvider()
        /// SHA384 new SHA384CryptoServiceProvider()
        /// SHA512 new SHA512CryptoServiceProvider()
        /// </summary>
        public abstract string HashAlgorithmStr { get; }
        public abstract string PublicKey { get; }
        public abstract string PrivateKey { get; }
        /// <summary>
        /// 使用私钥签名
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns></returns>
        public abstract bool Verify(string data, string sign);
        /// <summary>
        /// 使用公钥验证签名
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        public abstract string Sign(string data);
    }
}
