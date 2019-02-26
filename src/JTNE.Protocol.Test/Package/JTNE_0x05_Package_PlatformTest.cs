using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x05_Package_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Platform jTNEPackage_Platform = new JTNEPackage_Platform();
            jTNEPackage_Platform.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage_Platform.MsgId = JTNEMsgId_Platform.platformlogin.ToByteValue();
            jTNEPackage_Platform.VIN = "123456789";
            JTNE_0x05_Platform jTNE_0X05_Platform = new JTNE_0x05_Platform();
            jTNE_0X05_Platform.LoginTime = DateTime.Parse("2019-01-23 23:55:56");
            jTNE_0X05_Platform.LoginNum = 6666;
            jTNE_0X05_Platform.PlatformUserName = "SmallChi518";
            jTNE_0X05_Platform.PlatformPassword = "1234567890123456789";
            jTNEPackage_Platform.Bodies = jTNE_0X05_Platform;
            var hex = JTNESerializer_Platform.Serialize(jTNEPackage_Platform).ToHexString();
            Assert.Equal("232305FE31323334353637383900000000000000000100291301171737381A0A536D616C6C43686935313800313233343536373839303132333435363738390001FF", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232305FE31323334353637383900000000000000000100291301171737381A0A536D616C6C43686935313800313233343536373839303132333435363738390001FF".ToHexBytes();
            JTNEPackage_Platform jTNEPackage_Platform = JTNESerializer_Platform.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage_Platform.AskId);
            Assert.Equal(JTNEMsgId_Platform.platformlogin.ToByteValue(), jTNEPackage_Platform.MsgId);
            Assert.Equal("123456789", jTNEPackage_Platform.VIN);
            JTNE_0x05_Platform jTNE_0X05_Platform = jTNEPackage_Platform.Bodies as JTNE_0x05_Platform;
            Assert.Equal(DateTime.Parse("2019-01-23 23:55:56"), jTNE_0X05_Platform.LoginTime);
            Assert.Equal(6666, jTNE_0X05_Platform.LoginNum);
            Assert.Equal("SmallChi518", jTNE_0X05_Platform.PlatformUserName);
            Assert.Equal("1234567890123456789", jTNE_0X05_Platform.PlatformPassword);
            Assert.Equal(0x01, jTNE_0X05_Platform.EncryptMethod);
        }
    }
}
