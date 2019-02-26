using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using JTNE.Protocol.Enums;

namespace JTNE.Protocol.Benchmark
{
    [Config(typeof(JTNESerializerConfig))]
    [MemoryDiagnoser]
    public class JTNESerializerContext
    {
        private byte[] bytes;

        [Params(100, 10000, 100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            bytes = "2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867".ToHexBytes();
        }

        [Benchmark(Description = "JTNE_0x02_Device_Serialize")]
        public void JTNE_0x02_Serialize()
        {
            for (int i = 0; i < N; i++)
            {
                JTNEPackage_Device jTNEPackage = new JTNEPackage_Device();
                jTNEPackage.AskId = JTNEAskId.Success.ToByteValue();
                jTNEPackage.MsgId = JTNEMsgId_Device.uploadim.ToByteValue();
                jTNEPackage.VIN = "123456789";
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
                jTNE_0X02_0X02_Device.Electricals = new List<JTNE.Protocol.Metadata.Electrical>();
                JTNE.Protocol.Metadata.Electrical electrical1 = new JTNE.Protocol.Metadata.Electrical();
                electrical1.ElControlTemp = 0x01;
                electrical1.ElCurrent = 100;
                electrical1.ElNo = 0x01;
                electrical1.ElSpeed = 65;
                electrical1.ElStatus = 0x02;
                electrical1.ElTemp = 0x03;
                electrical1.ElTorque = 55;
                electrical1.ElVoltage = 236;
                JTNE.Protocol.Metadata.Electrical electrical2 = new JTNE.Protocol.Metadata.Electrical();
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
                jTNE_0X02_0X08_Device.BatteryAssemblies = new List<JTNE.Protocol.Metadata.BatteryAssembly>();
                JTNE.Protocol.Metadata.BatteryAssembly batteryAssembly1 = new JTNE.Protocol.Metadata.BatteryAssembly();
                batteryAssembly1.BatteryAssemblyCurrent = 123;
                batteryAssembly1.BatteryAssemblyNo = 0x01;
                batteryAssembly1.BatteryAssemblyVoltage = 0x02;
                batteryAssembly1.SingleBatteryCount = 55;
                batteryAssembly1.ThisSingleBatteryBeginCount = 0x02;
                batteryAssembly1.ThisSingleBatteryBeginNo = 111;
                batteryAssembly1.SingleBatteryVoltages = new List<ushort> {
                111,222,333
            };
                JTNE.Protocol.Metadata.BatteryAssembly batteryAssembly2 = new JTNE.Protocol.Metadata.BatteryAssembly();
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
                jTNE_0X02_0X09_Device.BatteryTemperatures = new List<JTNE.Protocol.Metadata.BatteryTemperature>();

                JTNE.Protocol.Metadata.BatteryTemperature batteryTemperature1 = new JTNE.Protocol.Metadata.BatteryTemperature();
                batteryTemperature1.BatteryAssemblyNo = 0x01;
                batteryTemperature1.Temperatures = new byte[]
                {
                0x01,0x02,0x03,0x04
                };

                JTNE.Protocol.Metadata.BatteryTemperature batteryTemperature2 = new JTNE.Protocol.Metadata.BatteryTemperature();
                batteryTemperature2.BatteryAssemblyNo = 0x02;
                batteryTemperature2.Temperatures = new byte[]
                {
                0x05,0x06,0x07,0x08
                };

                jTNE_0X02_0X09_Device.BatteryTemperatures.Add(batteryTemperature1);
                jTNE_0X02_0X09_Device.BatteryTemperatures.Add(batteryTemperature2);
                jTNE_0X02_Device.Values.Add(JTNE_0x02_Body_Device.JTNE_0x02_0x09_Device, jTNE_0X02_0X09_Device);

                jTNEPackage.Bodies = jTNE_0X02_Device;

                var hex = JTNESerializer_Device.Serialize(jTNEPackage);
            }
        }

        [Benchmark(Description = "JTNE_0x02_Deserialize")]
        public void JTNE_0x02_Deserialize()
        {
            for (int i = 0; i < N; i++)
            {
                JTNEPackage_Device jTNEPackage = JTNESerializer_Device.Deserialize(bytes);
            }
        }
    }

    public class JTNESerializerConfig : ManualConfig
    {
        public JTNESerializerConfig()
        {
            Add(Job.Default.WithGcServer(false).With(Runtime.Clr).With(Platform.AnyCpu));
            Add(Job.Default.WithGcServer(false).With(CsProjCoreToolchain.NetCoreApp22).With(Platform.AnyCpu));
        }
    }
}
