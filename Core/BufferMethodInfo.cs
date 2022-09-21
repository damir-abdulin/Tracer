using System.Collections.Generic;
using System.Diagnostics;
using Core.Result;

namespace Core
{
    internal class BufferMethodInfo
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public Stopwatch Clock { get; set; } = new Stopwatch();

        public long Milliseconds { get; set; }

        public List<MethodInfo> Methods = new List<MethodInfo>();

        public void UpdateMilliseconds()
        {
            Milliseconds = Clock.ElapsedMilliseconds;
        }

     }
}
