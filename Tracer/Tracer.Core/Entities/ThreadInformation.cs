using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class ThreadInformation : IThreadInformation
    {
        public int Id { get; internal set; }

        public long TimeInMs { get; internal set; }

        public IReadOnlyList<IMethodInformation> Methods { get; internal set; }
    }
}
