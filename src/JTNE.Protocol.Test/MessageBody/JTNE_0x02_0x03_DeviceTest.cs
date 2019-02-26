using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x03_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x03_Device jTNE_0X02_0X03_Device = new JTNE_0x02_0x03_Device();
            jTNE_0X02_0X03_Device.DCStatus = 0x02;
            jTNE_0X02_0X03_Device.FuelBatteryCurrent = 111;
            jTNE_0X02_0X03_Device.FuelBatteryVoltage = 2222;
            jTNE_0X02_0X03_Device.FuelConsumptionRate = 3222;
            jTNE_0X02_0X03_Device.HydrogenSystemMaxConcentrations = 6666;
            jTNE_0X02_0X03_Device.HydrogenSystemMaxConcentrationsNo = 0x56;
            jTNE_0X02_0X03_Device.HydrogenSystemMaxPressure = 3336;
            jTNE_0X02_0X03_Device.HydrogenSystemMaxPressureNo = 0x65;
            jTNE_0X02_0X03_Device.HydrogenSystemMaxTemp = 3355;
            jTNE_0X02_0X03_Device.HydrogenSystemMaxTempNo = 0x22;
            jTNE_0X02_0X03_Device.Temperatures = new byte[]
            {
                0x01,0x02,0x03
            };
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X03_Device).ToHexString();
            Assert.Equal("0308AE006F0C9600030102030D1B221A0A560D086502", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "0308AE006F0C9600030102030D1B221A0A560D086502".ToHexBytes();
            JTNE_0x02_0x03_Device jTNE_0X02_0X03_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x03_Device>(data);
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x03_Device, jTNE_0X02_0X03_Device.TypeCode);
            Assert.Equal(0x02, jTNE_0X02_0X03_Device.DCStatus);
            Assert.Equal(111, jTNE_0X02_0X03_Device.FuelBatteryCurrent);
            Assert.Equal(2222, jTNE_0X02_0X03_Device.FuelBatteryVoltage);
            Assert.Equal(3222, jTNE_0X02_0X03_Device.FuelConsumptionRate);
            Assert.Equal(6666, jTNE_0X02_0X03_Device.HydrogenSystemMaxConcentrations);
            Assert.Equal(0x56, jTNE_0X02_0X03_Device.HydrogenSystemMaxConcentrationsNo);
            Assert.Equal(3336, jTNE_0X02_0X03_Device.HydrogenSystemMaxPressure);
            Assert.Equal(0x65, jTNE_0X02_0X03_Device.HydrogenSystemMaxPressureNo);
            Assert.Equal(3355, jTNE_0X02_0X03_Device.HydrogenSystemMaxTemp);
            Assert.Equal(0x22, jTNE_0X02_0X03_Device.HydrogenSystemMaxTempNo);
            Assert.Equal(new byte []{ 0x01, 0x02, 0x03 }, jTNE_0X02_0X03_Device.Temperatures);
        }
    }
}
