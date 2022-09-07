using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Json.Models
{
    public class TraceResultOutputModel
    {
        public List<ThreadInformationOutputModel> Threads { get; set; }

        public TraceResultOutputModel()
        {

        }

        public TraceResultOutputModel(ITraceResult result)
        {
            Threads = new(result.Threads.Count);
            foreach (var thread in result.Threads)
            {
                var model = new ThreadInformationOutputModel(thread);
                Threads.Add(model);
            }
        }
    }
}
