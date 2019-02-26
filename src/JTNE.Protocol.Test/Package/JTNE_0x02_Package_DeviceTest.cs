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
    public class JTNE_0x02_Package_DeviceTest
    {
        [Fact]
        public void Test1()
        {
            JTNEPackage_Device jTNEPackage_Device = new JTNEPackage_Device();
            jTNEPackage_Device.AskId = JTNEAskId.Success.ToByteValue();
            jTNEPackage_Device.MsgId = JTNEMsgId_Device.uploadim.ToByteValue();
            jTNEPackage_Device.VIN = "123456789";
            JTNE_0x02_Device jTNE_0X02_Device = new JTNE_0x02_Device();
            jTNE_0X02_Device.Values = new Dictionary<byte, JTNE_0x02_Body_Device>();

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

            JTNE_0x02_0x04_Device jTNE_0X02_0X04_Device = new JTNE_0x02_0x04_Device();
            jTNE_0X02_0X04_Device.EngineStatus = 0x01;
            jTNE_0X02_0X04_Device.FuelRate = 102;
            jTNE_0X02_0X04_Device.Revs = 203;
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x04_Device, jTNE_0X02_0X04_Device);

            JTNE_0x02_0x05_Device jTNE_0X02_0X05_Device = new JTNE_0x02_0x05_Device();
            jTNE_0X02_0X05_Device.Lat = 1233355;
            jTNE_0X02_0X05_Device.Lng = 3255555;
            jTNE_0X02_0X05_Device.PositioStatus = 0x01;
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x05_Device, jTNE_0X02_0X05_Device);

            JTNE_0x02_0x06_Device jTNE_0X02_0X06_Device = new JTNE_0x02_0x06_Device();
            jTNE_0X02_0X06_Device.MaxTempBatteryAssemblyNo = 0x12;
            jTNE_0X02_0X06_Device.MaxTempProbeBatteryNo = 0x32;
            jTNE_0X02_0X06_Device.MaxTempProbeBatteryValue = 0x42;
            jTNE_0X02_0X06_Device.MaxVoltageBatteryAssemblyNo = 0x11;
            jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryNo = 0x15;
            jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryValue = 123;
            jTNE_0X02_0X06_Device.MinTempBatteryAssemblyNo = 0x32;
            jTNE_0X02_0X06_Device.MinTempProbeBatteryNo = 0x11;
            jTNE_0X02_0X06_Device.MinTempProbeBatteryValue = 0x06;
            jTNE_0X02_0X06_Device.MinVoltageBatteryAssemblyNo = 0x07;
            jTNE_0X02_0X06_Device.MinVoltageSingleBatteryNo = 0x09;
            jTNE_0X02_0X06_Device.MinVoltageSingleBatteryValue = 0x08;
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x06_Device, jTNE_0X02_0X06_Device);

            JTNE_0x02_0x07_Device jTNE_0X02_0X07_Device = new JTNE_0x02_0x07_Device();
            jTNE_0X02_0X07_Device.AlarmBatteryFlag = 5533;
            jTNE_0X02_0X07_Device.AlarmLevel = 0x11;
            jTNE_0X02_0X07_Device.AlarmBatteryOthers = new List<uint>
            {
                1000,1001,1002
            };
            jTNE_0X02_0X07_Device.AlarmEls = new List<uint>
            {
                2000,2001,2002
            };
            jTNE_0X02_0X07_Device.AlarmEngines = new List<uint>
            {
                3000,3001,3002
            };
            jTNE_0X02_0X07_Device.AlarmOthers = new List<uint>
            {
                4000,4001,4002
            };
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x07_Device, jTNE_0X02_0X07_Device);

            JTNE_0x02_0x08_Device jTNE_0X02_0X08_Device = new JTNE_0x02_0x08_Device();
            jTNE_0X02_0X08_Device.BatteryAssemblies = new List<Metadata.BatteryAssembly>();
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
            jTNE_0X02_0X08_Device.BatteryAssemblies.Add(batteryAssembly1);
            jTNE_0X02_0X08_Device.BatteryAssemblies.Add(batteryAssembly2);
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x08_Device, jTNE_0X02_0X08_Device);


            JTNE_0x02_0x09_Device jTNE_0X02_0X09_Device = new JTNE_0x02_0x09_Device();
            jTNE_0X02_0X09_Device.BatteryTemperatures = new List<Metadata.BatteryTemperature>();

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

            jTNE_0X02_0X09_Device.BatteryTemperatures.Add(batteryTemperature1);
            jTNE_0X02_0X09_Device.BatteryTemperatures.Add(batteryTemperature2);
            jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x09_Device, jTNE_0X02_0X09_Device);

            jTNEPackage_Device.Bodies = jTNE_0X02_Device;
            var hex = JTNESerializer_Device.Serialize(jTNEPackage_Device).ToHexString();
            Assert.Equal("2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867", hex);
        }

        [Fact]
        public void Test2()
        {
            var data = "2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867".ToHexBytes();
            JTNEPackage_Device jTNEPackage_Device = JTNESerializer_Device.Deserialize(data);
            JTNE_0x02_Device jTNE_0X02_Device = jTNEPackage_Device.Bodies as JTNE_0x02_Device;

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

            JTNE_0x02_0x04_Device jTNE_0X02_0X04_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x04_Device] as JTNE_0x02_0x04_Device;
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x04_Device, jTNE_0X02_0X04_Device.TypeCode);
            Assert.Equal(0x01, jTNE_0X02_0X04_Device.EngineStatus);
            Assert.Equal(102, jTNE_0X02_0X04_Device.FuelRate);
            Assert.Equal(203, jTNE_0X02_0X04_Device.Revs);

            JTNE_0x02_0x05_Device jTNE_0X02_0X05_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x05_Device] as JTNE_0x02_0x05_Device;
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x05_Device, jTNE_0X02_0X05_Device.TypeCode);
            Assert.Equal((uint)1233355, jTNE_0X02_0X05_Device.Lat);
            Assert.Equal((uint)3255555, jTNE_0X02_0X05_Device.Lng);
            Assert.Equal(0x01, jTNE_0X02_0X05_Device.PositioStatus);


            JTNE_0x02_0x06_Device jTNE_0X02_0X06_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x06_Device] as JTNE_0x02_0x06_Device;
            Assert.Equal(0x12, jTNE_0X02_0X06_Device.MaxTempBatteryAssemblyNo);
            Assert.Equal(0x32, jTNE_0X02_0X06_Device.MaxTempProbeBatteryNo);
            Assert.Equal(0x42, jTNE_0X02_0X06_Device.MaxTempProbeBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Device.MaxVoltageBatteryAssemblyNo);
            Assert.Equal(0x15, jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryNo);
            Assert.Equal(123, jTNE_0X02_0X06_Device.MaxVoltageSingleBatteryValue);
            Assert.Equal(0x11, jTNE_0X02_0X06_Device.MinTempProbeBatteryNo);
            Assert.Equal(0x06, jTNE_0X02_0X06_Device.MinTempProbeBatteryValue);
            Assert.Equal(0x07, jTNE_0X02_0X06_Device.MinVoltageBatteryAssemblyNo);
            Assert.Equal(0x09, jTNE_0X02_0X06_Device.MinVoltageSingleBatteryNo);
            Assert.Equal(0x08, jTNE_0X02_0X06_Device.MinVoltageSingleBatteryValue);

            JTNE_0x02_0x07_Device jTNE_0X02_0X07_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x07_Device] as JTNE_0x02_0x07_Device;
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x07_Device, jTNE_0X02_0X07_Device.TypeCode);
            Assert.Equal(0x11, jTNE_0X02_0X07_Device.AlarmLevel);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmBatteryOthers.Count);
            Assert.Equal(new List<uint>
            {
                1000,1001,1002
            }, jTNE_0X02_0X07_Device.AlarmBatteryOthers);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmEls.Count);
            Assert.Equal(new List<uint>
            {
                2000,2001,2002
            }, jTNE_0X02_0X07_Device.AlarmEls);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmEngines.Count);
            Assert.Equal(new List<uint>
            {
                3000,3001,3002
            }, jTNE_0X02_0X07_Device.AlarmEngines);
            Assert.Equal(3, jTNE_0X02_0X07_Device.AlarmOthers.Count);
            Assert.Equal(new List<uint>
            {
                4000,4001,4002
            }, jTNE_0X02_0X07_Device.AlarmOthers);

            JTNE_0x02_0x08_Device jTNE_0X02_0X08_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x08_Device] as JTNE_0x02_0x08_Device;
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x08_Device, jTNE_0X02_0X08_Device.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X08_Device.BatteryAssemblyCount);

            Metadata.BatteryAssembly batteryAssembly1 = jTNE_0X02_0X08_Device.BatteryAssemblies[0];
            Assert.Equal(123, batteryAssembly1.BatteryAssemblyCurrent);
            Assert.Equal(0x01, batteryAssembly1.BatteryAssemblyNo);
            Assert.Equal(0x02, batteryAssembly1.BatteryAssemblyVoltage);
            Assert.Equal(55, batteryAssembly1.SingleBatteryCount);
            Assert.Equal(111, batteryAssembly1.ThisSingleBatteryBeginNo);
            Assert.Equal(3, batteryAssembly1.ThisSingleBatteryBeginCount);
            Assert.Equal(new List<ushort> {
                111,222,333
            }, batteryAssembly1.SingleBatteryVoltages);

            Metadata.BatteryAssembly batteryAssembly2 = jTNE_0X02_0X08_Device.BatteryAssemblies[1];
            Assert.Equal(1234, batteryAssembly2.BatteryAssemblyCurrent);
            Assert.Equal(0x03, batteryAssembly2.BatteryAssemblyNo);
            Assert.Equal(0x05, batteryAssembly2.BatteryAssemblyVoltage);
            Assert.Equal(66, batteryAssembly2.SingleBatteryCount);
            Assert.Equal(222, batteryAssembly2.ThisSingleBatteryBeginNo);
            Assert.Equal(3, batteryAssembly2.ThisSingleBatteryBeginCount);
            Assert.Equal(new List<ushort> {
                444,555,666
            }, batteryAssembly2.SingleBatteryVoltages);

            JTNE_0x02_0x09_Device jTNE_0X02_0X09_Device = jTNE_0X02_Device.Values[JTNE_0x02_Body_Device.JTNE_0x02_0x09_Device] as JTNE_0x02_0x09_Device;
            Assert.Equal(JTNE_0x02_Body_Device.JTNE_0x02_0x09_Device, jTNE_0X02_0X09_Device.TypeCode);
            Assert.Equal(2, jTNE_0X02_0X09_Device.BatteryTemperatureCount);

            Metadata.BatteryTemperature batteryTemperature1 = jTNE_0X02_0X09_Device.BatteryTemperatures[0];
            Assert.Equal(0x01, batteryTemperature1.BatteryAssemblyNo);
            Assert.Equal(4, batteryTemperature1.TemperatureProbeCount);
            Assert.Equal(new byte[]
            {
                0x01,0x02,0x03,0x04
            }, batteryTemperature1.Temperatures);

            Metadata.BatteryTemperature batteryTemperature2 = jTNE_0X02_0X09_Device.BatteryTemperatures[1];
            Assert.Equal(0x02, batteryTemperature2.BatteryAssemblyNo);
            Assert.Equal(4, batteryTemperature2.TemperatureProbeCount);
            Assert.Equal(new byte[]
            {
                0x05,0x06,0x07,0x08
            }, batteryTemperature2.Temperatures);
        }
    }
}
