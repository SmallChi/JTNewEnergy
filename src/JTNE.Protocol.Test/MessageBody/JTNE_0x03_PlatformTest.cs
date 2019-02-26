using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x03_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x03_Platform jTNE_0X03_Platform = new JTNE_0x03_Platform();
            JTNE_0x02_Platform jTNE_0X02_Platform = new JTNE_0x02_Platform();
            jTNE_0X02_Platform.Values = new Dictionary<byte, JTNE_0x02_Body_Platform>();

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
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x01_Platform, jTNE_0X02_0X01_Platform);

            JTNE_0x02_0x02_Platform jTNE_0X02_0X02_Platform = new JTNE_0x02_0x02_Platform();
            jTNE_0X02_0X02_Platform.Electricals = new List<Metadata.Electrical>();
            Metadata.Electrical electrical1 = new Metadata.Electrical();
            electrical1.ElControlTemp = 0x01;
            electrical1.ElCurrent = 100;
            electrical1.ElNo = 0x01;
            electrical1.ElSpeed = 65;
            electrical1.ElStatus = 0x02;
            electrical1.ElTemp = 0x03;
            electrical1.ElTorque = 55;
            electrical1.ElVoltage = 236;
            Metadata.Electrical electrical2 = new Metadata.Electrical();
            electrical2.ElControlTemp = 0x02;
            electrical2.ElCurrent = 101;
            electrical2.ElNo = 0x02;
            electrical2.ElSpeed = 66;
            electrical2.ElStatus = 0x03;
            electrical2.ElTemp = 0x05;
            electrical2.ElTorque = 566;
            electrical2.ElVoltage = 2136;
            jTNE_0X02_0X02_Platform.Electricals.Add(electrical1);
            jTNE_0X02_0X02_Platform.Electricals.Add(electrical2);
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x02_Platform, jTNE_0X02_0X02_Platform);

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
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x03_Platform, jTNE_0X02_0X03_Platform);
            jTNE_0X03_Platform.Supplement = jTNE_0X02_Platform;
            var hex = JTNESerializer_Platform.Serialize(jTNE_0X03_Platform).ToHexString();
            //01 04 05 07 00 3A 00 00 1A 0A 00 64 00 63 03 06 02 00 7B 02 03 -21
            //02 02 01 02 01 00 41 00 37 03 00 EC 00 64 02 03 02 00 42 02 36 05 08 58 00 65 -26
            //03 08 AE 00 6F 0C 96 00 03 01 02 03 0D 1B 22 1A 0A 56 0D 08 65 02
            Assert.Equal("01040507003A00001A0A00640063030602007B0202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502", hex);
        }
        
        [Fact]
        public void Test2()
        {
            var data = "01040507003A00001A0A00640063030602007B0202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502".ToHexBytes();
            JTNE_0x03_Platform jTNE_0X03_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x03_Platform>(data);
            JTNE_0x02_Platform jTNE_0X02_Platform = jTNE_0X03_Platform.Supplement;
            JTNE_0x02_0x01_Platform jTNE_0X02_0X01_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x01_Platform] as JTNE_0x02_0x01_Platform;
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


            JTNE_0x02_0x02_Platform jTNE_0X02_0X02_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x02_Platform] as JTNE_0x02_0x02_Platform;
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x02_Platform, jTNE_0X02_0X02_Platform.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X02_Platform.ElectricalCount);
            Metadata.Electrical electrical1 = jTNE_0X02_0X02_Platform.Electricals[0];
            Assert.Equal(0x01, electrical1.ElControlTemp);
            Assert.Equal(100, electrical1.ElCurrent);
            Assert.Equal(0x01, electrical1.ElNo);
            Assert.Equal(65, electrical1.ElSpeed);
            Assert.Equal(0x02, electrical1.ElStatus);
            Assert.Equal(0x03, electrical1.ElTemp);
            Assert.Equal(55, electrical1.ElTorque);
            Assert.Equal(236, electrical1.ElVoltage);
            Metadata.Electrical electrical2 = jTNE_0X02_0X02_Platform.Electricals[1];
            Assert.Equal(0x02, electrical2.ElControlTemp);
            Assert.Equal(101, electrical2.ElCurrent);
            Assert.Equal(0x02, electrical2.ElNo);
            Assert.Equal(66, electrical2.ElSpeed);
            Assert.Equal(0x03, electrical2.ElStatus);
            Assert.Equal(0x05, electrical2.ElTemp);
            Assert.Equal(566, electrical2.ElTorque);
            Assert.Equal(2136, electrical2.ElVoltage);

            JTNE_0x02_0x03_Platform jTNE_0X02_0X03_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x03_Platform] as JTNE_0x02_0x03_Platform;

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
            Assert.Equal(new byte[] { 0x01, 0x02, 0x03 }, jTNE_0X02_0X03_Platform.Temperatures);
        }
    }
}
