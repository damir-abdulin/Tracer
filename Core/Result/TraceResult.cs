using System.Collections.Generic;

namespace Core.Result
{
    public class TraceResult
    {
        public IReadOnlyList<ThreadInfo> Threads { get; }

        public TraceResult(IReadOnlyList<ThreadInfo> threads)
        {
            Threads = threads;
        }
    }
}
