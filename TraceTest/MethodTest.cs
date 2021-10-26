using NUnit.Framework;
using System.Threading;
using TraceLib;
using System;

namespace TraceTest
{
   public class MethodTest
    {

        [Test]
        public void MethodNameTest()
        {
            ITracer tracer = new Tracer();
            Method(tracer);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string methodName = tracer.GetTraceResult().GetThreadTraces()[threadId].Methods[0].Name;
            Assert.AreEqual(methodName, "Method");
        }

        [Test]
        public void MethodClassNameTest()
        {
            ITracer tracer = new Tracer();
            Method(tracer);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string methodClassName = tracer.GetTraceResult().GetThreadTraces()[threadId].Methods[0].ClassName;
            Assert.AreEqual(methodClassName, "MethodTest");
        }

        [Test]
        public void InnerMethodNameTest()
        {
            ITracer tracer = new Tracer();
            Method(tracer);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string innerMethodName = tracer.GetTraceResult().GetThreadTraces()[threadId].Methods[0].InnerMethods[0].Name;
            Assert.AreEqual(innerMethodName, "InnerMethod");
        }

        [Test]
        public void InnerMethodClassNameTest()
        {
            ITracer tracer = new Tracer();
            Method(tracer);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string innerMethodClassName = tracer.GetTraceResult().GetThreadTraces()[threadId].Methods[0].InnerMethods[0].ClassName;
            Assert.AreEqual(innerMethodClassName, "MethodTest");
        }

        private void Method(ITracer tracer)
        {
            tracer.StartTrace();
            InnerMethod(tracer);
            tracer.StopTrace();
        }

        private void InnerMethod(ITracer tracer)
        {
            tracer.StartTrace();
            tracer.StopTrace();
        }
    }
}
