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
            return ThreadTraces;
        }
        public ThreadTrace FindThreadTrace(int id)
        {
            return ThreadTraces.GetOrAdd(id, new ThreadTrace(id));
        }

    }
}
