using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Core.Serialization.Xml
{
    public class ThreadInfo
    {
        [XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified)]
        public int ThreadId { get; set; }

        [XmlAttribute(AttributeName = "time", Form = XmlSchemaForm.Unqualified)]
        public string Milliseconds { get; set; }
        
        [XmlElement(ElementName = "method")]
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
