using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x03Test
    {
        [Fact]
        public void Test1()
        {
            JTNE_0x03 jTNE_0X03 = new JTNE_0x03();
            JTNE_0x02 jTNE_0X02 = new JTNE_0x02();
            jTNE_0X02.Values = new Dictionary<byte, JTNE_0x02_Body>();

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
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x01, jTNE_0X02_0X01);

            JTNE_0x02_0x02 jTNE_0X02_0X02 = new JTNE_0x02_0x02();
            jTNE_0X02_0X02.Electricals = new List<Metadata.Electrical>();
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
            jTNE_0X02_0X02.Electricals.Add(electrical1);
            jTNE_0X02_0X02.Electricals.Add(electrical2);
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x02, jTNE_0X02_0X02);

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
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x03, jTNE_0X02_0X03);
            jTNE_0X03.Supplement = jTNE_0X02;
            var hex = JTNESerializer.Serialize(jTNE_0X03).ToHexString();
            //01 04 05 07 00 3A 00 00 1A 0A 00 64 00 63 03 06 02 00 7B 02 03 -21
            //02 02 01 02 01 00 41 00 37 03 00 EC 00 64 02 03 02 00 42 02 36 05 08 58 00 65 -26
            //03 08 AE 00 6F 0C 96 00 03 01 02 03 0D 1B 22 1A 0A 56 0D 08 65 02
            Assert.Equal("01040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502", hex);
        }
        
        [Fact]
        public void Test2()
        {
            var data = "01040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502".ToHexBytes();
            JTNE_0x03 jTNE_0X03 = JTNESerializer.Deserialize<JTNE_0x03>(data);
            JTNE_0x02 jTNE_0X02 = jTNE_0X03.Supplement;
            JTNE_0x02_0x01 jTNE_0X02_0X01 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x01] as JTNE_0x02_0x01;
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


            JTNE_0x02_0x02 jTNE_0X02_0X02 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x02] as JTNE_0x02_0x02;
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x02, jTNE_0X02_0X02.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X02.ElectricalCount);
            Metadata.Electrical electrical1 = jTNE_0X02_0X02.Electricals[0];
            Assert.Equal(0x01, electrical1.ElControlTemp);
            Assert.Equal(100, electrical1.ElCurrent);
            Assert.Equal(0x01, electrical1.ElNo);
            Assert.Equal(65, electrical1.ElSpeed);
            Assert.Equal(0x02, electrical1.ElStatus);
            Assert.Equal(0x03, electrical1.ElTemp);
            Assert.Equal(55, electrical1.ElTorque);
            Assert.Equal(236, electrical1.ElVoltage);
            Metadata.Electrical electrical2 = jTNE_0X02_0X02.Electricals[1];
            Assert.Equal(0x02, electrical2.ElControlTemp);
            Assert.Equal(101, electrical2.ElCurrent);
            Assert.Equal(0x02, electrical2.ElNo);
            Assert.Equal(66, electrical2.ElSpeed);
            Assert.Equal(0x03, electrical2.ElStatus);
            Assert.Equal(0x05, electrical2.ElTemp);
            Assert.Equal(566, electrical2.ElTorque);
            Assert.Equal(2136, electrical2.ElVoltage);

            JTNE_0x02_0x03 jTNE_0X02_0X03 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x03] as JTNE_0x02_0x03;

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
            Assert.Equal(new byte[] { 0x01, 0x02, 0x03 }, jTNE_0X02_0X03.Temperatures);
        }
    }
}
