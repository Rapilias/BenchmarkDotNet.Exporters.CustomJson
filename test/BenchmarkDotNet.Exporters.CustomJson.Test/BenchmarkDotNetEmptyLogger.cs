using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Loggers;

namespace BenchmarkDotNet.Exporters.CustomJson.Test
{
    public class BenchmarkDotNetEmptyLogger : ILogger
    {
        public string Id => nameof(BenchmarkDotNetEmptyLogger);
        public int Priority { get; }

        public void Flush()
        {
        }

        public void Write(LogKind logKind, string text)
        {
        }

        public void WriteLine()
        {
        }

        public void WriteLine(LogKind logKind, string text)
        {
        }
    }
}