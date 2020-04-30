using System;
using Hashmap;
using System.Diagnostics;
using System.Collections.Generic;

namespace lab_2 {
	
	class Program {
        static void Main(string[] args)
        {
            Reader rd = new Reader(Console.ReadLine());
            Stopwatch st = new Stopwatch();

            List<string> keys = new List<string>();
            float popping = 0;
            float pushing = 0;

            var map = new HashmapClosed<string, string>();
            int count;

            while (true)
            {
                st.Reset();
                byte[] data = rd.GetData(out count);
                if (count == 0)
                    break;

                
                for (int i = 0; i < count / 32; i++)
                {
                    string key = BitConverter.ToString(data, i, 32);
                    st.Start();
                    map.Add(key, key);
                    st.Stop();
                    pushing += (float)st.ElapsedMilliseconds / 1000;
                    keys.Add(key);
                }

            }

            st.Reset();

            st.Start();
            foreach (var key in keys)
            {
                map.Remove(key);
            }
            st.Stop();

            popping = (float)st.ElapsedMilliseconds / 1000;
            Console.WriteLine("Inserting: " + pushing);
            Console.WriteLine("Removing: " + popping);
            Console.ReadKey();
        }
    }
}
