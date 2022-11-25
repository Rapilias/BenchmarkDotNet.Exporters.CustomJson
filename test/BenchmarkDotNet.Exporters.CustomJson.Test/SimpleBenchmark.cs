using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet.Exporters.CustomJson.Test
{
    [JsonExporter]
    public class SimpleBuiltinJsonBenchmark
    {
        [Benchmark]
        public static void A()
        {
        }
    }

    [CustomJson]
    public class SimpleCustomJsonBenchmark
    {
        [Benchmark]
        public static void A()
        {
        }
    }
}