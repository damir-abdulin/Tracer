using System.IO;
using System.Xml.Serialization;

namespace Core.Serialization.Xml
{
    public class XmlTraceSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(Result.TraceResult value)
        {
            var traceResult = new TraceResult(value);

            XmlSerializer xmlSerializer = new XmlSerializer(traceResult.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, traceResult);
                return textWriter.ToString();
            }
        }
    }
}
