using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Json.Models
{
    public class ThreadInformationOutputModel
    {
        public int Id { get; set; }

        public string Time { get; set; }

        public List<MethodInformationOutputModel> Methods { get; set; }

        public ThreadInformationOutputModel()
        {
            
        }

        public ThreadInformationOutputModel(IThreadInformation thread)
        {
            Id = thread.Id;
            Time = $"{thread.TimeInMs}ms";
            Methods = new(thread.Methods.Count);
            foreach (var method in thread.Methods)
            {
                var model = new MethodInformationOutputModel(method);
                Methods.Add(model);
            }
        }
    }
}
