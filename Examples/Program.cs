using System.Threading.Tasks;
using Core;
using Core.Serialization;
using Core.Serialization.Xml;

namespace Examples
{
    internal class Program
    {
        public delegate void ThreadStart();

        static private ITracer _tracer = new Tracer();
        static void Main(string[] args)
        {
            Foo foo = new Foo(_tracer);

            var task1 = new Task(() => {
                foo.MyMethod();
                foo.MyMethod();
            });

            var task2 = new Task(() => foo.MyMethod());
            var task3 = new Task(() => foo.MyMethod());

            task1.Start();
            task2.Start();
            task3.Start();

            task1.Wait();
            task2.Wait();
            task3.Wait();
                
            var result = _tracer.GetTraceResult();
            
            
            ITraceSerializer traceSerializer = new XmlTraceSerializer();

            System.Console.WriteLine(traceSerializer.Serialize(result));
        }
    }
}
