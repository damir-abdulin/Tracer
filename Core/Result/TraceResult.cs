using System.Collections.Generic;

namespace Result
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
