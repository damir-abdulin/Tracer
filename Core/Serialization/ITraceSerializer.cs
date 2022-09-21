using Core.Result;

namespace Core.Serialization
{
    public interface ITraceSerializer
    {
        string Serialize(TraceResult value);
    }
}
