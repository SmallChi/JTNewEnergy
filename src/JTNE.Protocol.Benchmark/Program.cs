using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;

namespace JTNE.Protocol.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<JTNESerializerContext>();
        }
    }
}
