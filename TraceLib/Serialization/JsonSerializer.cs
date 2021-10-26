using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TraceLib.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var data = new Dictionary<string, ICollection<ThreadTrace>>
            {
                {"threads", traceResult.GetThreadTraces().Values}
            };
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}
