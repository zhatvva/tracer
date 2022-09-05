using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Xml.Models
{
    public class TraceResultOutputModel
    {
        public List<ThreadInformationOutputModel> Threads { get; set; }

        public TraceResultOutputModel()
        {

        }

        public void SetValues(ITraceResult result)
        {
            Threads = new(result.Threads.Count);
            foreach (var thread in result.Threads)
            {
                var model = new ThreadInformationOutputModel();
                model.SetValues(thread);
                Threads.Add(model);
            }
        }
    }
}
