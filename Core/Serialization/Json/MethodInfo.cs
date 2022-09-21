using System.Collections.Generic;

namespace Core.Serialization.Json
{
    public class MethodInfo
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string Time { get; set; }
        public List<MethodInfo> Methods { get; set; } = new List<MethodInfo>();

        public MethodInfo() { }
        public MethodInfo(Result.MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            TypeName = methodInfo.TypeName;
            Time = $"{methodInfo.Milliseconds}ms";

            foreach (var method in methodInfo.Methods)
            {
                Methods.Add(new MethodInfo(method));
            }

        }
    }
}
