using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class MethodInformation : IMethodInformation
    {
        public string Name { get; internal set; }

        public string Class { get; internal set; }
        
        internal long TimeInMs { get; set; }
        public string Time => $"{TimeInMs}ms";
        
        internal List<MethodInformation> MethodsInternal { get; } = new();
        public IReadOnlyList<IMethodInformation> Methods => MethodsInternal.AsReadOnly();
    }
}
