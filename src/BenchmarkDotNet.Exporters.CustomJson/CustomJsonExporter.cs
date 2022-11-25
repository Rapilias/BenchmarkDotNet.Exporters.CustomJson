using System;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using Newtonsoft.Json;

namespace BenchmarkDotNet.Exporters.CustomJson
{
    public class CustomJsonExporter : JsonExporterBase
    {
        protected Type targetType = typeof(BenchmarkDotNetReport);
        private readonly Formatting JsonIndentFormat;

        public CustomJsonExporter(bool indentJson, bool excludeMesurements, Type targetType = null) : base(indentJson, excludeMesurements)
        {
            this.JsonIndentFormat = indentJson ? Formatting.Indented : Formatting.None;
            this.targetType = targetType;
            this.targetType ??= typeof(BenchmarkDotNetReport);
        }

        public override void ExportToLog(Summary summary, ILogger logger)
        {
            var createdAt = DateTime.Now;
            var officialJsonData = this.GetDataToSerialize(summary);
            var officialJson = JsonConvert.SerializeObject(officialJsonData, Formatting.None);
            var report = JsonConvert.DeserializeObject(officialJson, this.targetType) as BenchmarkDotNetReport;
            report.CreatedAt = createdAt;

            foreach (var item in summary.BenchmarksCases)
            {
                var runtime = item.GetRuntime();
                var targetBenchmark = report.Benchmarks.Find(m => m.DisplayInfo == item.DisplayInfo);
                targetBenchmark.RuntimeMoniker = runtime.RuntimeMoniker.ToString();
                targetBenchmark.MsBuildMoniker = runtime.MsBuildMoniker;
                targetBenchmark.IsAOT = runtime.IsAOT;
            }
            var resultJson = JsonConvert.SerializeObject(report, this.JsonIndentFormat);
            logger.WriteLine(resultJson);
        }
    }
}