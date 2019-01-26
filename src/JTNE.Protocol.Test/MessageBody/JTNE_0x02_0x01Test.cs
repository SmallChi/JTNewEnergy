using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x01Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x01 jTNE_0X02_0X01 = new JTNE_0x02_0x01();
            jTNE_0X02_0X01.Accelerator = 0x02;
            jTNE_0X02_0X01.Brakes = 0x03;
            jTNE_0X02_0X01.CarStatus = 0x04;
            jTNE_0X02_0X01.ChargeStatus = 0x05;
            jTNE_0X02_0X01.DCStatus = 0x06;
            jTNE_0X02_0X01.OperationMode = 0x07;
            jTNE_0X02_0X01.Resistance = 123;
            jTNE_0X02_0X01.SOC = 0x03;
            jTNE_0X02_0X01.Speed = 58;
            jTNE_0X02_0X01.Stall = 0x02;
            jTNE_0X02_0X01.TotalDis = 6666;
            jTNE_0X02_0X01.TotalTemp = 99;
            jTNE_0X02_0X01.TotalVoltage = 100;
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X01).ToHexString();
            Assert.Equal("01040507003A00001A0A00640063030602007B0203", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "01040507003A00001A0A00640063030602007B0203".ToHexBytes();
            JTNE_0x02_0x01 jTNE_0X02_0X01 = JTNESerializer.Deserialize<JTNE_0x02_0x01>(data);
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x01, jTNE_0X02_0X01.TypeCode);
            Assert.Equal(0x02, jTNE_0X02_0X01.Accelerator);
            Assert.Equal(0x03, jTNE_0X02_0X01.Brakes);
            Assert.Equal(0x04, jTNE_0X02_0X01.CarStatus);
            Assert.Equal(0x05, jTNE_0X02_0X01.ChargeStatus);
            Assert.Equal(0x06, jTNE_0X02_0X01.DCStatus);
            Assert.Equal(0x07, jTNE_0X02_0X01.OperationMode);
            Assert.Equal(123, jTNE_0X02_0X01.Resistance);
            Assert.Equal(0x03, jTNE_0X02_0X01.SOC);
            Assert.Equal(58, jTNE_0X02_0X01.Speed);
            Assert.Equal(0x02, jTNE_0X02_0X01.Stall);
            Assert.Equal((uint)6666, jTNE_0X02_0X01.TotalDis);
            Assert.Equal(99, jTNE_0X02_0X01.TotalTemp);
            Assert.Equal(100, jTNE_0X02_0X01.TotalVoltage);
        }
    }
}
