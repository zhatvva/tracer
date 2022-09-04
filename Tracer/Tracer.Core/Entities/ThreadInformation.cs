using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class ThreadInformation : IThreadInformation
    {
        public int Id { get; internal set; }

        internal long TimeInMs { get; set; }
        public string Time => $"{TimeInMs}ms";

        public IReadOnlyList<IMethodInformation> Methods { get; internal set; }
    }
}
