using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x09_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x09_Device jTNE_0X02_0X09_Device = new JTNE_0x02_0x09_Device();
            jTNE_0X02_0X09_Device.BatteryTemperatures = new List<Metadata.BatteryTemperature>();

            Metadata.BatteryTemperature batteryTemperature1 = new Metadata.BatteryTemperature();
            batteryTemperature1.BatteryAssemblyNo = 0x01;
            batteryTemperature1.Temperatures = new byte[]
            {
                0x01,0x02,0x03,0x04
            };
           
            Metadata.BatteryTemperature batteryTemperature2 = new Metadata.BatteryTemperature();
            batteryTemperature2.BatteryAssemblyNo = 0x02;
            batteryTemperature2.Temperatures = new byte[]
            {
                0x05,0x06,0x07,0x08
            };

            jTNE_0X02_0X09_Device.BatteryTemperatures.Add(batteryTemperature1);
            jTNE_0X02_0X09_Device.BatteryTemperatures.Add(batteryTemperature2);
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X09_Device).ToHexString();
            Assert.Equal("09020100040102030402000405060708", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "09020100040102030402000405060708".ToHexBytes();
            JTNE_0x02_0x09_Device jTNE_0X02_0X09_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x09_Device>(data);
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x09_Device, jTNE_0X02_0X09_Device.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X09_Device.BatteryTemperatureCount);

            Metadata.BatteryTemperature batteryTemperature1 = jTNE_0X02_0X09_Device.BatteryTemperatures[0];
            Assert.Equal(0x01, batteryTemperature1.BatteryAssemblyNo);
            Assert.Equal(4, batteryTemperature1.TemperatureProbeCount);
            Assert.Equal(new byte[]
            {
                0x01,0x02,0x03,0x04
            }, batteryTemperature1.Temperatures);

            Metadata.BatteryTemperature batteryTemperature2 = jTNE_0X02_0X09_Device.BatteryTemperatures[1];
            Assert.Equal(0x02, batteryTemperature2.BatteryAssemblyNo);
            Assert.Equal(4, batteryTemperature2.TemperatureProbeCount);
            Assert.Equal(new byte[]
            {
                0x05,0x06,0x07,0x08
            }, batteryTemperature2.Temperatures);
        }
    }
}
