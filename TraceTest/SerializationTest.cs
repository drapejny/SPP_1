using System;
using NUnit.Framework;
using System.Threading;
using TraceLib;
using TraceLib.Serialization;

namespace TraceTest
{
   public class SerializationTest
    {
        private ITracer _tracer;

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]

        public void JsonSerializationTest(int methodsCount)
        {
            int expectedLinesCount = 10;
            _tracer = new Tracer();
            for(int i = 0; i < methodsCount; i++)
            {
                Method();
                expectedLinesCount += 6;
            }
            string data = new JsonSerializer().Serialize(_tracer.GetTraceResult());
            string[] lines = data.Split("\r\n");
            int actualLInesCount = lines.Length;
            Assert.AreEqual(actualLInesCount, expectedLinesCount);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void XmlSerializationTest(int methodsCount)
        {
            int expectedLinesCount = 9;
            _tracer = new Tracer();
            for (int i = 0; i < methodsCount; i++)
            {
                Method();
                expectedLinesCount += 5;
            }
            string data = new XmlSerializer().Serialize(_tracer.GetTraceResult());
            string[] lines = data.Split("\r\n");
            int actualLInesCount = lines.Length;
            Assert.AreEqual(expectedLinesCount, actualLInesCount);
        }








        private void Method()
        {
            _tracer.StartTrace();
            _tracer.StopTrace();

        }
    }
}
