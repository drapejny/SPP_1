using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace TraceLib
{
    class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;

        public Tracer()
        {
            _traceResult = new TraceResult();
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }

        public void StartTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadTrace threadTrace = _traceResult.FindThreadTrace(threadId);
            StackTrace stackTrace = new StackTrace();
            string[] path = stackTrace.ToString().Split("\r\n");
            path[0] = "";
            string methodName = stackTrace.GetFrames()[1].GetMethod().Name;
            string className = stackTrace.GetFrames()[1].GetMethod().ReflectedType.Name;
            string methodPath = string.Join("", path);
            Method method = new Method(methodName, className, methodPath);
            threadTrace.AddMethod(method);
        }

        public void StopTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadTrace threadTrace = _traceResult.FindThreadTrace(threadId);
            StackTrace stackTrace = new StackTrace();
            string[] path = stackTrace.ToString().Split("\r\n");
            path[0] = "";
            string methodPath = string.Join("", path);
            threadTrace.RemoveMethod(methodPath);
        }
    }
}
