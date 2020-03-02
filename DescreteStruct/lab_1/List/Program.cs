using System;
using System.Diagnostics;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader rd = new Reader(Console.ReadLine());
            Stopwatch st = new Stopwatch();
            List<byte> byteList = null;
            float popping = 0;
            float pushing = 0;

            byteList = new List<byte>();

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

                    byteList.Add(data[i]);
                }
                st.Stop();
                pushing += (float)st.ElapsedMilliseconds / 1000;

            }

            st.Reset();

            st.Start();
            for (int i = 0; i < byteList.Size; i++)
            {
                byteList.Pop();
            }
            st.Stop();

            popping = (float)st.ElapsedMilliseconds / 1000;
            Console.WriteLine("Pushing: " + pushing);
            Console.WriteLine("Poping: " + popping);
        }

        class List<T>
        {
            private int size = 0;
            public int Size
            {
                get { return size; }
            }
            Node<T> start = null;
            Node<T> end = null;
            public void Add(T value)
            {
                Node<T> node = new Node<T>(value, null, end);
                if (start == null) start = node;
                if (end != null) end.nextNode = node;
                end = node;
                size++;

            }
            public void Push(T value)
            {
                Node<T> node = new Node<T>(value, start, null);
                start.previousNode = node;
                start = node;
                size++;

            }
            public bool Find(T value)
            {
                Node<T> node = start;
                while (node != null)
                {
                    if (node.data.ToString() == value.ToString()) return true;
                    node = node.nextNode;
                }
                return false;
            }

            public void Insert(T value, int position)
            {
                if (position >= size)
                {
                    Add(value);
                    return;
                }
                Node<T> node = start;
                int i = 0;
                while (i <= position)
                {
                    if (i == position)
                    {

                        Node<T> new_node = new Node<T>(value, node, node.previousNode);
                        new_node.previousNode.nextNode = new_node;
                        node.previousNode = new_node;

                    }
                    i++;

                    node = node.nextNode;
                }
            }
            public void Remove(T value)
            {
                Node<T> node = start;
                while (node != null)
                {
                    if (node.data.ToString() == value.ToString())
                    {

                        node.nextNode.previousNode = node.previousNode;
                        node.previousNode.nextNode = node.nextNode;
                        size--;
                    }

                    node = node.nextNode;
                }

            }

            public void Pop()
            {
                end.previousNode.nextNode = null;
                end = end.previousNode;

                size--;
            }
        }

        class Node<T>
        {
            public T data; 
            public Node<T> nextNode = null;
            public Node<T> previousNode = null;
            public Node(T data, Node<T>nextNode, Node<T> previousNode)
            {
                this.data = data;
                this.nextNode = nextNode;
                this.previousNode = previousNode;
            }
            
        }
    }
}
