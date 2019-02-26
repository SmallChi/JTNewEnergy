using JTNE.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Enums;
using JTNE.Protocol.MessageBody;
using JTNE.Protocol.Internal;

namespace JTNE.Protocol.Test.Package
{
    public class JTNE_0x02_Package_PlatformTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Platform jTNEPackage_Platform = new JTNEPackage_Platform();
            jTNEPackage_Platform.AskId = JTNEAskId.Success.ToByteValue();
            jTNEPackage_Platform.MsgId = JTNEMsgId_Platform.uploadim.ToByteValue();
            jTNEPackage_Platform.VIN = "123456789";
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

            JTNE_0x02_0x04_Platform jTNE_0X02_0X04_Platform = new JTNE_0x02_0x04_Platform();
            jTNE_0X02_0X04_Platform.EngineStatus = 0x01;
            jTNE_0X02_0X04_Platform.FuelRate = 102;
            jTNE_0X02_0X04_Platform.Revs = 203;
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x04_Platform, jTNE_0X02_0X04_Platform);

            JTNE_0x02_0x05_Platform jTNE_0X02_0X05_Platform = new JTNE_0x02_0x05_Platform();
            jTNE_0X02_0X05_Platform.Lat = 1233355;
            jTNE_0X02_0X05_Platform.Lng = 3255555;
            jTNE_0X02_0X05_Platform.PositioStatus = 0x01;
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x05_Platform, jTNE_0X02_0X05_Platform);

            JTNE_0x02_0x06_Platform jTNE_0X02_0X06_Platform = new JTNE_0x02_0x06_Platform();
            jTNE_0X02_0X06_Platform.MaxTempBatteryAssemblyNo = 0x12;
            jTNE_0X02_0X06_Platform.MaxTempProbeBatteryNo = 0x32;
            jTNE_0X02_0X06_Platform.MaxTempProbeBatteryValue = 0x42;
            jTNE_0X02_0X06_Platform.MaxVoltageBatteryAssemblyNo = 0x11;
            jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryNo = 0x15;
            jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryValue = 123;
            jTNE_0X02_0X06_Platform.MinTempBatteryAssemblyNo = 0x32;
            jTNE_0X02_0X06_Platform.MinTempProbeBatteryNo = 0x11;
            jTNE_0X02_0X06_Platform.MinTempProbeBatteryValue = 0x06;
            jTNE_0X02_0X06_Platform.MinVoltageBatteryAssemblyNo = 0x07;
            jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryNo = 0x09;
            jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryValue = 0x08;
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x06_Platform, jTNE_0X02_0X06_Platform);

            JTNE_0x02_0x07_Platform jTNE_0X02_0X07_Platform = new JTNE_0x02_0x07_Platform();
            jTNE_0X02_0X07_Platform.AlarmBatteryFlag = 5533;
            jTNE_0X02_0X07_Platform.AlarmLevel = 0x11;
            jTNE_0X02_0X07_Platform.AlarmBatteryOthers = new List<uint>
            {
                1000,1001,1002
            };
            jTNE_0X02_0X07_Platform.AlarmEls = new List<uint>
            {
                2000,2001,2002
            };
            jTNE_0X02_0X07_Platform.AlarmEngines = new List<uint>
            {
                3000,3001,3002
            };
            jTNE_0X02_0X07_Platform.AlarmOthers = new List<uint>
            {
                4000,4001,4002
            };
            jTNE_0X02_Platform.Values.Add(JTNE_0x02_Body_Platform.JTNE_0x02_0x07_Platform, jTNE_0X02_0X07_Platform);
   

            jTNEPackage_Platform.Bodies = jTNE_0X02_Platform;
            var hex = JTNESerializer_Platform.Serialize(jTNEPackage_Platform).ToHexString();
            Assert.Equal("23230201313233343536373839000000000000000001009C01040507003A00001A0A00640063030602007B0202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA2BD", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "23230201313233343536373839000000000000000001009C01040507003A00001A0A00640063030602007B0202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA2BD".ToHexBytes();
            JTNEPackage_Platform jTNEPackage_Platform = JTNESerializer_Platform.Deserialize(data);
            JTNE_0x02_Platform jTNE_0X02_Platform = jTNEPackage_Platform.Bodies as JTNE_0x02_Platform;

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

            JTNE_0x02_0x04_Platform jTNE_0X02_0X04_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x04_Platform] as JTNE_0x02_0x04_Platform;
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x04_Platform, jTNE_0X02_0X04_Platform.TypeCode);
            Assert.Equal(0x01, jTNE_0X02_0X04_Platform.EngineStatus);
            Assert.Equal(102, jTNE_0X02_0X04_Platform.FuelRate);
            Assert.Equal(203, jTNE_0X02_0X04_Platform.Revs);

            JTNE_0x02_0x05_Platform jTNE_0X02_0X05_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x05_Platform] as JTNE_0x02_0x05_Platform;
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x05_Platform, jTNE_0X02_0X05_Platform.TypeCode);
            Assert.Equal((uint)1233355, jTNE_0X02_0X05_Platform.Lat);
            Assert.Equal((uint)3255555, jTNE_0X02_0X05_Platform.Lng);
            Assert.Equal(0x01, jTNE_0X02_0X05_Platform.PositioStatus);


            JTNE_0x02_0x06_Platform jTNE_0X02_0X06_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x06_Platform] as JTNE_0x02_0x06_Platform;
            Assert.Equal(0x12, jTNE_0X02_0X06_Platform.MaxTempBatteryAssemblyNo);
            Assert.Equal(0x32, jTNE_0X02_0X06_Platform.MaxTempProbeBatteryNo);
            Assert.Equal(0x42, jTNE_0X02_0X06_Platform.MaxTempProbeBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Platform.MaxVoltageBatteryAssemblyNo);
            Assert.Equal(0x15, jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryNo);
            Assert.Equal(123, jTNE_0X02_0X06_Platform.MaxVoltageSingleBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Platform.MinTempProbeBatteryNo);
            Assert.Equal(0x06, jTNE_0X02_0X06_Platform.MinTempProbeBatteryValue);
            Assert.Equal(0x07, jTNE_0X02_0X06_Platform.MinVoltageBatteryAssemblyNo);
            Assert.Equal(0x09, jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryNo);
            Assert.Equal(0x08, jTNE_0X02_0X06_Platform.MinVoltageSingleBatteryValue);

            JTNE_0x02_0x07_Platform jTNE_0X02_0X07_Platform = jTNE_0X02_Platform.Values[JTNE_0x02_Body_Platform.JTNE_0x02_0x07_Platform] as JTNE_0x02_0x07_Platform;
            Assert.Equal(JTNE_0x02_Body_Platform.JTNE_0x02_0x07_Platform, jTNE_0X02_0X07_Platform.TypeCode);
            Assert.Equal(0x11, jTNE_0X02_0X07_Platform.AlarmLevel);
            Assert.Equal(3, jTNE_0X02_0X07_Platform.AlarmBatteryOthers.Count);
            Assert.Equal(new List<uint>
            {
                1000,1001,1002
            }, jTNE_0X02_0X07_Platform.AlarmBatteryOthers);
            Assert.Equal(3, jTNE_0X02_0X07_Platform.AlarmEls.Count);
            Assert.Equal(new List<uint>
            {
                2000,2001,2002
            }, jTNE_0X02_0X07_Platform.AlarmEls);
            Assert.Equal(3, jTNE_0X02_0X07_Platform.AlarmEngines.Count);
            Assert.Equal(new List<uint>
            {
                3000,3001,3002
            }, jTNE_0X02_0X07_Platform.AlarmEngines);
            Assert.Equal(3, jTNE_0X02_0X07_Platform.AlarmOthers.Count);
            Assert.Equal(new List<uint>
            {
                4000,4001,4002
            }, jTNE_0X02_0X07_Platform.AlarmOthers);
        }
    }
}
