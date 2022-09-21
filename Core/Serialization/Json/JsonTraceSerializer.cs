using System.Text.Json;

namespace Core.Serialization.Json
{
    public class JsonTraceSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(Result.TraceResult value)
        {
            var traceResult = new TraceResult(value);

            return JsonSerializer.Serialize(traceResult);
        }
    }
}
