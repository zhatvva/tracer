using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Xml.Models
{
    public class MethodInformationOutputModel
    {
        public string Name { get; set; }

        public string Class { get; set; }

        public long TimeInMs { get; set; }

        public List<MethodInformationOutputModel> Methods { get; set; }

        public MethodInformationOutputModel()
        {
            
        }

        public void SetValues(IMethodInformation method)
        {
            Name = method.Name;
            Class = method.Class;
            TimeInMs = method.TimeInMs;
            Methods = new(method.Methods.Count);
            foreach (var m in method.Methods)
            {
                var model = new MethodInformationOutputModel();
                model.SetValues(m);
                Methods.Add(model);
            }
        }
    }
}
