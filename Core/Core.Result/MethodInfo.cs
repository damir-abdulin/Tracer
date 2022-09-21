using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Result
{
    public class MethodInfo
    {
        public string Name { get; }
        public string TypeName { get; }
        public long Milliseconds { get; }
        public IReadOnlyList<MethodInfo> Methods { get; }

        public MethodInfo(string name, string typeName, long milliseconds, IReadOnlyList<MethodInfo> methods)
        {
            Name = name;
            TypeName = typeName;
            Milliseconds = milliseconds;
            Methods = methods;
        }
    }
}
