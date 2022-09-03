using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class MethodInformation : IMethodInformation
    {
        public string Name => throw new NotImplementedException();

        public string Class => throw new NotImplementedException();

        public string Time => throw new NotImplementedException();

        public IReadOnlyList<IMethodInformation> Methods => throw new NotImplementedException();
    }
}
