using System.Text;
using Tracer.Core.Abstractions;
using Tracer.Serialization.Abstractions;
using YamlDotNet.Serialization;
using Tracer.Serialization.Yaml.Models;

namespace Tracer.Serialization.Yaml.Core
{
    public class YamlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(ITraceResult traceResult, Stream to)
        {
            var model = new TraceResultOutputModel(traceResult);
            var serializer = new SerializerBuilder().Build();
            var yaml = serializer.Serialize(model);
            to.Write(Encoding.UTF8.GetBytes(yaml));
        }
    }
}
