using System;
using System.Collections.Generic;
using System.Text;
using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using JTNE.Protocol.Metadata;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 车辆位置数据
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0x05_Platform_Formatter))]
    public class JTNE_0x02_0x05_Platform : JTNE_0x02_Body_Platform
    {
        public override byte TypeCode { get; set; } = JTNE_0x02_0x05_Platform;

        /// <summary>
        /// 定位状态
        /// 0位：0：有效定位；1：无效定位（当数据通信正常，而不能获取定位信息时，发送最后一次有效定位信息，并将定位状态置为无效。）
        /// 1位：0：北纬；1：南纬
        /// 2位：0：东经；1：西经
        /// 3-7位：保留
        /// </summary>
        public byte PositioStatus { get; set; }
        /// <summary>
        /// 经度
        /// 以度位单位的经度值乘以10^6，精确到百万分之一度
        /// </summary>
        public uint Lng { get; set; }
        /// <summary>
        /// 纬度
        /// 以度位单位的纬度值乘以10^6，精确到百万分之一度
        /// </summary>
        public uint Lat { get; set; }
    }
}
