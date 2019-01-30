# JTNewEnergy协议

[![MIT Licence](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SmallChi/JTNewEnergy/blob/master/LICENSE)[![Build Status](https://travis-ci.org/SmallChi/JTNewEnergy.svg?branch=master)](https://travis-ci.org/SmallChi/JTNewEnergy)


## 前提条件

1. 掌握进制转换：二进制转十六进制；
2. 掌握BCD编码、Hex编码；
3. 掌握各种位移、异或；
4. 掌握常用反射；
5. 掌握快速ctrl+c、ctrl+v；
6. 掌握以上装逼技能，就可以开始搬砖了。

## JTNewEnergy数据结构解析

### 数据包[JTNEPackage]

| 起始标识1|起始标识2 | 命令标识 | 应答标志 | 车辆识别码 | 数据加密方式 |数据单元长度| 数据体|校验码|
| :---------:| :---------: | :---------: | :-------: | :-------: |:-------: |:-------: |:-------: |:-------:|
| BeginFlag1 | BeginFlag2 | MsgId | AskId | VIN |EncryptMethod|DataUnitLength|JTNEBodies|BCCCode|
| 0x23(#)      | 0x23(#)      | - | - | - |- |- |- |- |

#### 消息体属性[JTNEBodies]

> 根据对应消息ID：MsgId

### 举个栗子1

#### 1.组包：

> MsgId 0x02:实时信息上报

``` package
JTNEPackage jTNEPackage = new JTNEPackage();
//消息头
jTNEPackage.AskId = JTNEAskId.Success.ToByteValue();
jTNEPackage.MsgId = JTNEMsgId.uploadim.ToByteValue();
jTNEPackage.VIN = "123456789";
//消息体
JTNE_0x02 jTNE_0X02 = new JTNE_0x02();
jTNE_0X02.Values = new Dictionary<byte, JTNE_0x02_Body>();
//整车数据
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
//驱动电机数据
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
//燃料电池数据
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
//发动机数据
JTNE_0x02_0x04 jTNE_0X02_0X04 = new JTNE_0x02_0x04();
jTNE_0X02_0X04.EngineStatus = 0x01;
jTNE_0X02_0X04.FuelRate = 102;
jTNE_0X02_0X04.Revs = 203;
jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x04, jTNE_0X02_0X04);
//车辆位置数据
JTNE_0x02_0x05 jTNE_0X02_0X05 = new JTNE_0x02_0x05();
jTNE_0X02_0X05.Lat = 1233355;
jTNE_0X02_0X05.Lng = 3255555;
jTNE_0X02_0X05.PositioStatus = 0x01;
jTNE_0X02.Values.Add(JTNE_0x02_Body.JTNE_0x02_0x05, jTNE_0X02_0X05);
//极值数据
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
//报警数据
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
//可充电储能装置电压数据
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

//可充电储能装置温度数据
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

// 输出结果Hex：
2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867
```

#### 2.手动解包：
``` unpackage
1.原包：
2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867

2.拆解
23 23                         --起始符
02                            --命令标识
01                            --应答标志 
31 32 33 34 35 36 37 38 
39 00 00 00 00 00 00 00 00    --VIN
01                            --数据加密方式
00 D0                         --数据单元长度

01                            --整车数据
04 05 07 00 3A 00 00 1A 
0A 00 64 00 63 03 06 02 
00 7B 02 03 
02                            --驱动电机数据 
02 01 02 01 00 41 00 37 
03 00 EC 00 64 02 03 02 
00 42 02 36 05 08 58 00 65
03                            --燃料电池数据
08 AE 00 6F 0C 96 00 03 
01 02 03 0D 1B 22 1A 0A 
56 0D 08 65 02 
04                            --发动机数据
01 00 CB 00 66 
05                            --车辆位置数据
01 00 31 AD 03 00 12 D1 
CB
06                            --极值数据
11 15 00 7B 07 09 00 08 
32 12 42 11 32 06 
07                            --报警数据
11 00 00 15 9D 03 00 00 
03 E8 00 00 03 E9 00 00 
03 EA 03 00 00 07 D0 00 
00 07 D1 00 00 07 D2 03 
00 00 0B B8 00 00 0B B9 
00 00 0B BA 03 00 00 0F 
A0 00 00 0F A1 00 00 0F 
A2
08                            --可充电储能装置电压数据
02 01 00 02 00 7B 00 37 
00 6F 03 00 6F 00 DE 01
4D 03 00 05 04 D2 00 42
00 DE 03 01 BC 02 2B 02 9A 
09                            --可充电储能装置温度数据
02 01 00 04 01 02 03 04 
02 00 04 05 06 07 08 

67                            --校验位

```

#### 3.程序解包：
``` unpackage1
1.原包：
string data="2323020131323334353637383900000000000000000100D001040507003A00001A0A00640063030602007B02030202010201004100370300EC00640203020042023605085800650308AE006F0C9600030102030D1B221A0A560D086502040100CB006605010031AD030012D1CB061115007B0709000832124211320607110000159D03000003E8000003E9000003EA03000007D0000007D1000007D20300000BB800000BB900000BBA0300000FA000000FA100000FA20802010002007B0037006F03006F00DE014D03000504D2004200DE0301BC022B029A0902010004010203040200040506070867";

2.将原包反序列化
JTNEPackage jTNEPackage = JTNESerializer.Deserialize(data);
JTNE_0x02 jTNE_0X02 = jTNEPackage.Bodies as JTNE_0x02;

//整车数据
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

//驱动电机数据
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

//燃料电池数据
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

//发动机数据
JTNE_0x02_0x04 jTNE_0X02_0X04 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x04] as JTNE_0x02_0x04;
Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x04, jTNE_0X02_0X04.TypeCode);
Assert.Equal(0x01, jTNE_0X02_0X04.EngineStatus);
Assert.Equal(102, jTNE_0X02_0X04.FuelRate);
Assert.Equal(203, jTNE_0X02_0X04.Revs);

//车辆位置数据
JTNE_0x02_0x05 jTNE_0X02_0X05 = jTNE_0X02.Values[JTNE_0x02_Body.JTNE_0x02_0x05] as JTNE_0x02_0x05;
Assert.Equal(JTNE_0x02_Body.JTNE_0x02_0x05, jTNE_0X02_0X05.TypeCode);
Assert.Equal((uint)1233355, jTNE_0X02_0X05.Lat);
Assert.Equal((uint)3255555, jTNE_0X02_0X05.Lng);
Assert.Equal(0x01, jTNE_0X02_0X05.PositioStatus);

//极值数据
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

//报警数据
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

//可充电储能装置电压数据
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

//可充电储能装置温度数据
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

```

### 举个栗子2
``` create package
// 使用消息Id的扩展方法创建JTNEPackage包
JTNEPackage jTNEPackage= JTNEMsgId.login.Create("123456789", JTNEAskId.CMD, new JTNE_0x01
{
    PDATime = DateTime.Parse("2019-01-22 23:55:56"),
    LoginNum = 1,
    BatteryLength = 0x04,
    SIM = "12345678998765432100",
    BatteryNos = new List<string>()
    {
       "1234",
       "4567",
       "9870"
    }
});
var hex = JTNESerializer.Serialize(jTNEPackage).ToHexString();
//输出结果Hex：
232301FE313233343536373839000000000000000001002A130116173738000131323334353637383939383736353433323130300304313233343435363739383730FD
```
### 举个栗子3
``` config
// 全局配置
JTNEGlobalConfig.Instance
    //.SetDeviceMsgSNDistributed(//todo 实现IDeviceMsgSNDistributed设备流水号)
    //.SetPlatformMsgSNDistributed(//todo 实现IPlatformMsgSNDistributed平台流水号)
    //.SetDataBodiesEncrypt(//todo 实现IJTNEEncrypt消息数据体加密算法)
    //.SetPlatformLoginEncrypt(//todo 实现IJTNEEncrypt平台登入加密算法)
    // 注册自定义车载终端控制命令
    //.Register_JTNE0x82CustomBody(//todo 继承自JTNE_0x82_Body类)
    // 注册自定义实时信息上报信息
    //.Register_JTNE0x02CustomBody(//todo 继承自JTNE_0x02_CustomBody类)
    // 若为终端设置命令，则自定义终端设置命令，若为参数查询响应命令，则为自定义参数查询响应命令
    //.Register_JTNE0x81CustomBody(//todo 继承自JTNE_0x81_Body类)
    // 若为终端设置命令，则自定义终端设置命令依赖对象，若为参数查询响应命令，则为自定义参数查询响应命令依赖对象
    //.Register_JTNE0x81CustomDepenedBody("依赖对象消息id","被依赖对象消息id")
    // 跳过校验码验证
    .SetSkipCRCCode(true);
```
## NuGet安装

| Package Name |  Version | Downloads
|--------------|  ------- | ----
| Install-Package JTNewEnergy | ![JTNewEnergy](https://img.shields.io/nuget/v/JTNewEnergy.svg) | ![JTNewEnergy](https://img.shields.io/nuget/dt/JTNewEnergy.svg)

## 使用BenchmarkDotNet性能测试报告（只是玩玩，不能当真）

``` ini
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.472 (1803/April2018Update/Redstone4)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3260.0
  Job-FVMQGI : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3260.0
  Job-LGLQDK : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

Platform=AnyCpu  Runtime=Clr  Server=False  

```
|                Method |     Toolchain |      N |         Mean |      Error |     StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------------------- |-------------- |------- |-------------:|-----------:|-----------:|------------:|------------:|------------:|--------------------:|
|   **JTNE_0x02_Serialize** |       **Default** |    **100** |     **5.997 ms** |  **0.0704 ms** |  **0.0659 ms** |    **156.2500** |           **-** |           **-** |          **1000.83 KB** |
| JTNE_0x02_Deserialize |       Default |    100 |     5.713 ms |  0.0654 ms |  0.0611 ms |    140.6250 |           - |           - |           906.31 KB |
|   JTNE_0x02_Serialize | .NET Core 2.2 |    100 |     5.003 ms |  0.0706 ms |  0.0660 ms |    140.6250 |           - |           - |           878.13 KB |
| JTNE_0x02_Deserialize | .NET Core 2.2 |    100 |     4.591 ms |  0.0876 ms |  0.0899 ms |    125.0000 |           - |           - |           780.47 KB |
|   **JTNE_0x02_Serialize** |       **Default** |  **10000** |   **621.248 ms** | **12.0181 ms** | **11.8034 ms** |  **16000.0000** |           **-** |           **-** |        **100081.45 KB** |
| JTNE_0x02_Deserialize |       Default |  10000 |   569.567 ms |  9.4221 ms |  8.8135 ms |  14000.0000 |           - |           - |         90629.45 KB |
|   JTNE_0x02_Serialize | .NET Core 2.2 |  10000 |   509.149 ms |  9.9488 ms |  9.3061 ms |  14000.0000 |           - |           - |          87812.5 KB |
| JTNE_0x02_Deserialize | .NET Core 2.2 |  10000 |   457.481 ms |  8.6865 ms |  8.9204 ms |  12000.0000 |           - |           - |         78046.88 KB |
|   **JTNE_0x02_Serialize** |       **Default** | **100000** | **6,038.592 ms** | **37.8782 ms** | **35.4313 ms** | **162000.0000** |   **1000.0000** |           **-** |       **1000795.95 KB** |
| JTNE_0x02_Deserialize |       Default | 100000 | 5,676.756 ms | 51.2919 ms | 47.9785 ms | 147000.0000 |   1000.0000 |           - |        906264.57 KB |
|   JTNE_0x02_Serialize | .NET Core 2.2 | 100000 | 5,112.387 ms | 66.7348 ms | 59.1586 ms | 142000.0000 |   1000.0000 |           - |           878125 KB |
| JTNE_0x02_Deserialize | .NET Core 2.2 | 100000 | 4,469.358 ms | 20.2586 ms | 15.8166 ms | 127000.0000 |   1000.0000 |           - |        780468.75 KB |

## JTNewEnergy终端通讯协议消息对照表

| 序号  | 消息ID        | 完成情况 | 测试情况 | 消息体名称                     |
| :---: | :-----------: | :------: | :------: | :----------------------------: |
| 1     | 0x01        | √        | √        | 车辆登入                   |
| 2     | 0x02        | √        | √        | 实时信息上传               |
| 3     | 0x03        | √        | √        | 补传信息上传               |
| 4     | 0x04        | √        | √        | 车辆登出                   |
| 5     | 0x05        | √        | √        | 平台登入                   |
| 6     | 0x06        | √        | √        | 平台登出                   |
| 7     | 0x07        | √        | √        | 心跳                      |
| 8     | 0x08        | √        | √        | 终端校时                  |
| 9     | 0x09~0x7F   | -        | -        | 上行数据系统预留           |
| 10    | 0x80        | √        | √        | 查询命令                  |
| 11    | 0x81        | √        | √        | 设置命令                  |
| 12    | 0x82        | √        | √        | 车载终端控制命令           |
| 13    | 0x83~0xBF   | -        | -        | 下行数据系统预留           |
| 14    | 0xC0~0xFE   | -        | -        | 平台交换自定义数据         |
