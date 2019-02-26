using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x01_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x01_Device jTNE_0X02_0X01_Device = new JTNE_0x02_0x01_Device();
            jTNE_0X02_0X01_Device.Accelerator = 0x02;
            jTNE_0X02_0X01_Device.Brakes = 0x03;
            jTNE_0X02_0X01_Device.CarStatus = 0x04;
            jTNE_0X02_0X01_Device.ChargeStatus = 0x05;
            jTNE_0X02_0X01_Device.DCStatus = 0x06;
            jTNE_0X02_0X01_Device.OperationMode = 0x07;
            jTNE_0X02_0X01_Device.Resistance = 123;
            jTNE_0X02_0X01_Device.SOC = 0x03;
            jTNE_0X02_0X01_Device.Speed = 58;
            jTNE_0X02_0X01_Device.Stall = 0x02;
            jTNE_0X02_0X01_Device.TotalDis = 6666;
            jTNE_0X02_0X01_Device.TotalTemp = 99;
            jTNE_0X02_0X01_Device.TotalVoltage = 100;
            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_0X01_Device).ToHexString();
            Assert.Equal("01040507003A00001A0A00640063030602007B0203", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "01040507003A00001A0A00640063030602007B0203".ToHexBytes();
            JTNE_0x02_0x01_Device jTNE_0X02_0X01_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0x01_Device>(data);
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x01_Device, jTNE_0X02_0X01_Device.TypeCode);
            Assert.Equal(0x02, jTNE_0X02_0X01_Device.Accelerator);
            Assert.Equal(0x03, jTNE_0X02_0X01_Device.Brakes);
            Assert.Equal(0x04, jTNE_0X02_0X01_Device.CarStatus);
            Assert.Equal(0x05, jTNE_0X02_0X01_Device.ChargeStatus);
            Assert.Equal(0x06, jTNE_0X02_0X01_Device.DCStatus);
            Assert.Equal(0x07, jTNE_0X02_0X01_Device.OperationMode);
            Assert.Equal(123, jTNE_0X02_0X01_Device.Resistance);
            Assert.Equal(0x03, jTNE_0X02_0X01_Device.SOC);
            Assert.Equal(58, jTNE_0X02_0X01_Device.Speed);
            Assert.Equal(0x02, jTNE_0X02_0X01_Device.Stall);
            Assert.Equal((uint)6666, jTNE_0X02_0X01_Device.TotalDis);
            Assert.Equal(99, jTNE_0X02_0X01_Device.TotalTemp);
            Assert.Equal(100, jTNE_0X02_0X01_Device.TotalVoltage);
        }
    }
}
