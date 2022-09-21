using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Serialization.Json
{
    public class MethodInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("class")]
        public string TypeName { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }
        
        [JsonPropertyName("methods")]
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
