using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x06_PackageTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = JTNEAskId.CMD.ToByteValue();
            jTNEPackage.MsgId = JTNEMsgId.platformlogout.ToByteValue();
            jTNEPackage.VIN = "123456789";
            JTNE_0x06 jTNE_0X06 = new JTNE_0x06();
            jTNE_0X06.LogoutTime = DateTime.Parse("2019-01-23 23:55:56");
            jTNE_0X06.LogoutNum = 1;
            jTNEPackage.Bodies = jTNE_0X06;
            var hex = JTNESerializer.Serialize(jTNEPackage).ToHexString();
            Assert.Equal("232306FE31323334353637383900000000000000000100081301171737380001DC", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "232306FE31323334353637383900000000000000000100081301171737380001DC".ToHexBytes();
            JTNEPackage jTNEPackage = JTNESerializer.Deserialize(data);
            Assert.Equal(JTNEAskId.CMD.ToByteValue(), jTNEPackage.AskId);
            Assert.Equal(JTNEMsgId.platformlogout.ToByteValue(), jTNEPackage.MsgId);
            Assert.Equal("123456789", jTNEPackage.VIN);
            JTNE_0x06 jTNE_0X06 = jTNEPackage.Bodies as JTNE_0x06;
            Assert.Equal(DateTime.Parse("2019-01-23 23:55:56"), jTNE_0X06.LogoutTime);
            Assert.Equal(1, jTNE_0X06.LogoutNum);
        }
    }
}
