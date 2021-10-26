using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1.Write
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string data)
        {
            Console.WriteLine(data);
        }
    }
}
