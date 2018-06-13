using System;
using System.Collections.Generic;
using System.Text;

namespace GBNewEnergy.Protocol.Enums
{
    /// <summary>
    /// 信息类型标志
    /// </summary>
    public enum NEInfoType:byte
    {
        整车数据=0x01,
        驱动电机数据=0x02,
        燃料电池数据=0x03,
        发动机数据=0x04,
        车辆位置数据=0x05,
        极值数据=0x06,
        报警数据=0x07,
        终端数据预留=0x08,
        平台交换协议自定义数据=0x0A,
        预留=0x30,
        用户自定义=0x80
    }
}
