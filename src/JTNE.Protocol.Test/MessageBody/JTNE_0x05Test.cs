using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x05Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x05 jTNE_0X05 = new JTNE_0x05();
            jTNE_0X05.LoginTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X05.LoginNum = 6666;
            jTNE_0X05.PlatformUserName = "SmallChi518";
            jTNE_0X05.PlatformPassword = "1234567890123456789";
            jTNE_0X05.EncryptMethod = 0x00;
            var hex = JTNESerializer.Serialize(jTNE_0X05).ToHexString();
            Assert.Equal("1301161737381A0A536D616C6C43686935313800313233343536373839303132333435363738390000", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "1301161737381A0A536D616C6C43686935313800313233343536373839303132333435363738390000".ToHexBytes();
            JTNE_0x05 jTNE_0X05 = JTNESerializer.Deserialize<JTNE_0x05>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X05.LoginTime);
            Assert.Equal(6666, jTNE_0X05.LoginNum);
            Assert.Equal("SmallChi518", jTNE_0X05.PlatformUserName);
            Assert.Equal("1234567890123456789", jTNE_0X05.PlatformPassword);
            Assert.Equal(0x00, jTNE_0X05.EncryptMethod);
        }
    }
}
