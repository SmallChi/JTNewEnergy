using GBNewEnergy.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.UpStream
{
    /// <summary>
    /// 车辆登入
    /// </summary>
    public class NELoginUpStream : NEBodies
    {
        public NELoginUpStream(byte[] buffer) : base(buffer)
        {
            CurrentDateTime = buffer.ReadDateTimeLittle(0, 6);
            LoginNum = buffer.ReadUShortH2LLittle(6, 2);
            SIM = buffer.ReadStringLittle(8, 20);
            BatteryCount = buffer[28];
            BatteryLength = buffer[29];
            List<string> batteryNos = new List<string>();
            for (int i = 0; i < BatteryCount; i++)
            {
                batteryNos.Add(buffer.ReadStringLittle(i * BatteryLength + 30, BatteryLength));
            }
            BatteryNos = batteryNos;
        }

        public NELoginUpStream(string vin, string sim, byte batteryCount, byte batteryLength, IEnumerable<string> batteryNos) : base(vin)
        {
            if (LoginNumDict.ContainsKey(vin))
            {
                (ushort LoginNum, DateTime ExpirationTime) temp;
                if (LoginNumDict.TryGetValue(vin, out temp))
                {
                    // 不等于当天
                    if (temp.ExpirationTime != DateTime.Now.Date)
                    {
                        LoginNum = 1;
                        LoginNumDict.TryUpdate(vin, (LoginNum, DateTime.Now.Date), temp);
                    }
                    else
                    {// 自增1 更新字典
                        LoginNum = temp.LoginNum++;
                        LoginNumDict.TryUpdate(vin, (LoginNum, DateTime.Now.Date), temp);
                    }
                }
            }
            else
            {
                LoginNum = 1;
                LoginNumDict.TryAdd(vin, (LoginNum, DateTime.Now.Date));
            }
            SIM = sim;
            BatteryCount = batteryCount;
            BatteryLength = batteryLength;
            BatteryNos = batteryNos;
            ToBuffer();
        }

        /// <summary>
        /// SIM 卡号 
        /// </summary>
        public string SIM { get; set; }
        /// <summary>
        /// 电池总成数
        /// 可充电储能子系统数
        /// </summary>
        public byte BatteryCount { get; set; }
        /// <summary>
        /// 电池编码长度
        /// 可充电储能系统编码长度
        /// </summary>
        public byte BatteryLength { get; set; }
        /// <summary>
        /// 电池编码
        /// 可充电储能系统编码
        /// </summary>
        public IEnumerable<string> BatteryNos { get; set; }

        public override void ToBuffer()
        {
            // 根据协议说明书
            Buffer = new byte[6 + 2 + 20 + 1 + 1 + (BatteryCount * BatteryLength)];
            Buffer.WriteLittle(CurrentDateTime, 0, 6);
            Buffer.WriteLittle(LoginNum, 6, 2);
            Buffer.WriteLittle(SIM, 8);
            Buffer[28] = BatteryCount;
            Buffer[29] = BatteryLength;
            if ((BatteryCount * BatteryLength) != 0)
            {
                string str = string.Join("", BatteryNos);
                Buffer.WriteLittle(str, 30);
            }
        }
    }
}
