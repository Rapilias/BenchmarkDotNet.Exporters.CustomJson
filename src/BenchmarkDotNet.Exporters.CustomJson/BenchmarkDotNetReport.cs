using System;
using System.Collections.Generic;

namespace BenchmarkDotNet.Exporters.CustomJson
{
    public class BenchmarkDotNetReport
    {
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; } // Additional
        public HostEnvironmentInfo HostEnvironmentInfo { get; set; }
        public List<Benchmark> Benchmarks { get; set; }
    }

    public class Benchmark
    {
        public string DisplayInfo { get; set; }
        public string Namespace { get; set; }
        public string Type { get; set; }
        public string Method { get; set; }
        public string MethodTitle { get; set; }
        public string Parameters { get; set; }
        public string FullName { get; set; }
        public string HardwareIntrinsics { get; set; }
        public string RuntimeMoniker { get; set; } // Additional
        public string MsBuildMoniker { get; set; } // Additional
        public bool IsAOT { get; set; } // Additional
        public Statistics Statistics { get; set; }
        public List<Measurement> Measurements { get; set; }
    }

    public class ChronometerFrequency
    {
        public double Hertz { get; set; }
    }

    public class ConfidenceInterval
    {
        public int N { get; set; }
        public double Mean { get; set; }
        public double StandardError { get; set; }
        public int Level { get; set; }
        public double Margin { get; set; }
        public double Lower { get; set; }
        public double Upper { get; set; }
    }

    public class HostEnvironmentInfo
    {
        public string BenchmarkDotNetCaption { get; set; }
        public string BenchmarkDotNetVersion { get; set; }
        public string OsVersion { get; set; }
        public string ProcessorName { get; set; }
        public int PhysicalProcessorCount { get; set; }
        public int PhysicalCoreCount { get; set; }
        public int LogicalCoreCount { get; set; }
        public string RuntimeVersion { get; set; }
        public string Architecture { get; set; }
        public bool HasAttachedDebugger { get; set; }
        public bool HasRyuJit { get; set; }
        public string Configuration { get; set; }
        public string DotNetCliVersion { get; set; }
        public ChronometerFrequency ChronometerFrequency { get; set; }
        public string HardwareTimerKind { get; set; }
    }

    public class Measurement
    {
        public string IterationMode { get; set; }
        public string IterationStage { get; set; }
        public int LaunchIndex { get; set; }
        public int IterationIndex { get; set; }
        public int Operations { get; set; }
        public int Nanoseconds { get; set; }
    }

    public class Percentiles
    {
        public double P0 { get; set; }
        public double P25 { get; set; }
        public double P50 { get; set; }
        public double P67 { get; set; }
        public double P80 { get; set; }
        public double P85 { get; set; }
        public double P90 { get; set; }
        public double P95 { get; set; }
        public double P100 { get; set; }
    }

    public class Statistics
    {
        public List<double> OriginalValues { get; set; }
        public int N { get; set; }
        public double Min { get; set; }
        public double LowerFence { get; set; }
        public double Q1 { get; set; }
        public double Median { get; set; }
        public double Mean { get; set; }
        public double Q3 { get; set; }
        public double UpperFence { get; set; }
        public double Max { get; set; }
        public double InterquartileRange { get; set; }
        public List<double> LowerOutliers { get; set; }
        public List<object> UpperOutliers { get; set; }
        public List<double> AllOutliers { get; set; }
        public double StandardError { get; set; }
        public double Variance { get; set; }
        public double StandardDeviation { get; set; }
        public double Skewness { get; set; }
        public double Kurtosis { get; set; }
        public ConfidenceInterval ConfidenceInterval { get; set; }
        public Percentiles Percentiles { get; set; }
    }
}