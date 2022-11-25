using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using WellKnownGeometrySharp.Benchmark.Utility;
using Xunit;

namespace BenchmarkDotNet.Exporters.CustomJson.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var config = BenchmarkDotNetLiteConfig
                .CreateQuietConfig()
                .AddExporter(new CustomJsonExporter(true, true))
                .AddJobs(isFastRun: true);
            var summary = BenchmarkRunner.Run<SimpleBuiltinJsonBenchmark>(config);
            Assert.True(true);
        }

        [Fact]
        public void Test2()
        {
            var config = BenchmarkDotNetLiteConfig
                .CreateQuietConfig()
                .AddExporter(new CustomJsonExporter(true, true))
                .AddJobs(isFastRun: true);
            var summary = BenchmarkRunner.Run<SimpleCustomJsonBenchmark>(config);
            Assert.True(true);
        }
    }
}