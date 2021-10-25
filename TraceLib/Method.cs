using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceLib
{
  public class Method
    {
        readonly Stopwatch _stopWatch = new Stopwatch();
        readonly string _methodPath;

        public string Name { get; set; }
        public long Time { get; set; }
        public string ClassName { get; set; }
        public List<Method> InnerMethods { get; set; }

        public Method(string name, string className, string methodPath)
        {
            Name = name;
            ClassName = className;
            _methodPath = methodPath;
            _stopWatch.Start();
        }

        public string GetMethodPath()
        {
            return _methodPath;
        }
        
        public void CalculateTime()
        {
            _stopWatch.Stop();
            Time = _stopWatch.ElapsedMilliseconds;
        }

        public long GetElapsedTime()
        {
            return _stopWatch.ElapsedMilliseconds;
        }


    }
}
