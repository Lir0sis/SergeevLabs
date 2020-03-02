#define test

using System;
using System.Diagnostics;

namespace Stack
{
    public class Program
    {

#if test
        static void Main(string[] args)
        {
            Reader rd = new Reader(Console.ReadLine());
            Stopwatch st = new Stopwatch();
            Stack<byte> byteStack = null;
            float popping = 0;
            float pushing = 0;

            byteStack = new Stack<byte>();
            int count;

            while (true)
            {
                st.Reset();
                byte[] data = rd.GetData(out count);
                if (count == 0)
                    break;

                st.Start();
                for (int i = 0; i < count; i++)
                {
                    
                    byteStack.Push(data[i]);
                }
                st.Stop();
                pushing += (float)st.ElapsedMilliseconds / 1000;

            }

            st.Reset();

            st.Start();
            for (int i = 0; i < byteStack.count; i++)
            {
                byteStack.Pop();
            }
            st.Stop();

            popping = (float)st.ElapsedMilliseconds / 1000;
            Console.WriteLine("Pushing: " + pushing);
            Console.WriteLine("Poping: " + popping);
        }
#endif
        public class Stack<T>
        {
            private Node<T> top;
            public int count = 0;
            public void Push(T data)
            {
                Node<T> note = new Node<T>(data, top);
                top = note;
                count++;
            }
            public T Pop()
            {
                if (top == null)
                    throw new Exception("test");

                T result = top.data;
                top = top.nextNode;
                count--;

                return result;
            }
            public Stack()
            {
                top = null;
            }
            private class Node<T2>
            {
                public T2 data;
                public Node<T2> nextNode;
                public Node(T2 data, Node<T2> nextNode)
                {
                    this.data = data;
                    this.nextNode = nextNode;

                }
            }
        }

        

    }
}
