using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    public abstract class JTNE_0x02_Body
    {
        public abstract byte TypeCode { get; set; }

        /// <summary>
        /// 整车数据
        /// </summary>
        public const byte JTNE_0x02_0x01 = 0x01;
        /// <summary>
        /// 驱动电机数据
        /// </summary>
        public const byte JTNE_0x02_0x02 = 0x02;

        static JTNE_0x02_Body()
        {
// todo:实时位置信息上报
            Keys = new Dictionary<byte, Type>();
            Keys.Add(JTNE_0x02_0x01, typeof(JTNE_0x02_0x01));

        }

        internal static Dictionary<byte, Type> Keys;


    }
}
