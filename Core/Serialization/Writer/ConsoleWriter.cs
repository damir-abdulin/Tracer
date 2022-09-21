using System;

namespace Core.Serialization.Writer
{
    internal class ConsoleWriter : IResultWriter
    {
        void IResultWriter.Write(string result)
        {
            Console.WriteLine(result);
        }

    }
}
