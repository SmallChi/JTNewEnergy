using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x04Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x04 jTNE_0X02_0X04 = new JTNE_0x02_0x04();
            jTNE_0X02_0X04.EngineStatus = 0x01;
            jTNE_0X02_0X04.FuelRate = 102;
            jTNE_0X02_0X04.Revs = 203;
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X04).ToHexString();
            Assert.Equal("040100CB0066", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "040100CB0066".ToHexBytes();
            JTNE_0x02_0x04 jTNE_0X02_0X04 = JTNESerializer.Deserialize<JTNE_0x02_0x04>(data);
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x04, jTNE_0X02_0X04.TypeCode);
            Assert.Equal(0x01, jTNE_0X02_0X04.EngineStatus);
            Assert.Equal(102, jTNE_0X02_0X04.FuelRate);
            Assert.Equal(203, jTNE_0X02_0X04.Revs);
        }
    }
}
