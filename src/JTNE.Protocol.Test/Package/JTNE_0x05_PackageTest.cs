using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x05_PackageTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage.MsgId = JTNEMsgId.platformlogin.ToByteValue();
            jTNEPackage.VIN = "123456789";
            JTNE_0x05 jTNE_0X05 = new JTNE_0x05();
            jTNE_0X05.LoginTime = DateTime.Parse("2019-01-23 23:55:56");
            jTNE_0X05.LoginNum = 6666;
            jTNE_0X05.PlatformUserName = "SmallChi518";
            jTNE_0X05.PlatformPassword = "1234567890123456789";
            jTNEPackage.Bodies = jTNE_0X05;
            var hex = JTNESerializer.Serialize(jTNEPackage).ToHexString();
            Assert.Equal("232305FE31323334353637383900000000000000000100291301171737381A0A536D616C6C43686935313800313233343536373839303132333435363738390001FF", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232305FE31323334353637383900000000000000000100291301171737381A0A536D616C6C43686935313800313233343536373839303132333435363738390001FF".ToHexBytes();
            JTNEPackage jTNEPackage = JTNESerializer.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage.AskId);
            Assert.Equal(JTNEMsgId.platformlogin.ToByteValue(), jTNEPackage.MsgId);
            Assert.Equal("123456789", jTNEPackage.VIN);
            JTNE_0x05 jTNE_0X05 = jTNEPackage.Bodies as JTNE_0x05;
            Assert.Equal(DateTime.Parse("2019-01-23 23:55:56"), jTNE_0X05.LoginTime);
            Assert.Equal(6666, jTNE_0X05.LoginNum);
            Assert.Equal("SmallChi518", jTNE_0X05.PlatformUserName);
            Assert.Equal("1234567890123456789", jTNE_0X05.PlatformPassword);
            Assert.Equal(0x01, jTNE_0X05.EncryptMethod);
        }
    }
}
