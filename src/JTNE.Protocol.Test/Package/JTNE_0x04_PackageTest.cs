using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x04_PackageTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage.MsgId = JTNEMsgId.loginout.ToByteValue();
            jTNEPackage.VIN = "123456789";
            JTNE_0x04 jTNE_0X04 = new JTNE_0x04();
            jTNE_0X04.LogoutTime = DateTime.Parse("2019-01-23 23:55:56");
            jTNE_0X04.LogoutNum = 1;
            jTNEPackage.Bodies = jTNE_0X04;
            var hex = JTNESerializer.Serialize(jTNEPackage).ToHexString();
            Assert.Equal("232304FE31323334353637383900000000000000000100081301171737380001DE", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232304FE31323334353637383900000000000000000100081301171737380001DE".ToHexBytes();
            JTNEPackage jTNEPackage = JTNESerializer.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage.AskId);
            Assert.Equal(JTNEMsgId.loginout.ToByteValue(), jTNEPackage.MsgId);
            Assert.Equal("123456789", jTNEPackage.VIN);
            JTNE_0x04 jTNE_0X04 = jTNEPackage.Bodies as JTNE_0x04;
            Assert.Equal(DateTime.Parse("2019-01-23 23:55:56"), jTNE_0X04.LogoutTime);
            Assert.Equal(1, jTNE_0X04.LogoutNum);
        }
    }
}
