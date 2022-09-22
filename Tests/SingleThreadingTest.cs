using NUnit.Framework;
using Core;
using Core.Result;

namespace Tests
{
    [TestFixture]
    internal class SingleThreadingTest
    {
        private ITracer _tracer;
        private TraceResult _traceResult;

        public SingleThreadingTest()
        {
            _tracer = new Tracer();
            var foo = new Foo(_tracer);
            foo.MyMethod();
            _traceResult = _tracer.GetTraceResult();
        }

        [Test]
        public void GetTraceResult_ThreadCount_Return1()
        {
            var threadsCount = _traceResult.Threads.Count;
            Assert.IsTrue(threadsCount == 1, $"Invalid threads count: {threadsCount}");
        }

        [Test]
        public void GetTraceResult_ThreadTime_Return500()
        {
            const long ACCURACY = 50;
            var threadTime = _traceResult.Threads[0].Milliseconds;

            Assert.IsTrue(System.Math.Abs(threadTime - 500) <= ACCURACY, $"Invalid time: {threadTime}");
        }

        [Test]
        public void GetTraceResult_MethodsCount_Return1()
        {
            var methodsCount = _traceResult.Threads[0].Methods.Count;
            Assert.IsTrue(methodsCount == 1, $"Invalid methods count: {methodsCount}");
        }

        [Test]
        public void GetTraceResult_MethodName_EqualMyMethod()
        {
            var methodName = _traceResult.Threads[0].Methods[0].Name;
            Assert.IsTrue(methodName == "MyMethod", $"Invalid method name: {methodName}");
        }

        [Test]
        public void GetTraceResult_MethodTypeName_ReturnFoo()
        {
            var methodTypeName = _traceResult.Threads[0].Methods[0].TypeName;
            Assert.IsTrue(methodTypeName == "Foo", $"Invalid type name: {methodTypeName}");
        }
        
        [Test]
        public void GetTraceResult_MethodMilliseconds_Return500()
        {
            const long ACCURACY = 50;
            var methodTime = _traceResult.Threads[0].Methods[0].Milliseconds;

            Assert.IsTrue(System.Math.Abs(methodTime - 500) <= ACCURACY, $"Invalid time: {methodTime}");
        }

        [Test]
        public void GetTraceResult_InnerMethodsCount_Return1()
        {
            var innerMethodsCount = _traceResult.Threads[0].Methods[0].Methods.Count;
            Assert.IsTrue(innerMethodsCount == 1, $"Invalid inner methods count: {innerMethodsCount}");
        }

        [Test]
        public void GetTraceResult_InnerMethodName_ReturnInnerMethod()
        {
            var innerMethodName = _traceResult.Threads[0].Methods[0].Methods[0].Name;
            Assert.IsTrue(innerMethodName == "InnerMethod", $"Invalid method name: {innerMethodName}");
        }

        [Test]
        public void GetTraceResult_InnerMethodTypeName_ReturnBar()
        {
            var innerMethodTypeName = _traceResult.Threads[0].Methods[0].Methods[0].TypeName;
            Assert.IsTrue(innerMethodTypeName == "Bar", $"Invalid type name: { innerMethodTypeName}");
        }
    
        [Test]
        public void GetTraceResult_InnerMethodTime_Return500()
        {
            const long ACCURACY = 50;
            var innerMethodTime = _traceResult.Threads[0].Methods[0].Methods[0].Milliseconds;

            Assert.IsTrue(System.Math.Abs(innerMethodTime - 500) <= ACCURACY, $"Invalid time: {innerMethodTime}");
        }
    }
}
