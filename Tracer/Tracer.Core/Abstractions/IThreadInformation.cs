namespace Tracer.Core.Abstractions
{
    public interface IThreadInformation
    {
        public int Id { get; }

        public long TimeInMs { get; }

        public IReadOnlyList<IMethodInformation> Methods { get; }
    }
}
