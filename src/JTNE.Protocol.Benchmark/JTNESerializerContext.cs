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

        [Benchmark(Description = "JTNE_0x02_Serialize")]
        public void JTNE_0x02_Serialize()
        {
            for (int i = 0; i < N; i++)
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
                jTNE_0X02_0X02.Electricals = new List<JTNE.Protocol.Metadata.Electrical>();
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
                jTNE_0X02_0X08.BatteryAssemblies = new List<JTNE.Protocol.Metadata.BatteryAssembly>();
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
                jTNE_0X02_0X08.BatteryAssemblies.Add(batteryAssembly1);
                jTNE_0X02_0X08.BatteryAssemblies.Add(batteryAssembly2);
                jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x08, jTNE_0X02_0X08);


                JTNE_0x02_0x09 jTNE_0X02_0X09 = new JTNE_0x02_0x09();
                jTNE_0X02_0X09.BatteryTemperatures = new List<JTNE.Protocol.Metadata.BatteryTemperature>();

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

                jTNE_0X02_0X09.BatteryTemperatures.Add(batteryTemperature1);
                jTNE_0X02_0X09.BatteryTemperatures.Add(batteryTemperature2);
                jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x09, jTNE_0X02_0X09);

                jTNEPackage.Bodies = jTNE_0X02;

                var hex = JTNESerializer.Serialize(jTNEPackage);
            }
        }

        [Benchmark(Description = "JTNE_0x02_Deserialize")]
        public void JTNE_0x02_Deserialize()
        {
            for (int i = 0; i < N; i++)
            {
                JTNEPackage jTNEPackage = JTNESerializer.Deserialize(bytes);
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
