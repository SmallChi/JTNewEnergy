using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x05_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x05_Device jTNE_0X02_0X05_Device = new JTNE_0x02_0x05_Device();
            jTNE_0X02_0X05_Device.Lat = 1233355;
            jTNE_0X02_0X05_Device.Lng = 3255555;
            jTNE_0X02_0X05_Device.PositioStatus = 0x01;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X05_Device).ToHexString();
            Assert.Equal("05010031AD030012D1CB", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "05010031AD030012D1CB".ToHexBytes();
            JTNE_0x02_0x05_Device jTNE_0X02_0X05_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x05_Device>(data);
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x05_Device, jTNE_0X02_0X05_Device.TypeCode);
            Assert.Equal((uint)1233355, jTNE_0X02_0X05_Device.Lat);
            Assert.Equal((uint)3255555, jTNE_0X02_0X05_Device.Lng);
            Assert.Equal(0x01, jTNE_0X02_0X05_Device.PositioStatus);
        }
    }
}
