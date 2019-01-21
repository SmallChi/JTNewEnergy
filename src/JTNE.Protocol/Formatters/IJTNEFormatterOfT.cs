using System;
using System.Buffers;

namespace JTNE.Protocol.Formatters
{
    public interface IJTNEFormatter<T> 
    {
        T Deserialize(ReadOnlySpan<byte> bytes,  out int readSize);

        int Serialize(ref byte[] bytes, int offset, T value);
    }
}
