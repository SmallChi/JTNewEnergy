using JTNE.Protocol.Extensions;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("JTNE.Protocol.Test")]

namespace JTNE.Protocol
{
    /// <summary>
    /// 
    /// </summary>
    public static class JTNESerializer_Platform
    {
        public static byte[] Serialize(JTNEPackage_Platform jTNEPackage_Platform, int minBufferSize = 256)
        {
            return Serialize<JTNEPackage_Platform>(jTNEPackage_Platform, minBufferSize);
        }

        public static JTNEPackage_Platform Deserialize(ReadOnlySpan<byte> bytes)
        {
            return Deserialize<JTNEPackage_Platform>(bytes);
        }

        public static byte[] Serialize<T>(T obj, int minBufferSize = 256)
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
