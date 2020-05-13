using System;
using System.Diagnostics;


namespace RadixSort
{
    class Program
    {
        public static void Main()
        {
            Random rand = new Random();
            Stopwatch st = new Stopwatch();
            float time;
            int n = 10000000;
            int[] array = new int[n];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0,10000);
            }
            

            Console.WriteLine("Radix Sort");
            /*foreach (int i in array)
                Console.Write(i+";");*/

            int max = Max(array);
            st.Start();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(array, array.Length, exp);
            }
            st.Stop();
            time = (float)st.ElapsedMilliseconds / 1000;
            Console.WriteLine("\n---" + time);

            /*Console.WriteLine();
            foreach (int i in array)
                Console.Write(i+";");
                */
            Console.ReadLine();
        }

        public static void CountingSort(int[] array, int length, int exponent)
        {
            
            int[] output = new int[length];    
            int[] count = new int[10];
            
            for (int i = 0; i < length; i++)
            {
                count[(array[i] / exponent) % 10]++;
            }

            
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            
            for (int i = length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exponent) % 10] - 1] = array[i];
                count[(array[i] / exponent) % 10]--;
            }

            
            for (int i = 0; i < length; i++)
            {
                array[i] = output[i];
            }
        }

        public static int Max(int[] array)
        {
            int max = 0;
            foreach(int i in array)
                if (i >= max) max = i;
            return max;
        }
    }
}
