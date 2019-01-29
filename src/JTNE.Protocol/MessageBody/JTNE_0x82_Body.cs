using JTNE.Protocol.Attributes;
using JTNE.Protocol.Formatters.MessageBodyFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol.MessageBody
{
    /// <summary>
    /// 参数查询
    /// </summary>
    public class  JTNE_0x82_Body
    {
        /// <summary>
        /// 未用
        /// </summary>
        public const byte JTNE_0x82_0x00_Type = 0x00;
        /// <summary>
        /// 远程升级：根据需要组合升级参数，参数之间用半角分号分割。
        /// 指令如下：“URL地址;拨号点名称;拨号用户名;拨号密码;地址;端口;生产厂商代码
        ///  ;硬件版本;固件版本;连接到升级服务器时限"
        ///   如某个参数无值，则为空
        ///   远程升级操作建议但不限于采用FTP方式进行操作，数据定义见表B.16
        /// </summary>
        public const byte JTNE_0x82_0x01_Type = 0x01;
        /// <summary>
        /// 车载终端关机
        /// </summary>
        public const byte JTNE_0x82_0x02_Type = 0x02;
        /// <summary>
        /// 车载终端复位
        /// </summary>
        public const byte JTNE_0x82_0x03_Type = 0x03;
        /// <summary>
        /// 车载终端恢复出厂设置，其中包括本地存储时间周期，信息上报时间周期，心跳发送时间周期，终端应答超时时间等
        /// </summary>
        public const byte JTNE_0x82_0x04_Type = 0x04;
        /// <summary>
        /// 断开数据通信链路
        /// </summary>
        public const byte JTNE_0x82_0x05_Type = 0x05;
        /// <summary>
        /// 车载终端报警
        ///  报警命令参数数据格式和定义见表B.17
        /// </summary>
        public const byte JTNE_0x82_0x06_Type = 0x06;
        /// <summary>
        /// 开启抽样监测链路
        /// </summary>
        public const byte JTNE_0x82_0x07_Type = 0x07;
     

        public static IDictionary<byte, Type> JTNE_0x82Method { get; private set; }
        /// <summary>
        /// 参数 ID
        /// </summary>
        public virtual byte ParamId { get; set; }

        /// <summary>
        /// 参数长度
        /// </summary>
        public virtual byte ParamLength { get; set; }

        static JTNE_0x82_Body()
        {
            JTNE_0x82Method = new Dictionary<byte, Type>();
            JTNE_0x82Method.Add(JTNE_0x82_0x01_Type, typeof(JTNE_0x82_0x01));
            JTNE_0x82Method.Add(JTNE_0x82_0x06_Type, typeof(JTNE_0x82_0x06));
        }

        internal static void AddJTNE_0x82Method(byte paramId, Type type)
        {
            if (!JTNE_0x82Method.ContainsKey(paramId))
            {
                JTNE_0x82Method.Add(paramId, type);
            }
            else
            {
                JTNE_0x82Method[paramId] = type;
            }
        }
    }
}
