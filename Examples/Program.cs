using System.Threading.Tasks;
using Core;
using Core.Serialization;
using Core.Serialization.Json;
using Core.Serialization.Writer;

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
            

            ITraceSerializer traceSerializer = new JsonTraceSerializer();

            IResultWriter writer = new FileWriter("D:\\test.json");
            writer.Write(traceSerializer.Serialize(result));

            writer = new ConsoleWriter();
            writer.Write(traceSerializer.Serialize(result));   
        }
    }
}
