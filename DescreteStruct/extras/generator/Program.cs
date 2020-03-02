using System;
using System.IO;

namespace generator
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();

            Console.Write("Название файла: ");
            string path = Directory.GetCurrentDirectory() + "\\" + Console.ReadLine();

            Console.Write("Количество: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            byte[] bytes = null;

            bytes = new byte[amount];

            rand.NextBytes(bytes);

            File.WriteAllBytes(path, bytes);
        }
    }
}
