using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Core.Serialization.Xml
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        [XmlElement(ElementName = "thread")]
        public List<ThreadInfo> Threads { get; set; } = new List<ThreadInfo>();

        public TraceResult() { }

        public TraceResult(Result.TraceResult traceResult)
        {
            foreach(var thread in traceResult.Threads)
            {
                Threads.Add(new ThreadInfo(thread));
            }
        }
    }
}
