
using System;
using System.IO;
using System.Threading;
using TraceLib;
using SPP_1.Write;
using TraceLib.Serialization;

namespace SPP_1
{
    class Program
    {
        private const string JSON_FILE_PATH = "result.json";
        private const string XML_FILE_PATH = "result.xml";

        static void Main(string[] args)
        {
            var program = new Program();
            Thread thread = new Thread(program.Method1);
            ITracer tracer = new Tracer();

            var foo = new Foo(tracer);
            foo.MyMethod();
            thread.Start(tracer);
            thread.Join();

            var result = new JsonSerializer().Serialize(tracer.GetTraceResult());
            IWriter writer = new FileWriter(Path.GetFullPath(Path.Combine(GetFolderDirectory(), JSON_FILE_PATH)));
            writer.Write(result);
            writer = new ConsoleWriter();
            writer.Write(result);

            result = new XmlSerializer().Serialize(tracer.GetTraceResult());
            writer = new FileWriter(Path.GetFullPath(Path.Combine(GetFolderDirectory(), XML_FILE_PATH)));
            writer.Write(result);
            writer = new ConsoleWriter();
            writer.Write(result);
        }
        public void Method1(object obj)
        {
            var tracer = (Tracer)obj;
            tracer.StartTrace();
            Method2(tracer);
            Thread.Sleep(100);
            tracer.StopTrace();
        }
        public void Method2(object obj)
        {
            var tracer = (Tracer)obj;
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        public static string GetFolderDirectory()
        {
            var projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var folderPath = Path.Combine(projectDir, "Result");
            return folderPath;
        }
    }
}
