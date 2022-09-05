using System.Collections.Concurrent;
using System.Diagnostics;
using Tracer.Core.Abstractions;
using Tracer.Core.Entities;

namespace Tracer.Core.Services
{
    public class TracerService : ITracer
    {
        private readonly ConcurrentDictionary<int, ThreadTracer> _threads = new();
        
        public void StartTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var thread = _threads.GetOrAdd(threadId, new ThreadTracer(threadId));
            var frame = new StackTrace(true).GetFrame(1);
            thread.StartTrace(frame);
        }

        public void StopTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (_threads.TryGetValue(threadId, out var thread))
            {
                thread.StopTrace();
            }
        }

        public ITraceResult GetTraceResult()
        {
            var threads = _threads
                .Select(p => p.Value.GetTraceResult())
                .ToList()
                .AsReadOnly();

            var traceResult = new TraceResult(threads);
            return traceResult;
        }
    }
}
