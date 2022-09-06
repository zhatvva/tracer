using System.Text;
using Tracer.Core.Abstractions;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;

namespace Tracer.Serialization.Yaml.Core
{
    public class YamlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(ITraceResult traceResult, Stream to)
        {
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(traceResult);
            to.Write(Encoding.UTF8.GetBytes(yaml));
        }
    }
}
