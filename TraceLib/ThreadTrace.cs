using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TraceLib

{
  public class ThreadTrace
    {
        public int Id { get; set; }
        public long Time { get; set; }
        public List<Method> Methods { get;} = new List<Method>();

        public ThreadTrace() { }

        public ThreadTrace(int id)
        {
            Id = id;
        }

        public void AddMethod(Method method)
        {
            Methods.Add(method);
        }

        public void RemoveMethod(string methodPath)
        {
            int removeIndex = Methods.FindLastIndex(method => String.Equals(method.GetMethodPath(), methodPath));

            if(removeIndex != Methods.Count - 1)
            {
                int length = Methods.Count - 1 - removeIndex;
                List<Method> children = Methods.GetRange(removeIndex + 1, length);
                for(int i = 0; i < length; i++)
                {
                    Methods.RemoveAt(Methods.Count - 1);
                }
                Methods[removeIndex].InnerMethods = children;
                Methods[removeIndex].CalculateTime();
            }
            Time += Methods[removeIndex].GetElapsedTime();
            Methods[removeIndex].CalculateTime();
        }
    }
}
