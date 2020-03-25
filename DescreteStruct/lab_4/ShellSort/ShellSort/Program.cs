using System;
using System.Diagnostics;
using System.Collections.Generic;
using R;
namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Stopwatch st = new Stopwatch();

            Reader reader = new Reader("100k");
            float time;
            int[] intArray;
            List<int> intList = new List<int>();
            st.Start();
                while (true)
                {
                    int counter;
                    byte[] data = reader.GetData(out counter);
                    if (counter == 0) break;
                    for (int i = 0; i < counter / 4; i++)
                    {
                        intList.Add(BitConverter.ToInt32(data, i));
                    }
                }
                Console.WriteLine(intList.Count);
                intArray = intList.ToArray();


                ShellSort(intArray);
                st.Stop();     
            Console.WriteLine((float)st.ElapsedMilliseconds / 1000); 
            /*foreach(var i in intArray)
            {
                Console.WriteLine(i);
            }*/
            int[] ShellSort(int[] intArray)
            {
                int startGap = intArray.Length / 2;
                int temp;
                for (int gap = startGap; gap >= 1; gap /= 2)
                {
                    for (int j = gap; j < intArray.Length; j++)
                    {
                        for (int i = j - gap; i >= 0; i -= gap)
                        {
                            if (intArray[i] < intArray[gap + i]) break;
                            {
                                temp = intArray[i];
                                intArray[i] = intArray[gap + i];
                                intArray[gap + i] = temp;
                            }
                        }
                    }
                }
                return intArray;
            } 
        }
    }
}
