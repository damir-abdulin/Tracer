using System.Collections.Generic;
using Core.Result;

namespace Core
{
    internal class BufferThreadInfo
    {
        public Stack<BufferMethodInfo> RunningMethods = new Stack<BufferMethodInfo>();

        public List<MethodInfo> Methods = new List<MethodInfo>();
    }
}
