using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Result
{
    public class ThreadInfo
    {
        public int ThreadId { get; }
        public long Milliseconds { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        public ThreadInfo(int id, IReadOnlyList<MethodInfo> methods)
        {
            ThreadId = id;
            Methods = methods;

            Milliseconds = methods.Sum(method => method.Milliseconds);
        }
    }
}
