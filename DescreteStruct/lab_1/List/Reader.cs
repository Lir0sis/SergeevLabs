#define test
using System;
using System.IO;

namespace List
{
    class Reader
    {
        private const int bufferSize = 128;
        private int bufferCounts = 0;
        public string path;
        public Reader(string fileName)
        {
            path = Directory.GetCurrentDirectory() + "\\" + fileName;
        }

        private FileStream fs;
        private FileStream ReadFile()
        {
            if (!File.Exists(path))
                return null;
            else
                return File.Open(path, FileMode.Open);
        }

        public byte[] GetData(out int count)
        {

            if (fs == null) fs = ReadFile();

            byte[] data = new byte[bufferSize];
            

            if ((count = fs.Read(data, 0, bufferSize)) <= 0)
            {
                fs.Dispose();
                return null;

            }
            return data;
        }
    }
}
