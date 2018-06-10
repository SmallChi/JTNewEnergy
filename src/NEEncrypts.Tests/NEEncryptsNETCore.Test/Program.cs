using GBNewEnergy.Protocol.NEEncrypts;
using GBNewEnergy.Protocol.Extensions;
using System;
using System.Text;

namespace NEEncryptsNETCore.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            NEAES128EncryptImpl nE_AES128EncryptImpl = new NEAES128EncryptImpl(
             new GBNewEnergy.Protocol.NEGlobalConfigs()
             {
                 NEEncryptKey = "smallchi"
             });
            string str =Guid.NewGuid().ToString("N");
            var bytes = Encoding.UTF8.GetBytes(str);
            var encrypt = nE_AES128EncryptImpl.Encrypt(bytes);
            Console.WriteLine("原数据:" + str);
            Console.WriteLine("加密后:" + encrypt.ToHexString());
            Console.WriteLine("解密后:" + Encoding.UTF8.GetString(nE_AES128EncryptImpl.Decrypt(encrypt)));
            Console.ReadKey();
        }
    }
}
