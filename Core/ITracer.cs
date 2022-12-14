using Core.Result;

namespace Core
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();

        TraceResult GetTraceResult();

    }
}
