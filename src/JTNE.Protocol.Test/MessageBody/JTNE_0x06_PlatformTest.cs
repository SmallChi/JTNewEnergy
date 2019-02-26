using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x06_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x06_Platform jTNE_0X06_Platform = new JTNE_0x06_Platform();
            jTNE_0X06_Platform.LogoutTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X06_Platform.LogoutNum = 6666;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X06_Platform).ToHexString();
            Assert.Equal("1301161737381A0A", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "1301161737381A0A".ToHexBytes();
            JTNE_0x06_Platform jTNE_0X06_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x06_Platform>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X06_Platform.LogoutTime);
            Assert.Equal(6666, jTNE_0X06_Platform.LogoutNum);
        }
    }
}
