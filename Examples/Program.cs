using Core;
using Core.Result;
using Core.Serialization;
using Core.Serialization.Xml;

namespace Examples
{
    internal class Program
    {
        static private ITracer _tracer = new Tracer();
        static void Main(string[] args)
        {
            _tracer.StartTrace();

            InnerMethod1();
            InnerMethod2();

            _tracer.StopTrace();

            var result = _tracer.GetTraceResult();
            ITraceSerializer traceSerializer = new XmlTraceSerializer();
            System.Console.WriteLine(traceSerializer.Serialize(result));

        }

        static void InnerMethod1()
        {
            _tracer.StartTrace();

            InnerMethod2();

            _tracer.StopTrace();
        }

        static void InnerMethod2()
        {
            _tracer.StartTrace();

            _tracer.StopTrace();
        }
    }
}
