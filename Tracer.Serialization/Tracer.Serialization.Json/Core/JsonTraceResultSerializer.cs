using System.Text;
using System.Text.Json;
using Tracer.Core.Abstractions;
using Tracer.Serialization.Abstractions;
using Tracer.Serialization.Json.Models;

namespace Tracer.Serialization.Json.Core
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(ITraceResult traceResult, Stream to)
        {
            var model = new TraceResultOutputModel(traceResult);
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(model, options);
            to.Write(Encoding.UTF8.GetBytes(json));
        }
    }
}
