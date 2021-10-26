using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SPP_1.Write
{
    public class FileWriter : IWriter
    {
        private string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }
        public void Write(string data)
        {
            StreamWriter streamWriter = new StreamWriter(_filePath);
            try
            {
                streamWriter.WriteLine(data);
            }
            catch(DirectoryNotFoundException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            finally
            {
                streamWriter.Close();
            }
            
        }
    }
}
