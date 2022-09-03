namespace Tracer.Core.Abstractions
{
    public interface IMethodInformation
    {
        public string Name { get; }
        
        public string Class { get; }

        public string Time { get; }

        public IReadOnlyList<IMethodInformation> Methods { get; }
    }
}
