using System;
using System.Collections.Concurrent;

namespace TraceLib
{
    public class TraceResult
    {
        private ConcurrentDictionary<int, ThreadTrace> ThreadTraces { get; } = new ConcurrentDictionary<int, ThreadTrace>();

        public TraceResult()
        {
        }

        public ConcurrentDictionary<int, ThreadTrace> GetThreadTraces()
        {
            foreach(ThreadTrace threadTrace in ThreadTraces.Values)
            {
                long time = 0;
                foreach(Method method in threadTrace.Methods)
                {
                    time += method.Time;
                }
                threadTrace.Time = time;
            }
            return ThreadTraces;
        }
        public ThreadTrace FindThreadTrace(int id)
        {
            return ThreadTraces.GetOrAdd(id, new ThreadTrace(id));
        }

    }
}
