using NUnit.Framework;
using Core;
using Core.Result;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class MultiThreadingTest
    {
        private ITracer _tracer;
        private TraceResult _traceResult;

        public MultiThreadingTest()
        {
            _tracer = new Tracer();
            var foo = new Foo(_tracer);

            var task1 = new Task(() => {
                foo.MyMethod();
                foo.MyMethod();
            });

            var task2 = new Task(() => foo.MyMethod());

            task1.Start();
            task2.Start();

            task1.Wait();
            task2.Wait();

            _traceResult = _tracer.GetTraceResult();
        }

        [Test]
        public void GetTraceResult_ThreadCount_Return2()
        {
            var threadsCount = _traceResult.Threads.Count;
            Assert.IsTrue(threadsCount == 2, $"Invalid threads count: {threadsCount}");
        }

        [Test]
        public void GetTraceResult_ThreadsTime_Return500()
        {
            const long ACCURACY = 50;
            var firstThreadTime = _traceResult.Threads[0].Milliseconds;
            var secondThreadTime = _traceResult.Threads[1].Milliseconds;

            bool statement =
                (System.Math.Abs(firstThreadTime - 500) <= ACCURACY &&
                 System.Math.Abs(secondThreadTime - 1000) <= ACCURACY) ||
                (System.Math.Abs(secondThreadTime - 500) <= ACCURACY &&
                 System.Math.Abs(firstThreadTime - 1000) <= ACCURACY);

            Assert.IsTrue(statement,
                $"Invalid time: firstThread - {firstThreadTime}ms; secondThread - {secondThreadTime}ms");
        }

        [Test]
        public void GetTraceResult_ThreadsMethodsCount_Return2()
        {
            var firstMethodsCount = _traceResult.Threads[0].Methods.Count;
            var secondMethodsCount = _traceResult.Threads[1].Methods.Count;
            bool statement = (firstMethodsCount == 1 && secondMethodsCount == 2) ||
                             (firstMethodsCount == 2 && secondMethodsCount == 1);
    
            Assert.IsTrue(statement,
                $"Invalid methods count: firstThread - {firstMethodsCount}; secondThread - {secondMethodsCount}");
        }
    }
}
