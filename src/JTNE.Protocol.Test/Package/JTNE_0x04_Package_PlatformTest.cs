using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x04_Package_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Platform jTNEPackage_Platform = new JTNEPackage_Platform();
            jTNEPackage_Platform.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage_Platform.MsgId = JTNEMsgId_Platform.loginout.ToByteValue();
            jTNEPackage_Platform.VIN = "123456789";
            JTNE_0x04_Platform jTNE_0X04_Platform = new JTNE_0x04_Platform();
            jTNE_0X04_Platform.LogoutTime = DateTime.Parse("2019-01-23 23:55:56");
            jTNE_0X04_Platform.LogoutNum = 1;
            jTNEPackage_Platform.Bodies = jTNE_0X04_Platform;
            var hex = JTNESerializer_Platform.Serialize(jTNEPackage_Platform).ToHexString();
            Assert.Equal("232304FE31323334353637383900000000000000000100081301171737380001DE", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232304FE31323334353637383900000000000000000100081301171737380001DE".ToHexBytes();
            JTNEPackage_Platform jTNEPackage_Platform = JTNESerializer_Platform.Deserialize<JTNEPackage_Platform>(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage_Platform.AskId);
            Assert.Equal(JTNEMsgId_Platform.loginout.ToByteValue(), jTNEPackage_Platform.MsgId);
            Assert.Equal("123456789", jTNEPackage_Platform.VIN);
            JTNE_0x04_Platform jTNE_0X04_Platform = jTNEPackage_Platform.Bodies as JTNE_0x04_Platform;
            Assert.Equal(DateTime.Parse("2019-01-23 23:55:56"), jTNE_0X04_Platform.LogoutTime);
            Assert.Equal(1, jTNE_0X04_Platform.LogoutNum);
        }
    }
}
