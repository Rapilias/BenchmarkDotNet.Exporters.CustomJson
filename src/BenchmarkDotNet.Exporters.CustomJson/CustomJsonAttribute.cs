using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet.Exporters.CustomJson
{
    public class CustomJsonAttribute : ExporterConfigBaseAttribute
    {
        public CustomJsonAttribute() : base(new CustomJsonExporter(true, true)) { }
    }
}