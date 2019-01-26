using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x05Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x05 jTNE_0X02_0X05 = new JTNE_0x02_0x05();
            jTNE_0X02_0X05.Lat = 1233355;
            jTNE_0X02_0X05.Lng = 3255555;
            jTNE_0X02_0X05.PositioStatus = 0x01;
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X05).ToHexString();
            Assert.Equal("05010031AD030012D1CB", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "05010031AD030012D1CB".ToHexBytes();
            JTNE_0x02_0x05 jTNE_0X02_0X05 = JTNESerializer.Deserialize<JTNE_0x02_0x05>(data);
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x05, jTNE_0X02_0X05.TypeCode);
            Assert.Equal((uint)1233355, jTNE_0X02_0X05.Lat);
            Assert.Equal((uint)3255555, jTNE_0X02_0X05.Lng);
            Assert.Equal(0x01, jTNE_0X02_0X05.PositioStatus);
        }
    }
}
