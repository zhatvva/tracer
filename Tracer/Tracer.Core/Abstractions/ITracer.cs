namespace Tracer.Core.Abstractions
{
    public interface ITracer
    {
        public void StartTrace();

        public void StopTrace();

        public ITraceResult GetTraceResult();
    }
}
