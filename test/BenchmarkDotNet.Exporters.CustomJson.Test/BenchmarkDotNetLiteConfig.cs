using System.Linq;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters.CustomJson.Test;
using BenchmarkDotNet.Jobs;
using Perfolizer.Horology;

namespace WellKnownGeometrySharp.Benchmark.Utility
{
    internal static class BenchmarkDotNetLiteConfig
    {
        public static Job WithFastRun(this Job job)
        {
            return job
                .WithIterationCount(1)
                .WithMaxWarmupCount(2)
                .WithMinWarmupCount(2)
                .WithEvaluateOverhead(false)
                .WithIterationTime(TimeInterval.FromSeconds(0.1))
                .WithLaunchCount(1);
        }

        public static IConfig CreateQuietConfig()
        {
            var config = ManualConfig.CreateEmpty();
            config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
            config.AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
            config.AddDiagnoser(DefaultConfig.Instance.GetDiagnosers().ToArray());
            config.AddAnalyser(DefaultConfig.Instance.GetAnalysers().ToArray());
            config.AddValidator(DefaultConfig.Instance.GetValidators().ToArray());
            config.AddHardwareCounters(DefaultConfig.Instance.GetHardwareCounters().ToArray());
            config.AddLogicalGroupRules(DefaultConfig.Instance.GetLogicalGroupRules().ToArray());
            config.AddFilter(DefaultConfig.Instance.GetFilters().ToArray());
            config.AddLogger(new BenchmarkDotNetEmptyLogger());

            config.ArtifactsPath = DefaultConfig.Instance.ArtifactsPath;
            config.CultureInfo = DefaultConfig.Instance.CultureInfo;
            config.Options = DefaultConfig.Instance.Options;
            config.Orderer = DefaultConfig.Instance.Orderer;
            config.SummaryStyle = DefaultConfig.Instance.SummaryStyle;
            config.UnionRule = DefaultConfig.Instance.UnionRule;

            return config;
        }

        public static IConfig AddJobs(this IConfig config, bool isFastRun)
        {
            config = config
                .AddJob(
                    Job.Default
                        .WithRuntime(CoreRuntime.Core31)
                        .ApplyFastRun(isFastRun)
                )
                .AddJob(
                    Job.Default
                        .WithRuntime(CoreRuntime.Core60)
                        .ApplyFastRun(isFastRun)
                );
            return config;
        }

        public static Job ApplyFastRun(this Job job, bool use)
        {
            if (use == true)
            {
                return job.WithFastRun();
            }
            return job;
        }
    }
}