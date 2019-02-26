using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x03_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x03_Platform jTNE_0X02_0X03_Platform = new JTNE_0x02_0x03_Platform();
            jTNE_0X02_0X03_Platform.DCStatus = 0x02;
            jTNE_0X02_0X03_Platform.FuelBatteryCurrent = 111;
            jTNE_0X02_0X03_Platform.FuelBatteryVoltage = 2222;
            jTNE_0X02_0X03_Platform.FuelConsumptionRate = 3222;
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxConcentrations = 6666;
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxConcentrationsNo = 0x56;
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxPressure = 3336;
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxPressureNo = 0x65;
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxTemp = 3355;
            jTNE_0X02_0X03_Platform.HydrogenSystemMaxTempNo = 0x22;
            jTNE_0X02_0X03_Platform.Temperatures = new byte[]
            {
                0x01,0x02,0x03
            };
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_0X03_Platform).ToHexString();
            Assert.Equal("0308AE006F0C9600030102030D1B221A0A560D086502", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "0308AE006F0C9600030102030D1B221A0A560D086502".ToHexBytes();
            JTNE_0x02_0x03_Platform jTNE_0X02_0X03_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_0x03_Platform>(data);
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x03_Platform, jTNE_0X02_0X03_Platform.TypeCode);
            Assert.Equal(0x02, jTNE_0X02_0X03_Platform.DCStatus);
            Assert.Equal(111, jTNE_0X02_0X03_Platform.FuelBatteryCurrent);
            Assert.Equal(2222, jTNE_0X02_0X03_Platform.FuelBatteryVoltage);
            Assert.Equal(3222, jTNE_0X02_0X03_Platform.FuelConsumptionRate);
            Assert.Equal(6666, jTNE_0X02_0X03_Platform.HydrogenSystemMaxConcentrations);
            Assert.Equal(0x56, jTNE_0X02_0X03_Platform.HydrogenSystemMaxConcentrationsNo);
            Assert.Equal(3336, jTNE_0X02_0X03_Platform.HydrogenSystemMaxPressure);
            Assert.Equal(0x65, jTNE_0X02_0X03_Platform.HydrogenSystemMaxPressureNo);
            Assert.Equal(3355, jTNE_0X02_0X03_Platform.HydrogenSystemMaxTemp);
            Assert.Equal(0x22, jTNE_0X02_0X03_Platform.HydrogenSystemMaxTempNo);
            Assert.Equal(new byte []{ 0x01, 0x02, 0x03 }, jTNE_0X02_0X03_Platform.Temperatures);
        }
    }
}
