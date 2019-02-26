using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x01_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x01_Platform jTNE_0X02_0X01_Platform = new JTNE_0x02_0x01_Platform();
            jTNE_0X02_0X01_Platform.CarStatus = 0x04;
            jTNE_0X02_0X01_Platform.ChargeStatus = 0x05;
            jTNE_0X02_0X01_Platform.DCStatus = 0x06;
            jTNE_0X02_0X01_Platform.OperationMode = 0x07;
            jTNE_0X02_0X01_Platform.Resistance = 123;
            jTNE_0X02_0X01_Platform.SOC = 0x03;
            jTNE_0X02_0X01_Platform.Speed = 58;
            jTNE_0X02_0X01_Platform.Stall = 0x02;
            jTNE_0X02_0X01_Platform.TotalDis = 6666;
            jTNE_0X02_0X01_Platform.TotalTemp = 99;
            jTNE_0X02_0X01_Platform.TotalVoltage = 100;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_0X01_Platform).ToHexString();
            Assert.Equal("01040507003A00001A0A00640063030602007B", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "01040507003A00001A0A00640063030602007B".ToHexBytes();
            JTNE_0x02_0x01_Platform jTNE_0X02_0X01_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_0x01_Platform>(data);
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x01_Platform, jTNE_0X02_0X01_Platform.TypeCode);
            Assert.Equal(0x04, jTNE_0X02_0X01_Platform.CarStatus);
            Assert.Equal(0x05, jTNE_0X02_0X01_Platform.ChargeStatus);
            Assert.Equal(0x06, jTNE_0X02_0X01_Platform.DCStatus);
            Assert.Equal(0x07, jTNE_0X02_0X01_Platform.OperationMode);
            Assert.Equal(123, jTNE_0X02_0X01_Platform.Resistance);
            Assert.Equal(0x03, jTNE_0X02_0X01_Platform.SOC);
            Assert.Equal(58, jTNE_0X02_0X01_Platform.Speed);
            Assert.Equal(0x02, jTNE_0X02_0X01_Platform.Stall);
            Assert.Equal((uint)6666, jTNE_0X02_0X01_Platform.TotalDis);
            Assert.Equal(99, jTNE_0X02_0X01_Platform.TotalTemp);
            Assert.Equal(100, jTNE_0X02_0X01_Platform.TotalVoltage);
        }
    }
}
