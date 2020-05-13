using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            float time;
            int n = 10000000;
            Stopwatch st = new Stopwatch();
            int[] inputIntArray = new int[n]; //{ 2, 10, 5, 6, 7, 3, 13, 4, 7, 8};
            int[] outputIntArray = new int[n];
            Random rand = new Random();
            for(int i = 0; i < n; i++)
                inputIntArray[i] = rand.Next(0,10000);

            st.Start();
            outputIntArray = CountingSort(inputIntArray);
            st.Stop();

            time = (float)st.ElapsedMilliseconds / 1000;
            Console.WriteLine("\n---" + time);
            /*for(int i = 0;i< outputIntArray.Length; i++)
            {
                Console.WriteLine(outputIntArray[i]);  
            }*/

        }
        public static int[] CountingSort(int[] inputArray)
        { 
            int max = 0;
            for (int i = 0; i < inputArray.Length; i++)
                if (inputArray[i] >= max) max = inputArray[i];

            int[] valueArray = new int[max+1];
            int[] outputArray = new int[inputArray.Length];

            for (int i = 0; i < inputArray.Length; i++)
            {
                valueArray[inputArray[i]] ++;
            }
            List<int> intList = new List<int>();
            for(int i = 0;i < valueArray.Length; i++)
            {
                int k = valueArray[i];
                for (int n = 0; n < k; n++)
                {
                    intList.Add(i);
                }
            }
            outputArray = intList.ToArray();
            return outputArray;
  
        }
    }
}
