using JTNE.Protocol.Extensions;
using System;

namespace JTNE.Protocol
{
    /// <summary>
    /// 
    /// </summary>
    public static class JTNESerializer
    {
        public static byte[] Serialize(JTNEPackage jTNEPackage, int minBufferSize = 1024)
        {
            return Serialize<JTNEPackage>(jTNEPackage, minBufferSize);
        }

        public static JTNEPackage Deserialize(ReadOnlySpan<byte> bytes)
        {
            return Deserialize<JTNEPackage>(bytes);
        }

        public static byte[] Serialize<T>(T obj, int minBufferSize = 1024)
        {
            var formatter = JTNEFormatterExtensions.GetFormatter<T>();
            byte[] buffer = JTNEArrayPool.Rent(minBufferSize);
            try
            {
                var len = formatter.Serialize(ref buffer, 0, obj);
                return buffer.AsSpan(0, len).ToArray();
            }
            finally
            {
                JTNEArrayPool.Return(buffer);
            }
        }

        public static T Deserialize<T>(ReadOnlySpan<byte> bytes)
        {
            var formatter = JTNEFormatterExtensions.GetFormatter<T>();
            int readSize;
            return formatter.Deserialize(bytes,out readSize);
        }

        public static dynamic Deserialize(ReadOnlySpan<byte> bytes,Type type)
        {
            var formatter = JTNEFormatterExtensions.GetFormatter(type);
            return JTNEFormatterResolverExtensions.JTNEDynamicDeserialize(formatter,bytes,out int readSize);
        }
    }
}
