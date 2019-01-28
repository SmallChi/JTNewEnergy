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