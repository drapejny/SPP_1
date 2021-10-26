using NUnit.Framework;
using System.Threading;
using TraceLib;
using System.Collections.Generic;
using System;


namespace TraceTest
{
   public class ThreadsTest
    {
        private ITracer _tracer;

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void ThreadsCountTest(int threadsCount)
        {
            _tracer = new Tracer();
            List<Thread> threads = new List<Thread>();
            for(int i = 0; i < threadsCount; i++)
            {
                threads.Add(new Thread(Method));
            }
            foreach(Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }
            TraceResult traceResult = _tracer.GetTraceResult();
            Assert.AreEqual(threadsCount, traceResult.GetThreadTraces().Count);
        }

        private void Method()
        {
            _tracer.StartTrace();
            Thread.Sleep(10);
            _tracer.StopTrace();
        }


    }
}
