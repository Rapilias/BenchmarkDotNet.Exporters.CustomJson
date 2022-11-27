// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.CustomJson;
using BenchmarkDotNet.Running;


var config = BenchmarkDotNet.Configs.DefaultConfig.Instance;
var summary = BenchmarkRunner.Run<SimpleBuiltinJsonBenchmark>(config);
var summary2 = BenchmarkRunner.Run<SimpleCustomJsonBenchmark>(config);

[JsonExporter]
public class SimpleBuiltinJsonBenchmark
{
    [Benchmark]
    public void A()
    {
    }
}

[CustomJson]
public class SimpleCustomJsonBenchmark
{
    [Benchmark]
    public void A()
    {
    }
}
