using System.Collections.Generic;

namespace Core.Serialization.Json
{
    public class ThreadInfo
    {

        public int ThreadId { get; set; }
        public string Milliseconds { get; set; }
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();

        public ThreadInfo() { }
        public ThreadInfo(Result.ThreadInfo threadInfo)
        {
            ThreadId = threadInfo.ThreadId;
            Milliseconds = $"{threadInfo.Milliseconds}ms";

            foreach (var method in threadInfo.Methods)
            {
                Methods.Add(new MethodInfo(method));
            }
        }
    }
}
