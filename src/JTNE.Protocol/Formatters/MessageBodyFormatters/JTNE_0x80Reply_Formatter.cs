using JTNE.Protocol.Extensions;
using JTNE.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JTNE.Protocol.Formatters.MessageBodyFormatters
{
    public class JTNE_0x80Reply_Formatter : IJTNEFormatter<JTNE_0x80Reply>
    {
        public JTNE_0x80Reply Deserialize(ReadOnlySpan<byte> bytes, out int readSize)
        {
            int offset = 0;
            JTNE_0x80Reply jTNE_0x80Reply = new JTNE_0x80Reply();
            jTNE_0x80Reply.ReplyTime = JTNEBinaryExtensions.ReadDateTime6Little(bytes, ref offset);
            jTNE_0x80Reply.ParamNum = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);
            for (int i = 0; i < jTNE_0x80Reply.ParamNum; i++)
            {
                var paramId = JTNEBinaryExtensions.ReadByteLittle(bytes, ref offset);//参数ID         
                int readSubBodySize = 0;
                if (JTNE_0x80Reply_Body.JTNE_0x80ReplyMethod.TryGetValue(paramId, out Type type))
                {
                    ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>();
                    if (JTNE_0x80Reply_Body.JTNE_0x80ReplyLengthOfADependOnValueOfB.TryGetValue(paramId, out byte dependOnParamId)) {
                        var length = jTNE_0x80Reply.ParamList.FirstOrDefault(m => m.ParamId== dependOnParamId).ParamLength;
                        int tempOffset = 0;
                        int lengthVal = JTNEBinaryExtensions.ReadByteLittle(bytes.Slice(offset - length - 1, length), ref tempOffset);
                        readOnlySpan = bytes.Slice(offset, lengthVal);
                    }
                    else {
                        readOnlySpan = bytes.Slice(offset);
                    }
                    if (jTNE_0x80Reply.ParamList != null)
                    {
                        jTNE_0x80Reply.ParamList.Add(JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(JTNEFormatterExtensions.GetFormatter(type), readOnlySpan, out readSubBodySize));
                    }
                    else
                    {
                        jTNE_0x80Reply.ParamList = new List<JTNE_0x80Reply_Body> { JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(JTNEFormatterExtensions.GetFormatter(type), readOnlySpan, out readSubBodySize) };
                    }
                }
                offset = offset + readSubBodySize;
            }
            readSize = offset;
            return jTNE_0x80Reply;
        }

        public int Serialize(ref byte[] bytes, int offset, JTNE_0x80Reply value)
        {
            offset += JTNEBinaryExtensions.WriteDateTime6Little(bytes, offset, value.ReplyTime);
            offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, value.ParamNum);
            foreach (var item in value.ParamList)
            {
                offset += JTNEBinaryExtensions.WriteByteLittle(bytes, offset, item.ParamId);
                object obj = JTNEFormatterExtensions.GetFormatter(item.GetType());
                offset = JTNEFormatterResolverExtensions.JTNEDynamicSerialize(obj, ref bytes, offset, item);
            }
            return offset;
        }
    }
}
