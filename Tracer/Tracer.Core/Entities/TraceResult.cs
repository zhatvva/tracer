using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class TraceResult : ITraceResult
    {
        public IReadOnlyList<IThreadInformation> Threads => throw new NotImplementedException();
    }
}
