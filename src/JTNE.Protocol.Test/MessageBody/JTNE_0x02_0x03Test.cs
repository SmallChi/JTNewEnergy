using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_0x03Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x02_0x03 jTNE_0X02_0X03 = new JTNE_0x02_0x03();
            jTNE_0X02_0X03.DCStatus = 0x02;
            jTNE_0X02_0X03.FuelBatteryCurrent = 111;
            jTNE_0X02_0X03.FuelBatteryVoltage = 2222;
            jTNE_0X02_0X03.FuelConsumptionRate = 3222;
            jTNE_0X02_0X03.HydrogenSystemMaxConcentrations = 6666;
            jTNE_0X02_0X03.HydrogenSystemMaxConcentrationsNo = 0x56;
            jTNE_0X02_0X03.HydrogenSystemMaxPressure = 3336;
            jTNE_0X02_0X03.HydrogenSystemMaxPressureNo = 0x65;
            jTNE_0X02_0X03.HydrogenSystemMaxTemp = 3355;
            jTNE_0X02_0X03.HydrogenSystemMaxTempNo = 0x22;
            jTNE_0X02_0X03.Temperatures = new byte[]
            {
                0x01,0x02,0x03
            };
            var hex = JTNESerializer.Serialize(jTNE_0X02_0X03).ToHexString();
            Assert.Equal("0308AE006F0C9600030102030D1B221A0A560D086502", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "0308AE006F0C9600030102030D1B221A0A560D086502".ToHexBytes();
            JTNE_0x02_0x03 jTNE_0X02_0X03 = JTNESerializer.Deserialize<JTNE_0x02_0x03>(data);
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x03, jTNE_0X02_0X03.TypeCode);
            Assert.Equal(0x02, jTNE_0X02_0X03.DCStatus);
            Assert.Equal(111, jTNE_0X02_0X03.FuelBatteryCurrent);
            Assert.Equal(2222, jTNE_0X02_0X03.FuelBatteryVoltage);
            Assert.Equal(3222, jTNE_0X02_0X03.FuelConsumptionRate);
            Assert.Equal(6666, jTNE_0X02_0X03.HydrogenSystemMaxConcentrations);
            Assert.Equal(0x56, jTNE_0X02_0X03.HydrogenSystemMaxConcentrationsNo);
            Assert.Equal(3336, jTNE_0X02_0X03.HydrogenSystemMaxPressure);
            Assert.Equal(0x65, jTNE_0X02_0X03.HydrogenSystemMaxPressureNo);
            Assert.Equal(3355, jTNE_0X02_0X03.HydrogenSystemMaxTemp);
            Assert.Equal(0x22, jTNE_0X02_0X03.HydrogenSystemMaxTempNo);
            Assert.Equal(new byte []{ 0x01, 0x02, 0x03 }, jTNE_0X02_0X03.Temperatures);
        }
    }
}
