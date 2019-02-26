using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x05_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x05_Platform jTNE_0X05_Platform = new JTNE_0x05_Platform();
            jTNE_0X05_Platform.LoginTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X05_Platform.LoginNum = 6666;
            jTNE_0X05_Platform.PlatformUserName = "SmallChi518";
            jTNE_0X05_Platform.PlatformPassword = "1234567890123456789";
            jTNE_0X05_Platform.EncryptMethod = 0x00;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X05_Platform).ToHexString();
            Assert.Equal("1301161737381A0A536D616C6C43686935313800313233343536373839303132333435363738390000", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "1301161737381A0A536D616C6C43686935313800313233343536373839303132333435363738390000".ToHexBytes();
            JTNE_0x05_Platform jTNE_0X05_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x05_Platform>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X05_Platform.LoginTime);
            Assert.Equal(6666, jTNE_0X05_Platform.LoginNum);
            Assert.Equal("SmallChi518", jTNE_0X05_Platform.PlatformUserName);
            Assert.Equal("1234567890123456789", jTNE_0X05_Platform.PlatformPassword);
            Assert.Equal(0x00, jTNE_0X05_Platform.EncryptMethod);
        }
    }
}
