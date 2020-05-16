#define time

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Додавання\t\t" + "Видалення\t");
            Random r = new Random();
            Stopwatch st = new Stopwatch();

            if (!File.Exists("./txt.txt"))
            {
                using (StreamWriter sw = File.CreateText("./ txt.txt")) { }
            }

            for (int i = 1; i <= 10; i++)
            {
                Reader rd = null;
                try
                {
                    rd = new Reader(i + "00k");
                }
                catch
                {
                    continue;
                }
                
                Binary tree = new Binary();
                st.Restart();

                while (true)
                {
                    int count;
                    byte[] data = rd.GetData(out count);
                    if (count == 0)
                        break;

                    for (int k = 0; k < count / 4; k++)
                    {
                        int temp = BitConverter.ToInt32(data, k * 4);

                        st.Start();
                        tree.Insert(temp);
                        st.Stop();
                    }
                }

                using (StreamWriter sw = File.AppendText("./ txt.txt"))
                {
                    sw.Write((i + "00k\t" + (float)st.ElapsedMilliseconds / 1000 + "\t\t").Replace('.', ','));
                }

                st.Reset();
                List<int> datalist = null; tree.GetListOfData(out datalist);

                while (datalist.Count > 0)
                {
                    int valueIndx = r.Next(0, datalist.Count - 1);

                    st.Start();
                    tree.DeleteNode(datalist[valueIndx]);
                    st.Stop();

                    datalist.RemoveAt(valueIndx);
                }

                using (StreamWriter sw = File.AppendText("./ txt.txt"))
                {
                    sw.WriteLine((i + "00k\t" + (float)st.ElapsedMilliseconds / 1000).Replace('.', ','));
                }
            }
        }
    }
}
