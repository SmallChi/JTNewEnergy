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
| 3     | 0x03        | x        | x        | 补传信息上传               |
| 4     | 0x04        | √        | √        | 车辆登出                   |
| 5     | 0x05        | √        | √        | 平台登入                   |
| 6     | 0x06        | √        | √        | 平台登出                   |
| 7     | 0x07        | √        | √        | 心跳                      |
| 8     | 0x08        | √        | √        | 终端校时                  |
| 9     | 0x09~0x7F   | -        | -        | 上行数据系统预留           |
| 10    | 0x80        | x        | x        | 查询命令                  |
| 11    | 0x81        | x        | x        | 设置命令                  |
| 12    | 0x82        | x        | x        | 车载终端控制命令           |
| 13    | 0x83~0xBF   | -        | -        | 下行数据系统预留           |
| 14    | 0xC0~0xFE   | -        | -        | 平台交换自定义数据         |