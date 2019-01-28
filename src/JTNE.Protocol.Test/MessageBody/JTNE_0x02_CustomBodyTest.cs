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
    public class JTNE_0x02_CustomBodyTest
    {

        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA1, typeof(JTNE_0x02_0xA1));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA2, typeof(JTNE_0x02_0xA2));

            JTNE_0x02 jTNE_0X02 = new JTNE_0x02();
            jTNE_0X02.CusotmSerializeObjectValues = new Dictionary<byte, JTNE_0x02_CustomBody>();

            JTNE_0x02_0xA1 jTNE_0X02_0XA1 = new JTNE_0x02_0xA1();
            jTNE_0X02_0XA1.UserName = "SmallChi";
            jTNE_0X02_0XA1.Age = 18;
            jTNE_0X02.CusotmSerializeObjectValues.Add(0xA1, jTNE_0X02_0XA1);

            JTNE_0x02_0xA2 jTNE_0X02_0XA2 = new JTNE_0x02_0xA2();
            jTNE_0X02_0XA2.CompanyName = "小池有限公司";
            jTNE_0X02.CusotmSerializeObjectValues.Add(0xA2, jTNE_0X02_0XA2);

            var hex = JTNESerializer.Serialize(jTNE_0X02).ToHexString();
            Assert.Equal("A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000", hex);
        }

        [Fact]
        public void Test2()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA1, typeof(JTNE_0x02_0xA1));
            JTNEGlobalConfigs.Instance.Register_JTNE0x02CustomBody(0xA2, typeof(JTNE_0x02_0xA2));

            var data = "A1000E536D616C6C436869000000000012A20014E5B08FE6B1A0E69C89E99990E585ACE58FB80000".ToHexBytes();
            JTNE_0x02 jTNE_0X02 = JTNESerializer.Deserialize<JTNE_0x02>(data);
            Assert.Empty(jTNE_0X02.Values);

            JTNE_0x02_0xA1 jTNE_0X02_0XA1 = JTNESerializer.Deserialize<JTNE_0x02_0xA1>(jTNE_0X02.CusotmValues[0xA1]);
            Assert.Equal(0xA1, jTNE_0X02_0XA1.TypeCode);
            Assert.Equal(14, jTNE_0X02_0XA1.Length);
            Assert.Equal("SmallChi", jTNE_0X02_0XA1.UserName);
            Assert.Equal(18, jTNE_0X02_0XA1.Age);

            JTNE_0x02_0xA2 jTNE_0X02_0XA2 = JTNESerializer.Deserialize<JTNE_0x02_0xA2>(jTNE_0X02.CusotmValues[0xA2]);
            Assert.Equal(0xA2, jTNE_0X02_0XA2.TypeCode);
            Assert.Equal(20, jTNE_0X02_0XA2.Length);
            Assert.Equal("小池有限公司", jTNE_0X02_0XA2.CompanyName);
        }
    }

    /// <summary>
    ///自定义0xA1消息
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0xA1_Formatter))]
    public class JTNE_0x02_0xA1: JTNE_0x02_CustomBody
    {
        public override ushort Length { get; set; } = 14;

        public override byte TypeCode { get; set; } = 0xA1;

        public string UserName { get; set; }

        public ushort Age { get; set; }
    }

    /// <summary>
    ///自定义0xA2消息
    /// </summary>
    [JTNEFormatter(typeof(JTNE_0x02_0xA2_Formatter))]
    public class JTNE_0x02_0xA2 : JTNE_0x02_CustomBody
    {
        public override ushort Length { get; set; } = 20;

        public override byte TypeCode { get; set; } = 0xA2;

        public string CompanyName { get; set; }
    }

    /// <summary>
    /// 自定义0xA1消息序列化器
    /// </summary>
    public class JTNE_0x02_0xA1_Formatter : IJTNEFormatter<JTNE_0x02_0xA1>
    {
        public JTNE_0x02_0xA1 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0xA1 jTNE_0X02_0XA1 = new JTNE_0x02_0xA1();
            jTNE_0X02_0XA1.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0XA1.Length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0XA1.UserName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset,12);
            jTNE_0X02_0XA1.Age = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            readSize = offset;
            return jTNE_0X02_0XA1;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0xA1 value)
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
    public class JTNE_0x02_0xA2_Formatter : IJTNEFormatter<JTNE_0x02_0xA2>
    {
        public JTNE_0x02_0xA2 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x02_0xA2 jTNE_0X02_0XA2 = new JTNE_0x02_0xA2();
            jTNE_0X02_0XA2.TypeCode = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            jTNE_0X02_0XA2.Length = JTNEBinaryExtensions.ReadUInt16Little(bytes, ref offset);
            jTNE_0X02_0XA2.CompanyName = JTNEBinaryExtensions.ReadStringLittle(bytes, ref offset, 20);
            readSize = offset;
            return jTNE_0X02_0XA2;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x02_0xA2 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.TypeCode);
            offset += JTNEBinaryExtensions.WriteUInt16Little(bytes, offset, value.Length);
            offset += JTNEBinaryExtensions.WriteStringLittle(bytes, offset, value.CompanyName, 20);
            return offset;
        }
    }

}
