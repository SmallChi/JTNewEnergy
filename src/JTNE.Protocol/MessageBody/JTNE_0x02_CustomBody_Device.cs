using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 自定义类型数据体
    /// </summary>
    public abstract class JTNE_0x02_CustomBody_Device: JTNE_0x02_Body_Device
    {
        /// <summary>
        /// 自定义数据长度
        /// </summary>
        public abstract ushort Length { get; set; }

        static JTNE_0x02_CustomBody_Device()
        {
            CustomTypeCodes = new Dictionary<byte, Type>();
        }
        /// <summary>
        /// 自定义类型编码
        /// </summary>
        internal static Dictionary<byte, Type> CustomTypeCodes;
    }
}
