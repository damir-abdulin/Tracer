using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Serialization.Writer
{
    public interface IResultWriter
    {
        void Write(string result);
    }
}
