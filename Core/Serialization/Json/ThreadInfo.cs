using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Serialization.Json
{
    public class ThreadInfo
    {
        [JsonPropertyName("id")]
        public int ThreadId { get; set; }

        [JsonPropertyName("time")]
        public string Milliseconds { get; set; }

        [JsonPropertyName("methods")]
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
