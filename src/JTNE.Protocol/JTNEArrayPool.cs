using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace JTNE.Protocol
{
    internal static class JTNEArrayPool
    {
        private readonly static ArrayPool<byte> ArrayPool;

        static JTNEArrayPool()
        {
            ArrayPool = ArrayPool<byte>.Create();
        }

        public static byte[] Rent(int minimumLength)
        {
            return ArrayPool.Rent(minimumLength);
        }

        public static void Return(byte[] array, bool clearArray = false)
        {
             ArrayPool.Return(array, clearArray);
        }
    }
}
