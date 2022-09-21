using System;

namespace Core.Serialization.Writer
{
    public class ConsoleWriter : IResultWriter
    {
        void IResultWriter.Write(string result)
        {
            Console.WriteLine(result);
        }

    }
}
