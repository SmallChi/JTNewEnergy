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
    public class JTNE_0x02_CustomBody_PlatformTest
    {

        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Platform(0xA1, typeof(JTNE_0x02_0xA1_Platform));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Platform(0xA2, typeof(JTNE_0x02_0xA2_Platform));

            JTNE_0x02_Platform jTNE_0X02_Platform = new JTNE_0x02_Platform();
            jTNE_0X02_Platform.CusotmSerializeObjectValues = new Dictionary<byte, JTNE_0x02_CustomBody_Platform>();

            JTNE_0x02_0xA1_Platform jTNE_0X02_0XA1_Platform = new JTNE_0x02_0xA1_Platform();
            jTNE_0X02_0XA1_Platform.UserName = "SmallChi";
            jTNE_0X02_0XA1_Platform.Age = 18;
            jTNE_0X02_Platform.CusotmSerializeObjectValues.Add(0xA1, jTNE_0X02_0XA1_Platform);

            JTNE_0x02_0xA2_Platform jTNE_0X02_0XA2_Platform = new JTNE_0x02_0xA2_Platform();
            jTNE_0X02_0XA2_Platform.CompanyName = "小池有限公司";
            jTNE_0X02_Platform.CusotmSerializeObjectValues.Add(0xA2, jTNE_0X02_0XA2_Platform);

            var hex = JTNESerializer_Platform.Serialize(jTNE_0X02_Platform).ToHexString();
            Assert.Equal("A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000", hex);
        }

        [Fact]
        public void Test2()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Platform(0xA1, typeof(JTNE_0x02_0xA1_Platform));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody_Platform(0xA2, typeof(JTNE_0x02_0xA2_Platform));

            var data = "A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000".ToHexBytes();
            JTNE_0x02_Platform jTNE_0X02_Platform = JTNESerializer_Platform.Deserialize<JTNE_0x02_Platform>(data);
            Assert.Empty(jTNE_0X02_Platform.Values);

            JTNE_0x02_0xA1_Platform jTNE_0X02_0XA1_Platform = JTNESerializer_Device.Deserialize<JTNE_0x02_0xA1_Platform>(jTNE_0X02_Platform.CusotmValues[0xA1]);
            Assert.Equal(0xA1, jTNE_0X02_0XA1_Platform.TypeCode);
            Assert.Equal(14, jTNE_0X02_0XA1_Platform.Length);
            Assert.Equal("SmallChi", jTNE_0X02_0XA1_Platform.UserName);
            Assert.Equal(18, jTNE_0X02_0XA1_Platform.Age);

            JTNE_0x02_0xA2_Platform jTNE_0X02_0XA2_Platform = JTNESerializer_Device.Deserialize<JTNE_0x02_0xA2_Platform>(jTNE_0X02_Platform.CusotmValues[0xA2]);
            Assert.Equal(0xA2, jTNE_0X02_0XA2_Platform.TypeCode);
            Assert.Equal(20, jTNE_0X02_0XA2_Platform.Length);
            Assert.Equal("小池有限公司", jTNE_0X02_0XA2_Platform.CompanyName);
        }
    }

    /// <summary>
    ///自定义0xA1消息
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0xA1_Platform_Formatter))]
    public class JTNE_0x02_0xA1_Platform : JTNE_0x02_CustomBody_Platform
    {
        public override ushort Length { get; set; } = 14;

        public override byte TypeCode { get; set; } = 0xA1;

        public string UserName { get; set; }

        public ushort Age { get; set; }
    }

    /// <summary>
    ///自定义0xA2消息
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0xA2_Platform_Formatter))]
    public class JTNE_0x02_0xA2_Platform : JTNE_0x02_CustomBody_Platform
    {
        public override ushort Length { get; set; } = 20;

        public override byte TypeCode { get; set; } = 0xA2;

        public string CompanyName { get; set; }
    }

    /// <summary>
    /// 自定义0xA1消息序列化器
    /// </summary>
    public class JTNE_0x02_0xA1_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0xA1_Platform>
    {
        public JTNE_0x02_0xA1_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0xA1_Platform jTNE_0X02_0XA1_Platform = new JTNE_0x02_0xA1_Platform();
            jTNE_0X02_0XA1_Platform.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0XA1_Platform.Length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0XA1_Platform.UserName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset,12);
            jTNE_0X02_0XA1_Platform.Age = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0XA1_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0xA1_Platform value)
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
    public class JTNE_0x02_0xA2_Platform_Formatter : IJTNEFormatter<JTNE_0x02_0xA2_Platform>
    {
        public JTNE_0x02_0xA2_Platform Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0xA2_Platform jTNE_0X02_0XA2_Platform = new JTNE_0x02_0xA2_Platform();
            jTNE_0X02_0XA2_Platform.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0XA2_Platform.Length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0XA2_Platform.CompanyName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            readSize = offset;
            return jTNE_0X02_0XA2_Platform;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0xA2_Platform value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Length);
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.CompanyName, 20);
            return offset;
        }
    }

}
