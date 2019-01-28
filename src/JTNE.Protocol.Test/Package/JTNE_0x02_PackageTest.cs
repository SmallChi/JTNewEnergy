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
    public class JTNE_0x02_PackageTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage jTNEPackage = new JTNEPackage();
            jTNEPackage.AskId = JTNEAskId.Success.ToByteValue();
            jTNEPackage.MsgId = JTNEMsgId.uploadim.ToByteValue();
            jTNEPackage.VIN = "123456789";
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

            JTNE_0x02_0x04 jTNE_0X02_0X04 = new JTNE_0x02_0x04();
            jTNE_0X02_0X04.EngineStatus = 0x01;
            jTNE_0X02_0X04.FuelRate = 102;
            jTNE_0X02_0X04.Revs = 203;
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x04, jTNE_0X02_0X04);

            JTNE_0x02_0x05 jTNE_0X02_0X05 = new JTNE_0x02_0x05();
            jTNE_0X02_0X05.Lat = 1233355;
            jTNE_0X02_0X05.Lng = 3255555;
            jTNE_0X02_0X05.PositioStatus = 0x01;
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x05, jTNE_0X02_0X05);

            JTNE_0x02_0x06 jTNE_0X02_0X06 = new JTNE_0x02_0x06();
            jTNE_0X02_0X06.MaxTempBatteryAssemblyNo = 0x12;
            jTNE_0X02_0X06.MaxTempProbeBatteryNo = 0x32;
            jTNE_0X02_0X06.MaxTempProbeBatteryValue = 0x42;
            jTNE_0X02_0X06.MaxVoltageBatteryAssemblyNo = 0x11;
            jTNE_0X02_0X06.MaxVoltageSingleBatteryNo = 0x15;
            jTNE_0X02_0X06.MaxVoltageSingleBatteryValue = 123;
            jTNE_0X02_0X06.MinTempBatteryAssemblyNo = 0x32;
            jTNE_0X02_0X06.MinTempProbeBatteryNo = 0x11;
            jTNE_0X02_0X06.MinTempProbeBatteryValue = 0x06;
            jTNE_0X02_0X06.MinVoltageBatteryAssemblyNo = 0x07;
            jTNE_0X02_0X06.MinVoltageSingleBatteryNo = 0x09;
            jTNE_0X02_0X06.MinVoltageSingleBatteryValue = 0x08;
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x06, jTNE_0X02_0X06);

            JTNE_0x02_0x07 jTNE_0X02_0X07 = new JTNE_0x02_0x07();
            jTNE_0X02_0X07.AlarmBatteryFlag = 5533;
            jTNE_0X02_0X07.AlarmLevel = 0x11;
            jTNE_0X02_0X07.AlarmBatteryOthers = new List<uint>
            {
                1000,1001,1002
            };
            jTNE_0X02_0X07.AlarmEls = new List<uint>
            {
                2000,2001,2002
            };
            jTNE_0X02_0X07.AlarmEngines = new List<uint>
            {
                3000,3001,3002
            };
            jTNE_0X02_0X07.AlarmOthers = new List<uint>
            {
                4000,4001,4002
            };
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x07, jTNE_0X02_0X07);

            JTNE_0x02_0x08 jTNE_0X02_0X08 = new JTNE_0x02_0x08();
            jTNE_0X02_0X08.BatteryAssemblies = new List<Metadata.BatteryAssembly>();
            Metadata.BatteryAssembly batteryAssembly1 = new Metadata.BatteryAssembly();
            batteryAssembly1.BatteryAssemblyCurrent = 123;
            batteryAssembly1.BatteryAssemblyNo = 0x01;
            batteryAssembly1.BatteryAssemblyVoltage = 0x02;
            batteryAssembly1.SingleBatteryCount = 55;
            batteryAssembly1.ThisSingleBatteryBeginCount = 0x02;
            batteryAssembly1.ThisSingleBatteryBeginNo = 111;
            batteryAssembly1.SingleBatteryVoltages = new List<ushort> {
                111,222,333
            };
            Metadata.BatteryAssembly batteryAssembly2 = new Metadata.BatteryAssembly();
            batteryAssembly2.BatteryAssemblyCurrent = 1234;
            batteryAssembly2.BatteryAssemblyNo = 0x03;
            batteryAssembly2.BatteryAssemblyVoltage = 0x05;
            batteryAssembly2.SingleBatteryCount = 66;
            batteryAssembly2.ThisSingleBatteryBeginCount = 0x02;
            batteryAssembly2.ThisSingleBatteryBeginNo = 222;
            batteryAssembly2.SingleBatteryVoltages = new List<ushort> {
                444,555,666
            };
            jTNE_0X02_0X08.BatteryAssemblies.Add(batteryAssembly1);
            jTNE_0X02_0X08.BatteryAssemblies.Add(batteryAssembly2);
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x08, jTNE_0X02_0X08);


            JTNE_0x02_0x09 jTNE_0X02_0X09 = new JTNE_0x02_0x09();
            jTNE_0X02_0X09.BatteryTemperatures = new List<Metadata.BatteryTemperature>();

            Metadata.BatteryTemperature batteryTemperature1 = new Metadata.BatteryTemperature();
            batteryTemperature1.BatteryAssemblyNo = 0x01;
            batteryTemperature1.Temperatures = new byte[]
            {
                0x01,0x02,0x03,0x04
            };

            Metadata.BatteryTemperature batteryTemperature2 = new Metadata.BatteryTemperature();
            batteryTemperature2.BatteryAssemblyNo = 0x02;
            batteryTemperature2.Temperatures = new byte[]
            {
                0x05,0x06,0x07,0x08
            };

            jTNE_0X02_0X09.BatteryTemperatures.Add(batteryTemperature1);
            jTNE_0X02_0X09.BatteryTemperatures.Add(batteryTemperature2);
            jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x09, jTNE_0X02_0X09);

            jTNEPackage.Bodies = jTNE_0X02;
            var hex = JTNESerializer.Serialize(jTNEPackage).ToHexString();
            Assert.Equal("2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867".ToHexBytes();
            JTNEPackage jTNEPackage = JTNESerializer.Deserialize(data);
            JTNE_0x02 jTNE_0X02 = jTNEPackage.Bodies as JTNE_0x02;

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

            JTNE_0x02_0x04 jTNE_0X02_0X04 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x04] as JTNE_0x02_0x04;
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x04, jTNE_0X02_0X04.TypeCode);
            Assert.Equal(0x01, jTNE_0X02_0X04.EngineStatus);
            Assert.Equal(102, jTNE_0X02_0X04.FuelRate);
            Assert.Equal(203, jTNE_0X02_0X04.Revs);

            JTNE_0x02_0x05 jTNE_0X02_0X05 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x05] as JTNE_0x02_0x05;
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x05, jTNE_0X02_0X05.TypeCode);
            Assert.Equal((uint)1233355, jTNE_0X02_0X05.Lat);
            Assert.Equal((uint)3255555, jTNE_0X02_0X05.Lng);
            Assert.Equal(0x01, jTNE_0X02_0X05.PositioStatus);


            JTNE_0x02_0x06 jTNE_0X02_0X06 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x06] as JTNE_0x02_0x06;
            Assert.Equal(0x12, jTNE_0X02_0X06.MaxTempBatteryAssemblyNo);
            Assert.Equal(0x32, jTNE_0X02_0X06.MaxTempProbeBatteryNo);
            Assert.Equal(0x42, jTNE_0X02_0X06.MaxTempProbeBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06.MaxVoltageBatteryAssemblyNo);
            Assert.Equal(0x15, jTNE_0X02_0X06.MaxVoltageSingleBatteryNo);
            Assert.Equal(123, jTNE_0X02_0X06.MaxVoltageSingleBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06.MinTempProbeBatteryNo);
            Assert.Equal(0x06, jTNE_0X02_0X06.MinTempProbeBatteryValue);
            Assert.Equal(0x07, jTNE_0X02_0X06.MinVoltageBatteryAssemblyNo);
            Assert.Equal(0x09, jTNE_0X02_0X06.MinVoltageSingleBatteryNo);
            Assert.Equal(0x08, jTNE_0X02_0X06.MinVoltageSingleBatteryValue);

            JTNE_0x02_0x07 jTNE_0X02_0X07 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x07] as JTNE_0x02_0x07;
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x07, jTNE_0X02_0X07.TypeCode);
            Assert.Equal(0x11, jTNE_0X02_0X07.AlarmLevel);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmBatteryOthers.Count);
            Assert.Equal(new List<uint>
            {
                1000,1001,1002
            }, jTNE_0X02_0X07.AlarmBatteryOthers);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmEls.Count);
            Assert.Equal(new List<uint>
            {
                2000,2001,2002
            }, jTNE_0X02_0X07.AlarmEls);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmEngines.Count);
            Assert.Equal(new List<uint>
            {
                3000,3001,3002
            }, jTNE_0X02_0X07.AlarmEngines);
            Assert.Equal(3, jTNE_0X02_0X07.AlarmOthers.Count);
            Assert.Equal(new List<uint>
            {
                4000,4001,4002
            }, jTNE_0X02_0X07.AlarmOthers);

            JTNE_0x02_0x08 jTNE_0X02_0X08 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x08] as JTNE_0x02_0x08;
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x08, jTNE_0X02_0X08.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X08.BatteryAssemblyCount);

            Metadata.BatteryAssembly batteryAssembly1 = jTNE_0X02_0X08.BatteryAssemblies[0];
            Assert.Equal(123, batteryAssembly1.BatteryAssemblyCurrent);
            Assert.Equal(0x01, batteryAssembly1.BatteryAssemblyNo);
            Assert.Equal(0x02, batteryAssembly1.BatteryAssemblyVoltage);
            Assert.Equal(55, batteryAssembly1.SingleBatteryCount);
            Assert.Equal(111, batteryAssembly1.ThisSingleBatteryBeginNo);
            Assert.Equal(3, batteryAssembly1.ThisSingleBatteryBeginCount);
            Assert.Equal(new List<ushort> {
                111,222,333
            }, batteryAssembly1.SingleBatteryVoltages);

            Metadata.BatteryAssembly batteryAssembly2 = jTNE_0X02_0X08.BatteryAssemblies[1];
            Assert.Equal(1234, batteryAssembly2.BatteryAssemblyCurrent);
            Assert.Equal(0x03, batteryAssembly2.BatteryAssemblyNo);
            Assert.Equal(0x05, batteryAssembly2.BatteryAssemblyVoltage);
            Assert.Equal(66, batteryAssembly2.SingleBatteryCount);
            Assert.Equal(222, batteryAssembly2.ThisSingleBatteryBeginNo);
            Assert.Equal(3, batteryAssembly2.ThisSingleBatteryBeginCount);
            Assert.Equal(new List<ushort> {
                444,555,666
            }, batteryAssembly2.SingleBatteryVoltages);

            JTNE_0x02_0x09 jTNE_0X02_0X09 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x09] as JTNE_0x02_0x09;
            Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x09, jTNE_0X02_0X09.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X09.BatteryTemperatureCount);

            Metadata.BatteryTemperature batteryTemperature1 = jTNE_0X02_0X09.BatteryTemperatures[0];
            Assert.Equal(0x01, batteryTemperature1.BatteryAssemblyNo);
            Assert.Equal(4, batteryTemperature1.TemperatureProbeCount);
            Assert.Equal(new byte[]
            {
                0x01,0x02,0x03,0x04
            }, batteryTemperature1.Temperatures);

            Metadata.BatteryTemperature batteryTemperature2 = jTNE_0X02_0X09.BatteryTemperatures[1];
            Assert.Equal(0x02, batteryTemperature2.BatteryAssemblyNo);
            Assert.Equal(4, batteryTemperature2.TemperatureProbeCount);
            Assert.Equal(new byte[]
            {
                0x05,0x06,0x07,0x08
            }, batteryTemperature2.Temperatures);
        }
    }
}
