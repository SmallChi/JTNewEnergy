using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x04_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x04_Device jTNE_0X02_0X04_Device = new JTNE_0x02_0x04_Device();
            jTNE_0X02_0X04_Device.EngineStatus = 0x01;
            jTNE_0X02_0X04_Device.FuelRate = 102;
            jTNE_0X02_0X04_Device.Revs = 203;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X04_Device).ToHexString();
            Assert.Equal("040100CB0066", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "040100CB0066".ToHexBytes();
            JTNE_0x02_0x04_Device jTNE_0X02_0X04_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x04_Device>(data);
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x04_Device, jTNE_0X02_0X04_Device.TypeCode);
            Assert.Equal(0x01, jTNE_0X02_0X04_Device.EngineStatus);
            Assert.Equal(102, jTNE_0X02_0X04_Device.FuelRate);
            Assert.Equal(203, jTNE_0X02_0X04_Device.Revs);
        }
    }
}
