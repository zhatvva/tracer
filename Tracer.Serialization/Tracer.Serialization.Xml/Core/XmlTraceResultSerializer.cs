using System.Xml.Serialization;
using Tracer.Core.Abstractions;
using Tracer.Serialization.Abstractions;
using Tracer.Serialization.Xml.Models;

namespace Tracer.Serialization.Xml.Core
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(ITraceResult traceResult, Stream to)
        {
            var serializer = new XmlSerializer(typeof(TraceResultOutputModel));
            var model = new TraceResultOutputModel();
            model.SetValues(traceResult);
            serializer.Serialize(to, model);
        }
    }
}
