using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JTNE.Protocol.Extensions;
using JTNE.Protocol.Formatters;
using JTNE.Protocol.Attributes;

namespace JTNE.Protocol.Test.MessageBody
{
    public class JTNE_0x02_CustomBody_DeviceTest
    {

        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA1, typeof(JTNE_0x02_0xA1_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA2, typeof(JTNE_0x02_0xA2_Device));

            JTNE_0x02_Device jTNE_0X02_Device = new JTNE_0x02_Device();
            jTNE_0X02_Device.CusotmSerializeObjectValues = new Dictionary<byte, JTNE_0x02_CustomBody_Device>();

            JTNE_0x02_0xA1_Device jTNE_0X02_0XA1_Device = new JTNE_0x02_0xA1_Device();
            jTNE_0X02_0XA1_Device.UserName = "SmallChi";
            jTNE_0X02_0XA1_Device.Age = 18;
            jTNE_0X02_Device.CusotmSerializeObjectValues.Add(0xA1, jTNE_0X02_0XA1_Device);

            JTNE_0x02_0xA2_Device jTNE_0X02_0XA2_Device = new JTNE_0x02_0xA2_Device();
            jTNE_0X02_0XA2_Device.CompanyName = "小池有限公司";
            jTNE_0X02_Device.CusotmSerializeObjectValues.Add(0xA2, jTNE_0X02_0XA2_Device);

            var hex = JTNESerializer_Device.Serialize(jTNE_0X02_Device).ToHexString();
            Assert.Equal("A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000", hex);
        }

        [Fact]
        public void Test2()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA1, typeof(JTNE_0x02_0xA1_Device));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Device(0xA2, typeof(JTNE_0x02_0xA2_Device));

            var data = "A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000".ToHexBytes();
            JTNE_0x02_Device jTNE_0X02_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_Device>(data);
            Assert.Empty(jTNE_0X02_Device.Values);

            JTNE_0x02_0xA1_Device jTNE_0X02_0XA1_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0xA1_Device>(jTNE_0X02_Device.CusotmValues[0xA1]);
            Assert.Equal(0xA1, jTNE_0X02_0XA1_Device.TypeCode);
            Assert.Equal(14, jTNE_0X02_0XA1_Device.Length);
            Assert.Equal("SmallChi", jTNE_0X02_0XA1_Device.UserName);
            Assert.Equal(18, jTNE_0X02_0XA1_Device.Age);

            JTNE_0x02_0xA2_Device jTNE_0X02_0XA2_Device = JTNESerializer_Device.Deserialize<JTNE_0x02_0xA2_Device>(jTNE_0X02_Device.CusotmValues[0xA2]);
            Assert.Equal(0xA2, jTNE_0X02_0XA2_Device.TypeCode);
            Assert.Equal(20, jTNE_0X02_0XA2_Device.Length);
            Assert.Equal("小池有限公司", jTNE_0X02_0XA2_Device.CompanyName);
        }
    }

    /// <summary>
    ///自定义0xA1消息
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0xA1_Device_Formatter))]
    public class JTNE_0x02_0xA1_Device : JTNE_0x02_CustomBody_Device
    {
        public override ushort Length { get; set; } = 14;

        public override byte TypeCode { get; set; } = 0xA1;

        public string UserName { get; set; }

        public ushort Age { get; set; }
    }

    /// <summary>
    ///自定义0xA2消息
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0xA2_Device_Formatter))]
    public class JTNE_0x02_0xA2_Device : JTNE_0x02_CustomBody_Device
    {
        public override ushort Length { get; set; } = 20;

        public override byte TypeCode { get; set; } = 0xA2;

        public string CompanyName { get; set; }
    }

    /// <summary>
    /// 自定义0xA1消息序列化器
    /// </summary>
    public class JTNE_0x02_0xA1_Device_Formatter : IJTNEFormatter<JTNE_0x02_0xA1_Device>
    {
        public JTNE_0x02_0xA1_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0xA1_Device jTNE_0X02_0XA1_Device = new JTNE_0x02_0xA1_Device();
            jTNE_0X02_0XA1_Device.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0XA1_Device.Length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0XA1_Device.UserName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset,12);
            jTNE_0X02_0XA1_Device.Age = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0XA1_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0xA1_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Length);
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.UserName,12);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Age);
            return offset;
        }
    }
    /// <summary>
    /// 自定义0xA2消息序列化器
    /// </summary>
    public class JTNE_0x02_0xA2_Device_Formatter : IJTNEFormatter<JTNE_0x02_0xA2_Device>
    {
        public JTNE_0x02_0xA2_Device Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0xA2_Device jTNE_0X02_0XA2_Device = new JTNE_0x02_0xA2_Device();
            jTNE_0X02_0XA2_Device.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0XA2_Device.Length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0XA2_Device.CompanyName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            readSize = offset;
            return jTNE_0X02_0XA2_Device;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0xA2_Device value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Length);
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.CompanyName, 20);
            return offset;
        }
    }

}
