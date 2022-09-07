using Tracer.Core.Abstractions;

namespace Tracer.Serialization.Yaml.Models
{
    public class MethodInformationOutputModel
    {
        public string Name { get; set; }

        public string Class { get; set; }

        public string Time { get; set; }

        public List<MethodInformationOutputModel> Methods { get; set; }

        public MethodInformationOutputModel()
        {
            
        }

        public MethodInformationOutputModel(IMethodInformation method)
        {
            Name = method.Name;
            Class = method.Class;
            Time = $"{method.TimeInMs}ms";
            Methods = new(method.Methods.Count);
            foreach (var m in method.Methods)
            {
                var model = new MethodInformationOutputModel(m);
                Methods.Add(model);
            }
        }
    }
}
