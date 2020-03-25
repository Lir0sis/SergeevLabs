using System;
using System.Diagnostics;
using R;
using System.Collections.Generic;


namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            Reader reader = new Reader("100k");
            float time; 
            int[] intArray;
            List<int> intList = new List<int>();

            while (true)
            {
                int counter;
                byte[] data = reader.GetData(out counter);
                if (counter == 0) break;
                for(int i = 0; i < counter/4; i++)
                {    
                    intList.Add(BitConverter.ToInt32(data,i));
                }
            }
            Console.WriteLine(intList.Count);
            intArray = intList.ToArray();
            for (int i = 0; i < intArray.Length; i++)
            {
                //intArray[i] = rand.Next(0, 20);
               // Console.WriteLine(intArray[i]);
            }
                intArray = BubbleSort(intArray);
            st.Stop();
            time = (float)st.ElapsedMilliseconds /1000;
            Console.WriteLine("\n---"+time);
           /* for(int i =0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i] + " ;");
            }*/
            Console.WriteLine();
            

        }
        static public int[] BubbleSort(int[] inputArray)
        {
            for(int i = 0; i < inputArray.Length; i++)
            {
                for(int j = i+1; j < inputArray.Length; j++)
                {
                    if(inputArray[i] >= inputArray[j])
                    {
                        int t = inputArray[i];
                        inputArray[i] = inputArray[j];
                        inputArray[j] = t;
                    }
                }
            }
            return inputArray;
        }
    }
}
