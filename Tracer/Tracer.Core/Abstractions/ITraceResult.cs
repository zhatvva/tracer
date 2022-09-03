namespace Tracer.Core.Abstractions
{
    public interface ITraceResult
    {
        public IReadOnlyList<IThreadInformation> Threads { get; }
    }
}
