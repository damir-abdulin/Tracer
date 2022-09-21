using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using Core.Result;

namespace Core
{
    public class Tracer : ITracer
    {
        private ConcurrentDictionary<int, BufferThreadInfo> _threads;

        public Tracer()
        {
            _threads = new ConcurrentDictionary<int, BufferThreadInfo>();
        }

        TraceResult ITracer.GetTraceResult()
        {
            List<ThreadInfo> threads = new List<ThreadInfo>();

            foreach (var threadId in _threads.Keys)
            {
                threads.Add(new ThreadInfo(threadId, _threads[threadId].Methods));
            }

            return new TraceResult(threads);
        }

        void ITracer.StartTrace()
        {
            int threadId = Environment.CurrentManagedThreadId;
            _threads.GetOrAdd(threadId, new BufferThreadInfo());

            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();

            BufferMethodInfo methodInfo = new BufferMethodInfo();
            methodInfo.Name = method.Name;
            methodInfo.TypeName = method.DeclaringType.Name;
            methodInfo.Clock.Start();

            _threads[threadId].RunningMethods.Push(methodInfo);
        }

        void ITracer.StopTrace()
        {
            int threadId = Environment.CurrentManagedThreadId;
            var bufferMethodInfo = _threads[threadId].RunningMethods.Pop();

            bufferMethodInfo.Clock.Stop();
            bufferMethodInfo.UpdateMilliseconds();

            var methodInfo = new MethodInfo(bufferMethodInfo.Name, bufferMethodInfo.TypeName,
                                            bufferMethodInfo.Milliseconds, bufferMethodInfo.Methods);
            
            if (_threads[threadId].RunningMethods.Count == 0)
            { 
                _threads[threadId].Methods.Add(methodInfo);
            }
            else
            {
                _threads[threadId].RunningMethods.Peek().Methods.Add(methodInfo);
            }
        }
    }
}
