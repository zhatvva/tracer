using Tracer.Core.Entities;
using System.Diagnostics;

namespace Tracer.Core.Services
{
    internal class ThreadTracer
    {
        private readonly ThreadInformation _threadInformation;
        
        private readonly Stack<MethodTracer> _methodTracers = new();

        private readonly List<MethodInformation> _methodInformations = new();

        public ThreadTracer(int id)
        {
            _threadInformation = new ThreadInformation()
            {
                Id = id
            };
        }
        
        public void StartTrace(StackFrame frame)
        {
            var methodTracer = new MethodTracer();
            _methodTracers.Push(methodTracer);
            methodTracer.StartTrace(frame);
        }

        public void StopTrace()
        {
            if (_methodTracers.TryPop(out var methodTracer))
            {
                methodTracer.StopTrace();
                var methodInformation = methodTracer.GetTraceResult();
                if (_methodTracers.TryPeek(out var previousTracer))
                {
                    previousTracer.AddMethodInformation(methodInformation);
                }
                else
                {
                    _methodInformations.Add(methodInformation);
                }
            }
        }

        public ThreadInformation GetTraceResult()
        {
            _threadInformation.TimeInMs = _methodInformations.Sum(m => m.TimeInMs);
            _threadInformation.Methods = _methodInformations;

            return _threadInformation;
        }
    }
}
