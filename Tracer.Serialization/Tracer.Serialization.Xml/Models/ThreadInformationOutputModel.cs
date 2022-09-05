using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Xml.Models
{
    public class ThreadInformationOutputModel
    {
        public int Id { get; set; }

        public long TimeInMs { get; set; }

        public List<MethodInformationOutputModel> Methods { get; set; }

        public ThreadInformationOutputModel()
        {
            
        }

        public void SetValues(IThreadInformation thread)
        {
            Id = thread.Id;
            TimeInMs = thread.TimeInMs;
            Methods = new(thread.Methods.Count);
            foreach (var method in thread.Methods)
            {
                var model = new MethodInformationOutputModel();
                model.SetValues(method);
                Methods.Add(model);
            }
        }
    }
}
