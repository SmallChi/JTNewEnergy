using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_Composite_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA1, typeof(JTNE_0x02_0xA1_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA2, typeof(JTNE_0x02_0xA2_Device));

            JTNE_0x02_Device jTNE_0X02_Device = new JTNE_0x02_Device();
            jTNE_0X02_Device.Values = new Dictionary<byte, JTNE_0x02_Body_Device>();
            jTNE_0X02_Device.CusotmSerializeObjectValues = new Dictionary<byte, JTNE_0x02_CustomBody_Device>();

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
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x01_Device, jTNE_0X02_0X01_Device);

            JTNE_0x02_0x02_Device jTNE_0X02_0X02_Device = new JTNE_0x02_0x02_Device();
            jTNE_0X02_0X02_Device.Electricals = new List<Metadata.Electrical>();
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
            jTNE_0X02_0X02_Device.Electricals.Add(electrical1);
            jTNE_0X02_0X02_Device.Electricals.Add(electrical2);
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x02_Device, jTNE_0X02_0X02_Device);

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
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x03_Device, jTNE_0X02_0X03_Device);

            JTNE_0x02_0xA1_Device jTNE_0X02_0XA1_Device = new JTNE_0x02_0xA1_Device();
            jTNE_0X02_0XA1_Device.UserName = "SmallChi";
            jTNE_0X02_0XA1_Device.Age = 18;
            jTNE_0X02_Device.CusotmSerializeObjectValues.Add(0xA1, jTNE_0X02_0XA1_Device);

            JTNE_0x02_0xA2_Device jTNE_0X02_0XA2_Device = new JTNE_0x02_0xA2_Device();
            jTNE_0X02_0XA2_Device.CompanyName = "小池有限公司";
            jTNE_0X02_Device.CusotmSerializeObjectValues.Add(0xA2, jTNE_0X02_0XA2_Device);


            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_Device).ToHexString();
            Assert.Equal("01040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000", hex);
        }

        [Fact]
        public void Test2()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA1, typeof(JTNE_0x02_0xA1_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA2, typeof(JTNE_0x02_0xA2_Device));

            var data = "01040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000".ToHexBytes();
            JTNE_0x02_Device jTNE_0X02_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_Device>(data);

            JTNE_0x02_0x01_Device jTNE_0X02_0X01_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x01_Device] as JTNE_0x02_0x01_Device;
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


            JTNE_0x02_0x02_Device jTNE_0X02_0X02_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x02_Device] as JTNE_0x02_0x02_Device;
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x02_Device, jTNE_0X02_0X02_Device.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X02_Device.ElectricalCount);
            Metadata.Electrical electrical1 = jTNE_0X02_0X02_Device.Electricals[0];
            Assert.Equal(0x01, electrical1.ElControlTemp);
            Assert.Equal(100, electrical1.ElCurrent);
            Assert.Equal(0x01, electrical1.ElNo);
            Assert.Equal(65, electrical1.ElSpeed);
            Assert.Equal(0x02, electrical1.ElStatus);
            Assert.Equal(0x03, electrical1.ElTemp);
            Assert.Equal(55, electrical1.ElTorque);
            Assert.Equal(236, electrical1.ElVoltage);
            Metadata.Electrical electrical2 = jTNE_0X02_0X02_Device.Electricals[1];
            Assert.Equal(0x02, electrical2.ElControlTemp);
            Assert.Equal(101, electrical2.ElCurrent);
            Assert.Equal(0x02, electrical2.ElNo);
            Assert.Equal(66, electrical2.ElSpeed);
            Assert.Equal(0x03, electrical2.ElStatus);
            Assert.Equal(0x05, electrical2.ElTemp);
            Assert.Equal(566, electrical2.ElTorque);
            Assert.Equal(2136, electrical2.ElVoltage);

            JTNE_0x02_0x03_Device jTNE_0X02_0X03_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x03_Device] as JTNE_0x02_0x03_Device;

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
            Assert.Equal(new byte[] { 0x01, 0x02, 0x03 }, jTNE_0X02_0X03_Device.Temperatures);


            JTNE_0x02_0xA1_Device jTNE_0X02_0XA1_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0xA1_Device>(jTNE_0X02_Device.CusotmValues[0xA1]);
            Assert.Equal(0xA1, jTNE_0X02_0XA1_Device.TypeCode);
            Assert.Equal(14, jTNE_0X02_0XA1_Device.Length);
            Assert.Equal("SmallChi", jTNE_0X02_0XA1_Device.UserName);
            Assert.Equal(18, jTNE_0X02_0XA1_Device.Age);

            JTNE_0x02_0xA2_Device jTNE_0X02_0XA2_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0xA2_Device>(jTNE_0X02_Device.CusotmValues[0xA2]);
            Assert.Equal(0xA2, jTNE_0X02_0XA2_Device.TypeCode);
            Assert.Equal(20, jTNE_0X02_0XA2_Device.Length);
            Assert.Equal("小池有限公司", jTNE_0X02_0XA2_Device.CompanyName);
        }

    }
}
