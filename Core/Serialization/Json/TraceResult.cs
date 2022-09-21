using System.Collections.Generic;

namespace Core.Serialization.Json
{
    public class TraceResult
    {
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
