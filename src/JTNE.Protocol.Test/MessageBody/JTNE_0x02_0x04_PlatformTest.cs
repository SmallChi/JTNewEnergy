using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x04_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x04_Platform jTNE_0X02_0X04_Platform = new JTNE_0x02_0x04_Platform();
            jTNE_0X02_0X04_Platform.EngineStatus = 0x01;
            jTNE_0X02_0X04_Platform.FuelRate = 102;
            jTNE_0X02_0X04_Platform.Revs = 203;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_0X04_Platform).ToHexString();
            Assert.Equal("040100CB0066", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "040100CB0066".ToHexBytes();
            JTNE_0x02_0x04_Platform jTNE_0X02_0X04_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_0x04_Platform>(data);
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x04_Platform, jTNE_0X02_0X04_Platform.TypeCode);
            Assert.Equal(0x01, jTNE_0X02_0X04_Platform.EngineStatus);
            Assert.Equal(102, jTNE_0X02_0X04_Platform.FuelRate);
            Assert.Equal(203, jTNE_0X02_0X04_Platform.Revs);
        }
    }
}
