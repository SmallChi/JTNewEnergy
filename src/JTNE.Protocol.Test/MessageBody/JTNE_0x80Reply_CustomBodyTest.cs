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
    public class JTNE_0x80Reply_CustomBodyTest
    {
        [Fact]
        public void Test1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x80, typeof(JTNE_0x80Reply_0x80));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x81, typeof(JTNE_0x80Reply_0x81));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomDepenedBody(0x81, 0x80);

            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            JTNE_0x81 jTNE_0X81 = new JTNE_0x81 {
                 OperateTime= DateTime.Parse("2019-01-22 23:55:56"),
                  ParamNum=2,
                ParamList = new List<JTNE_0x81_Body> {
                new JTNE_0x80Reply_0x80{
                       ParamValue=6
                },
                new JTNE_0x80Reply_0x81{
                     ParamLength=6,
                      ParamValue=new byte[]{ 1,2,3,4,5,6 }
                }
            }
            };
            jTNE_0x80Reply.JTNE_Reply0x80 = jTNE_0X81;
            var hex = JTNESerializer.Serialize(jTNE_0x80Reply).ToHexString();
            Assert.Equal("13011617373802800681010203040506", hex);
        }
        [Fact]
        public void Test1_1()
        {
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x80, typeof(JTNE_0x80Reply_0x80));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomBody(0x81, typeof(JTNE_0x80Reply_0x81));
            JTNEGlobalConfigs.Instance.Register_JTNE0x81CustomDepenedBody(0x81, 0x80);

            var data = "13011617373802800681010203040506".ToHexBytes();
            JTNE_0x80Reply jTNE_0x80Reply = JTNESerializer.Deserialize<JTNE_0x80Reply>(data);
            Assert.Equal(DateTime.Parse("2019-01-22 23:55:56"), jTNE_0x80Reply.JTNE_Reply0x80.OperateTime);
            Assert.Equal(jTNE_0x80Reply.JTNE_Reply0x80.ParamList.Count, jTNE_0x80Reply.JTNE_Reply0x80.ParamNum);
            Assert.Equal(Newtonsoft.Json.JsonConvert.SerializeObject(new List<JTNE_0x81_Body> {
               new JTNE_0x80Reply_0x80{
                       ParamValue=6
                },
                new JTNE_0x80Reply_0x81{
                     ParamLength=6,
                      ParamValue=new byte[]{ 1,2,3,4,5,6 }
                }
            }), Newtonsoft.Json.JsonConvert.SerializeObject(jTNE_0x80Reply.JTNE_Reply0x80.ParamList));
        }
    }
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x80Formatter))]
    public class JTNE_0x80Reply_0x80 : JTNE_0x81_Body
    {
        public override byte ParamId { get; set; }= 0x80;
        public override byte ParamLength { get; set; } = 1;
        public byte ParamValue { get; set; }
    }
    [JTNEFormatter(typeof(JTNE_0x80Reply_0x81Formatter))]
    public class JTNE_0x80Reply_0x81 : JTNE_0x81_Body
    {
        public override byte ParamId { get; set; } = 0x81;
        public override byte ParamLength { get; set; }
        public byte[] ParamValue { get; set; }
    }

    public class JTNE_0x80Reply_0x80Formatter : IJTNEFormatter<JTNE_0x80Reply_0x80>
    {
        public JTNE_0x80Reply_0x80 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x80 jTNE_0x80Reply_0x80 = new JTNE_0x80Reply_0x80();
            jTNE_0x80Reply_0x80.ParamValue = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            readSize = offset;
            return jTNE_0x80Reply_0x80;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x80 value)
        {
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
    public class JTNE_0x80Reply_0x81Formatter : IJTNEFormatter<JTNE_0x80Reply_0x81>
    {
        public JTNE_0x80Reply_0x81 Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply_0x81 jTNE_0x80Reply_0x80Reply = new JTNE_0x80Reply_0x81();
            jTNE_0x80Reply_0x80Reply.ParamValue = JTNEBinaryExtensions.ReadBytesLittle(bytes, ref offset);
            jTNE_0x80Reply_0x80Reply.ParamLength = (byte)bytes.Length;
            readSize = offset;
            return jTNE_0x80Reply_0x80Reply;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply_0x81 value)
        {
            offset += JTNEBinaryExtensions.WriteBytesLittle(bytes, offset, value.ParamValue);
            return offset;
        }
    }
}
