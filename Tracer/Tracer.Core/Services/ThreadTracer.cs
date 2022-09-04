using Tracer.Core.Entities;
using System.Diagnostics;

namespace Tracer.Core.Services
{
    internal class ThreadTracer
    {
        internal bool IsStopped { get; private set; } = false;
        
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
            lock (_methodTracers)
            {
                _methodTracers.Push(methodTracer);
            }
            methodTracer.StartTrace(frame);
        }

        public void StopTrace()
        {
            lock (_methodTracers)
            {
                if (_methodTracers.TryPop(out var methodTracer))
                {
                    methodTracer.StopTrace();
                    var methodInformation = methodTracer.GetTraceResult();
                    if (_methodTracers.TryPeek(out var previousTracer))
                    {
                        previousTracer.AttachMethodInformation(methodInformation);
                    }
                    else
                    {
                        lock (_methodInformations)
                        {
                            _methodInformations.Add(methodInformation);
                        }
                    }
                }
            }
            IsStopped = true;
        }

        public ThreadInformation GetTraceResult()
        {
            lock (_methodInformations)
            {
                _threadInformation.TimeInMs = _methodInformations.Sum(m => m.TimeInMs);
                _threadInformation.Methods = _methodInformations;
            }

            return _threadInformation;
        }
    }
}
