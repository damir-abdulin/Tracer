using System.IO;

namespace Core.Serialization.Writer
{
    internal class FileWriter : IResultWriter
    {
        private string _destination;
        public FileWriter(string destination)
        {
            _destination = destination;
        }

        void IResultWriter.Write(string result)
        {
            using (StreamWriter writer = new StreamWriter(_destination, false))
            {
                writer.WriteLine(result);
            }
        }
    }
}
