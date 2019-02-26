using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x05_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x05_Platform jTNE_0X02_0X05_Platform = new JTNE_0x02_0x05_Platform();
            jTNE_0X02_0X05_Platform.Lat = 1233355;
            jTNE_0X02_0X05_Platform.Lng = 3255555;
            jTNE_0X02_0X05_Platform.PositioStatus = 0x01;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_0X05_Platform).ToHexString();
            Assert.Equal("05010031AD030012D1CB", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "05010031AD030012D1CB".ToHexBytes();
            JTNE_0x02_0x05_Platform jTNE_0X02_0X05_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_0x05_Platform>(data);
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x05_Platform, jTNE_0X02_0X05_Platform.TypeCode);
            Assert.Equal((uint)1233355, jTNE_0X02_0X05_Platform.Lat);
            Assert.Equal((uint)3255555, jTNE_0X02_0X05_Platform.Lng);
            Assert.Equal(0x01, jTNE_0X02_0X05_Platform.PositioStatus);
        }
    }
}
