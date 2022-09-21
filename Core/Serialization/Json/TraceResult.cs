using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Serialization.Json
{
    public class TraceResult
    {
        [JsonPropertyName("threads")]
        public List<ThreadInfo> Threads { get; set; } = new List<ThreadInfo>();

        public TraceResult() { }

        public TraceResult(Result.TraceResult traceResult)
        {
            foreach (var thread in traceResult.Threads)
            {
                Threads.Add(new ThreadInfo(thread));
            }
        }
    }
}
