namespace Tracer.Core.Abstractions
{
    public interface IThreadInformation
    {
        public int Id { get; }

        public string Time { get; }

        public IReadOnlyList<IMethodInformation> Methods { get; }
    }
}
