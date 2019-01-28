using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_CompositeTest
    {
        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA1, typeof(JTNE_0x02_0xA1));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA2, typeof(JTNE_0x02_0xA2));

            JTNE_0x02 jTNE_0X02 = new JTNE_0x02();
            jTNE_0X02.Values = new Dictionary<byte, JTNE_0x02_Body>();
            jTNE_0X02.CusotmSerializeObjectValues = new Dictionary<byte, JTNE_0x02_CustomBody>();

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

            JTNE_0x02_0xA1 jTNE_0X02_0XA1 = new JTNE_0x02_0xA1();
            jTNE_0X02_0XA1.UserName = "SmallChi";
            jTNE_0X02_0XA1.Age = 18;
            jTNE_0X02.CusotmSerializeObjectValues.Add(0xA1, jTNE_0X02_0XA1);

            JTNE_0x02_0xA2 jTNE_0X02_0XA2 = new JTNE_0x02_0xA2();
            jTNE_0X02_0XA2.CompanyName = "小池有限公司";
            jTNE_0X02.CusotmSerializeObjectValues.Add(0xA2, jTNE_0X02_0XA2);


            var hex = JTNESerializer.Serialize(jTNE_0X02).ToHexString();
            Assert.Equal("01040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000", hex);
        }

        [Fact]
        public void Test2()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA1, typeof(JTNE_0x02_0xA1));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA2, typeof(JTNE_0x02_0xA2));

            var data = "01040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000".ToHexBytes();
            JTNE_0x02 jTNE_0X02 = JTNESerializer.Deserialize<JTNE_0x02>(data);

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


            JTNE_0x02_0xA1 jTNE_0X02_0XA1 = JTNESerializer.Deserialize<JTNE_0x02_0xA1>(jTNE_0X02.CusotmValues[0xA1]);
            Assert.Equal(0xA1, jTNE_0X02_0XA1.TypeCode);
            Assert.Equal(14, jTNE_0X02_0XA1.Length);
            Assert.Equal("SmallChi", jTNE_0X02_0XA1.UserName);
            Assert.Equal(18, jTNE_0X02_0XA1.Age);

            JTNE_0x02_0xA2 jTNE_0X02_0XA2 = JTNESerializer.Deserialize<JTNE_0x02_0xA2>(jTNE_0X02.CusotmValues[0xA2]);
            Assert.Equal(0xA2, jTNE_0X02_0XA2.TypeCode);
            Assert.Equal(20, jTNE_0X02_0XA2.Length);
            Assert.Equal("小池有限公司", jTNE_0X02_0XA2.CompanyName);
        }

    }
}
