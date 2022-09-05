using System.Text;
using System.Text.Json;
using Tracer.Core.Abstractions;
using Tracer.Serialization.Abstractions;

namespace Tracer.Serialization.Json.Core
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(ITraceResult traceResult, Stream to)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(traceResult, options);
            to.Write(Encoding.UTF8.GetBytes(json));
        }
    }
}
