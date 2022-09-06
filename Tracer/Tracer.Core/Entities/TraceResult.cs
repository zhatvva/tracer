using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class TraceResult : ITraceResult
    {
        public IReadOnlyList<IThreadInformation> Threads { get; init; }

        public TraceResult(List<ThreadInformation> threads)
        {
            if (threads is null)
            {
                throw new ArgumentNullException(nameof(threads));
            }

            Threads = threads.AsReadOnly();
        }
    }
}
