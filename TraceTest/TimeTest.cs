using NUnit.Framework;
using System.Threading;
using TraceLib;
using System;

namespace TraceTest
{
    [TestFixture]
   public class TimeTest
    {
        private ITracer _tracer;

        [TestCase(0)]
        [TestCase(50)]
        [TestCase(150)]
        [TestCase(250)]
        [TestCase(350)]
        public void EllapsedMethodTimeTest(int sleepTime)
        {
            _tracer = new Tracer();
            _tracer.StartTrace();
            Method(sleepTime);
            _tracer.StopTrace();
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(threadId);
            Method method = _tracer.GetTraceResult().GetThreadTraces()[threadId].Methods[0].InnerMethods[0];
            long time = method.GetElapsedTime();
            Assert.AreEqual(sleepTime - 50 <= time && time <= sleepTime + 50, true, $"Expected elapsed time in ({sleepTime - 50}; {sleepTime + 50})");
        }

        private void Method(int sleepTime)
        {
            _tracer.StartTrace();
            Thread.Sleep(sleepTime);
            _tracer.StopTrace();
    }
    }

   
}
