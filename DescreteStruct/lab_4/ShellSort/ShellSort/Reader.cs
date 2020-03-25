using System;
using System.IO;

namespace R
{
    class Reader
    {
        private const int buferSize = 1024;
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

            byte[] data = new byte[buferSize];


            if ((count = fs.Read(data, 0, buferSize)) <= 0)
            {
                fs.Close();
                return null;

            }

            return data;
        }
    }
}
