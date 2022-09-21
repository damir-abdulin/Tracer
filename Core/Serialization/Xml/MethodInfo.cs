using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Core.Serialization.Xml
{
    public class MethodInfo
    {
        [XmlAttribute(AttributeName = "name", Form = XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "class", Form = XmlSchemaForm.Unqualified)]
        public string TypeName { get; set; }


        [XmlAttribute(AttributeName = "time", Form = XmlSchemaForm.Unqualified)]
        public string Time { get; set; }

        [XmlElement(ElementName = "method")]
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();

        public MethodInfo() { }
        public MethodInfo(Result.MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            TypeName = methodInfo.TypeName;
            Time = $"{methodInfo.Milliseconds}ms";
            
            foreach(var method in methodInfo.Methods)
            {
                Methods.Add(new MethodInfo(method));
            }

        }
    }
}
