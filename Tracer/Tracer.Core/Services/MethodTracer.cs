using System.Diagnostics;
using Tracer.Core.Entities;

namespace Tracer.Core.Services
{
    internal class MethodTracer
    {
        private readonly Stopwatch _stopwatch = new();

        private readonly MethodInformation _information = new();

        public void AddMethodInformation(MethodInformation information)
        {
            _information.MethodsInternal.Add(information);
        }

        public void StartTrace(StackFrame frame)
        {
            if (frame is null)
            {
                _information.Name = "no info";
                _information.Class = "no info";
            }
            else
            {
                var method = frame.GetMethod();
                _information.Name = method.Name;
                _information.Class = method.DeclaringType.Name;
            }
            
            _stopwatch.Start();
        }

        public void StopTrace()
        {
            _stopwatch.Stop();
            _information.TimeInMs = _stopwatch.ElapsedMilliseconds; 
        }

        public MethodInformation GetTraceResult()
        {
            return _information;
        }
    }
}
