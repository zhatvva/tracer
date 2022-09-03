using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Abstractions
{
    public interface ITraceResultSerializer
    {
        public void Serialize(ITraceResult traceResult, Stream to);
    }
}
