using System;
using Hashmap;
using System.Diagnostics;
using System.Collections.Generic;

namespace lab_2 {
	
	
	class Program {
		static void Main() {

			var map = new HashmapClosed<string, string>(512);
			map.Add("Oleg", "Valentina");
			map.Add("Valentine", "Olga");
			Console.WriteLine("Oleg -> " + map.Find("Oleg").Value);
			Console.ReadKey();
		}
        static void Main(string[] args)
        {
            Reader rd = new Reader(Console.ReadLine());
            Stopwatch st = new Stopwatch();

            HashmapClosed<byte, byte> closedMap = null;
            List<byte> keys = new List<byte>();
            float popping = 0;
            float pushing = 0;

            closedMap = new HashmapClosed<byte, byte>();
            int count;

            while (true)
            {
                st.Reset();
                byte[] data = rd.GetData(out count);
                if (count == 0)
                    break;

                
                for (int i = 0; i < count; i++)
                {
                    st.Start();
                    closedMap.Add(data[i], data[i]);
                    st.Stop();
                    pushing += (float)st.ElapsedMilliseconds / 1000;
                    keys.Add(data[i * 2]);
                }

            }

            st.Reset();

            st.Start();
            for (int i = 0; i < keys.Count; i++)
            {
                closedMap.Remove(keys[i]);
            }
            st.Stop();

            popping = (float)st.ElapsedMilliseconds / 1000;
            Console.WriteLine("Pushing: " + pushing);
            Console.WriteLine("Poping: " + popping);
        }
    }
}
