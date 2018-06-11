using GBNewEnergy.Protocol.Extensions;
using GBNewEnergy.Protocol.NEEncrypts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEEncryptsNET45.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Default_NEAES128EncryptImpl nE_AES128EncryptImpl = new Default_NEAES128EncryptImpl("smallchi");
            string str = "aaasssddd123";
            var bytes = Encoding.UTF8.GetBytes(str);
            var encrypt = nE_AES128EncryptImpl.Encrypt(bytes);
            Console.WriteLine("原数据:" + str);
            Console.WriteLine("加密后:" + encrypt.ToHexString());
            Console.WriteLine("解密后:" + Encoding.UTF8.GetString(nE_AES128EncryptImpl.Decrypt(encrypt)));

            Default_NERSAEncryptImpl_NET rsa = new Default_NERSAEncryptImpl_NET(Encoding.UTF8,
                  "SHA256",
                  "<RSAKeyValue><Modulus>s+rl5mtcckCF9mEECD86L9UE2pbCR4CuiqDepwpiZCEflymQLNC3qNUPDlua9/kltyu6L489uimHRbEp4C7Gl7dDmaXVZLUVGkgUCZoRc8MrOw4+BiVAeQtCDdilPpA7DMN0bMfJAj3U4GuTU89/OWZMb9SYFfqEHM2e60PZHIU=</Modulus><Exponent>AQAB</Exponent><P>8qSTX42w2NaMCXL0PTZuacUFdJj93KopOJPD2q/JfmXSjXHV/IQK9YlCVKXHucqy8xcQgjkaKHqy3Rse14SZ7Q==</P><Q>vdJfDZ6ZIAQDx0sQbmbadHb6EOr8/oXo8B1CUSG0LqFZgDY7vBj17ujd6UhJWzhsg/5/3L+m4wDjMkUpOExZ+Q==</Q><DP>Av3Uc1Ej5QiAIX2xVS/enJ85Of7I4neWmoP33jJcoZpPxj6pDLv0BqLylmiU1c2R9z1JjtF1aRpaKi+zaaTQ4Q==</DP><DQ>Pv5yhv2MCYDrlBbIJCtD8gSN5lFllj3wWMcM/Am4VwU6w368Aicybo+fHUzc80XdVUx/OE3t30WrIEKtdD56WQ==</DQ><InverseQ>OcUQg0/kEGi9l2CgXCLKmQ1/1VVb+r89LXTO6rqi2wg5txkJIIXXePx7ce0Bh0eEnZzeSudwBLA3kqXmeAyYaw==</InverseQ><D>mnPL+zwtd7OmjTUJ5h6JUCi56wFDNWjl7gJeQd4rSzQYT4eRyrc/A4QsUbIYXkqXsyCpzExWvGsMQqrtfRQKzR53MBL3MQln5BjAUql2NqCkM2KT/D8Px5M21/TpMAycK4tGLOHgcCQRH1PQLHG1OfpfDASIzLwLgMjvMuHnIyE=</D></RSAKeyValue>",
                  "<RSAKeyValue><Modulus>s+rl5mtcckCF9mEECD86L9UE2pbCR4CuiqDepwpiZCEflymQLNC3qNUPDlua9/kltyu6L489uimHRbEp4C7Gl7dDmaXVZLUVGkgUCZoRc8MrOw4+BiVAeQtCDdilPpA7DMN0bMfJAj3U4GuTU89/OWZMb9SYFfqEHM2e60PZHIU=</Modulus><Exponent>AQAB</Exponent><P>8qSTX42w2NaMCXL0PTZuacUFdJj93KopOJPD2q/JfmXSjXHV/IQK9YlCVKXHucqy8xcQgjkaKHqy3Rse14SZ7Q==</P><Q>vdJfDZ6ZIAQDx0sQbmbadHb6EOr8/oXo8B1CUSG0LqFZgDY7vBj17ujd6UhJWzhsg/5/3L+m4wDjMkUpOExZ+Q==</Q><DP>Av3Uc1Ej5QiAIX2xVS/enJ85Of7I4neWmoP33jJcoZpPxj6pDLv0BqLylmiU1c2R9z1JjtF1aRpaKi+zaaTQ4Q==</DP><DQ>Pv5yhv2MCYDrlBbIJCtD8gSN5lFllj3wWMcM/Am4VwU6w368Aicybo+fHUzc80XdVUx/OE3t30WrIEKtdD56WQ==</DQ><InverseQ>OcUQg0/kEGi9l2CgXCLKmQ1/1VVb+r89LXTO6rqi2wg5txkJIIXXePx7ce0Bh0eEnZzeSudwBLA3kqXmeAyYaw==</InverseQ><D>mnPL+zwtd7OmjTUJ5h6JUCi56wFDNWjl7gJeQd4rSzQYT4eRyrc/A4QsUbIYXkqXsyCpzExWvGsMQqrtfRQKzR53MBL3MQln5BjAUql2NqCkM2KT/D8Px5M21/TpMAycK4tGLOHgcCQRH1PQLHG1OfpfDASIzLwLgMjvMuHnIyE=</D></RSAKeyValue>"
                  );

            Console.WriteLine("原始字符串：" + str);
            //加密
            byte[] enBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(str));
            Console.WriteLine("加密字符串：" + enBytes.ToHexString());
            //解密
            byte[] deBytes = rsa.Decrypt(enBytes);
            Console.WriteLine("解密字符串：" + Encoding.UTF8.GetString(deBytes));
            //私钥签名
            string signStr = rsa.Sign(str);
            Console.WriteLine("字符串签名：" + signStr);
            //公钥验证签名
            bool signVerify = rsa.Verify(str, signStr);
            Console.WriteLine("验证签名：" + signVerify);
            Console.ReadKey();
        }
    }
}
