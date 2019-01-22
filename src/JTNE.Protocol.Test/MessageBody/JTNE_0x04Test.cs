using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x04Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x04 jTNE_0X04 = new JTNE_0x04();
            jTNE_0X04.LogoutTime = DateTime.Parse("2019-01-22 23:55:56");
            jTNE_0X04.LogoutNum = 4444;
            var hex = JTNESerializer.Serialize(jTNE_0X04).ToHexString();
            Assert.Equal("190122235556115C", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "190122235556115C".ToHexBytes();
            JTNE_0x04 jTNE_0X04 = JTNESerializer.Deserialize<JTNE_0x04>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0X04.LogoutTime);
            Assert.Equal(4444, jTNE_0X04.LogoutNum);
        }
    }
}
