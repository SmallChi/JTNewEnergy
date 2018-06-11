using GBNewEnergy.Protocol.NEEncrypts;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Text;
using System.Security.Cryptography;

namespace NEEncryptsNETCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Default_NEAES128EncryptImpl nE_AES128EncryptImpl = new Default_NEAES128EncryptImpl("smallchi");
            string str = "aaaaaa111111";
            //var bytes = Encoding.UTF8.GetBytes(str);
            //var encrypt = nE_AES128EncryptImpl.Encrypt(bytes);
            //Console.WriteLine("原数据:" + str);
            //Console.WriteLine("加密后:" + encrypt.ToHexString());
            //Console.WriteLine("解密后:" + Encoding.ASCII.GetString(nE_AES128EncryptImpl.Decrypt(encrypt)));

            //NERSAEncryptImpl rsa = new NERSAEncryptImpl(
            // new GBNewEnergy.Protocol.NEGlobalConfigs()
            // {
            //     NEEncryptRSAPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoQh0wEqx/R2H1v00IU12Oc30fosRC/frhH89L6G+fzeaqI19MYQhEPMU13wpeqRONCUta+2iC1sgCNQ9qGGf19yGdZUfueaB1Nu9rdueQKXgVurGHJ+5N71UFm+OP1XcnFUCK4wT5d7ZIifXxuqLehP9Ts6sNjhVfa+yU+VjF5HoIe69OJEPo7OxRZcRTe17khc93Ic+PfyqswQJJlY/bgpcLJQnM+QuHmxNtF7/FpAx9YEQsShsGpVo7JaKgLo+s6AFoJ4QldQKir2vbN9vcKRbG3piElPilWDpjXQkOJZhUloh/jd7QrKFimZFldJ1r6Q59QYUyGKZARUe0KZpMQIDAQAB",
            //     NEEncryptRSAPrivateKey = "MIIEpAIBAAKCAQEAoQh0wEqx/R2H1v00IU12Oc30fosRC/frhH89L6G+fzeaqI19MYQhEPMU13wpeqRONCUta+2iC1sgCNQ9qGGf19yGdZUfueaB1Nu9rdueQKXgVurGHJ+5N71UFm+OP1XcnFUCK4wT5d7ZIifXxuqLehP9Ts6sNjhVfa+yU+VjF5HoIe69OJEPo7OxRZcRTe17khc93Ic+PfyqswQJJlY/bgpcLJQnM+QuHmxNtF7/FpAx9YEQsShsGpVo7JaKgLo+s6AFoJ4QldQKir2vbN9vcKRbG3piElPilWDpjXQkOJZhUloh/jd7QrKFimZFldJ1r6Q59QYUyGKZARUe0KZpMQIDAQABAoIBAQCRZLUlOUvjIVqYvhznRK1OG6p45s8JY1r+UnPIId2Bt46oSLeUkZvZVeCnfq9k0Bzb8AVGwVPhtPEDh73z3dEYcT/lwjLXAkyPB6gG5ZfI/vvC/k7JYV01+neFmktw2/FIJWjEMMF2dvLNZ/Pm4bX1Dz9SfD/45Hwr8wqrvRzvFZsj5qqOxv9RPAudOYwCwZskKp/GF+L+3Ycod1Wu98imzMZUH+L5dQuDGg3kvf3ljIAegTPoqYBg0imNPYY/EGoFKnbxlK5S5/5uAFb16dGJqAz3XQCz9Is/IWrOTu0etteqV2Ncs8uqPdjed+b0j8CMsr4U1xjwPQ8WwdaJtTkRAoGBANAndgiGZkCVcc9975/AYdgFp35W6D+hGQAZlL6DmnucUFdXbWa/x2rTSEXlkvgk9X/PxOptUYsLJkzysTgfDywZwuIXLm9B3oNmv3bVgPXsgDsvDfaHYCgz0nHK6NSrX2AeX3yO/dFuoZsuk+J+UyRigMqYj0wjmxUlqj183hinAoGBAMYMOBgF77OXRII7GAuEut/nBeh2sBrgyzR7FmJMs5kvRh6Ck8wp3ysgMvX4lxh1ep8iCw1R2cguqNATr1klOdsCTOE9RrhuvOp3JrYzuIAK6MpH/uBICy4w1rW2+gQySsHcH40r+tNaTFQ7dQ1tef//iy/IW8v8i0t+csztE1JnAoGABdtWYt8FOYP688+jUmdjWWSvVcq0NjYeMfaGTOX/DsNTL2HyXhW/Uq4nNnBDNmAz2CjMbZwt0y+5ICkj+2REVQVUinAEinTcAe5+LKXNPx4sbX3hcrJUbk0m+rSu4G0B/f5cyXBsi9wFCAzDdHgBduCepxSr04Sc9Hde1uQQi7kCgYB0U20HP0Vh+TG2RLuE2HtjVDD2L/CUeQEiXEHzjxXWnhvTg+MIAnggvpLwQwmMxkQ2ACr5sd/3YuCpB0bxV5o594nsqq9FWVYBaecFEjAGlWHSnqMoXWijwu/6X/VOTbP3VjH6G6ECT4GR4DKKpokIQrMgZ9DzaezvdOA9WesFdQKBgQCWfeOQTitRJ0NZACFUn3Fs3Rvgc9eN9YSWj4RtqkmGPMPvguWo+SKhlk3IbYjrRBc5WVOdoX8JXb2/+nAGhPCuUZckWVmZe5pMSr4EkNQdYeY8kOXGSjoTOUH34ZdKeS+e399BkBWIiXUejX/Srln0H4KoHnTWgxwNpTsBCgXu8Q==",
            //     NERSAType = GBNewEnergy.Protocol.NEGlobalConfigs.RSAType.RSA2
            // });

            Default_NERSAEncryptImpl rsa = new Default_NERSAEncryptImpl(
               Encoding.UTF8,
               HashAlgorithmName.SHA256,
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
