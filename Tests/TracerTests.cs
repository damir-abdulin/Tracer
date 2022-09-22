using NUnit.Framework;
using Core;


namespace Tests
{
    public class Tests
    {
        private ITracer _tracer = new Tracer();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}