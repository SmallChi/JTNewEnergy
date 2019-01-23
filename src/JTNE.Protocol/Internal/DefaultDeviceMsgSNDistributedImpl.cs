using JTNE.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JTNE.Protocol.Internal
{
    internal class DefaultDeviceMsgSNDistributedImpl : IDeviceMsgSNDistributed
    {
        int _counter = 0;

        public ushort Increment()
        {
            return (ushort)Interlocked.Increment(ref _counter);
        }
    }
}
