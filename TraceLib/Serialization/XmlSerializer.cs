using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace TraceLib.Serialization
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize(TraceResult traceResult)
        {
            var data = traceResult.GetThreadTraces().Values.ToArray();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(data.GetType());
            var stringWriter = new StringWriter();
            //using(var xmlTextWriter = new System.Xml.Xml)
            xmlSerializer.Serialize(stringWriter, data);
            return stringWriter.ToString();
        }
    }
}
