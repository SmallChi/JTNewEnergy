using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x04_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x04_Platform jTNE_0X04_Platform = new JTNE_0x04_Platform();
            jTNE_0X04_Platform.LogoutTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X04_Platform.LogoutNum = 4444;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X04_Platform).ToHexString();
            Assert.Equal("130116173738115C", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "130116173738115C".ToHexBytes();
            JTNE_0x04_Platform jTNE_0X04_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x04_Platform>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X04_Platform.LogoutTime);
            Assert.Equal(4444, jTNE_0X04_Platform.LogoutNum);
        }
    }
}
