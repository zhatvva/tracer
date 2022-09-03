using Tracer.Core.Abstractions;

namespace Tracer.Core.Entities
{
    internal class ThreadInformation : IThreadInformation
    {
        public int Id => throw new NotImplementedException();

        public string Time => throw new NotImplementedException();

        public IReadOnlyList<IMethodInformation> Methods => throw new NotImplementedException();
    }
}
