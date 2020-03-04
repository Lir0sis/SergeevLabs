#define tests

using System;
using System.Diagnostics;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Console.ReadLine();

            Stopwatch st = new Stopwatch();
            List<byte> byteList = new List<byte>();

            Random rand = new Random(DateTime.Now.Millisecond);
            float popping = 0;
            float adding = 0;
            float inserting = 0;
            float removing = 0;

            for (int ias = 0; ias < 16; ias++)
            {
                Reader rd = new Reader(file);

#if test
            byteList.Add(0b0000_0010);
            byteList.Add(0b0000_0100);
            byteList.Add(0b0000_0011);
            byteList.Add(0b1111_1111);
            byteList.Add(0b1111_0010);
            byteList.Add(0b1100_0010);

            while (byteList.Size > 0)
            {
                byteList.RemoveAt(rand.Next(0, byteList.Size));
            }

            Console.WriteLine(byteList.Find(0b0000_0100));
            Console.Read();
#endif

                while (true)
                {
                    st.Reset();
                    byte[] data = rd.GetData(out int count);
                    if (data == null || count == 0)
                        break;

                    st.Start();
                    for (int i = 0; i < count; i++)
                    {
                        byteList.Add(data[i]);
                    }
                    st.Stop();
                    adding += (float)st.ElapsedMilliseconds;

                }

                st.Reset();

                st.Start();
                while (byteList.Size > 0)
                {
                    byteList.Pop();
                }
                st.Stop();

                popping = (float)st.ElapsedMilliseconds;

                st.Reset();

                //2nd section

                //rd = new Reader(file);

                //st.Start();
                //while (true)
                //{
                //    st.Reset();
                //    byte[] data = rd.GetData(out int count);
                //    if (data == null || count == 0)
                //        break;

                //    for (int i = 0; i < count; i++)
                //    {
                //        int random = rand.Next(0, byteList.Size);

                //        st.Restart();
                //        byteList.Insert(data[i], random);
                //        st.Stop();
                //        inserting += (float)st.ElapsedMilliseconds;
                //    }
                //}

                //while (byteList.Size > 0)
                //{
                //    int random = rand.Next(0, byteList.Size);

                //    st.Restart();
                //    byteList.RemoveAt(random);
                //    st.Stop();
                //    removing += (float)st.ElapsedMilliseconds;
                //}
            }
            Console.WriteLine("Adding: " + adding/16000);
            Console.WriteLine("Poping: " + popping/16000);
            Console.WriteLine("RemovingAt: " + removing/3000);
            Console.WriteLine("Inserting: " + inserting/3000);
            Console.ReadLine();
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
                if (start == null && size == 0) start = node;
                if (end != null) end.nextNode = node;
                end = node;
                size++;

            }
            public void Push(T value)
            {
                Node<T> node = new Node<T>(value, start, null);
                if (end == null && size == 0) end = node;
                if (start != null) start.previousNode = node;
                start = node;
                size++;
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
                if (position <= 0)
                {
                    Push(value);
                    return;
                }

                Node<T> node;
                int i = 0;
                if (position <= size / 2)
                {
                    node = start;
                    while (i <= position)
                    {
                        if (i == position)
                        {

                            Node<T> new_node = new Node<T>(value, node, node.previousNode);
                            new_node.previousNode.nextNode = new_node;
                            node.previousNode = new_node;
                            size++;
                        }
                        i++;
                        node = node.nextNode;
                    }
                }
                else
                {
                    i = size - 1;
                    node = end;
                    while (i >= position)
                    {
                        if (i == position)
                        {

                            Node<T> new_node = new Node<T>(value, node, node.previousNode);
                            new_node.previousNode.nextNode = new_node;
                            node.previousNode = new_node;
                            size++;

                        }
                        i--;
                        node = node.previousNode;
                    }
                }
            }
            public void RemoveAt(int index)
            {
                if (index >= size - 1)
                {
                    Pop();
                    return;
                }
                else if (index <= 0)
                {
                    Shift();
                    return;
                }

                Node<T> node;
                int i = 0;
                if (index <= size / 2)
                {
                    node = start;
                    while (i <= index)
                    {
                        if (i == index)
                        {

                            node.nextNode.previousNode = node.previousNode;
                            node.previousNode.nextNode = node.nextNode;
                            size--;
                        }
                        i++;
                        node = node.nextNode;
                    }
                }
                else
                {
                    i = size - 1;
                    node = end;
                    while (i >= index)
                    {
                        if (i == index)
                        {

                            node.nextNode.previousNode = node.previousNode;
                            node.previousNode.nextNode = node.nextNode;
                            size--;
                        }
                        i--;
                        node = node.previousNode;
                    }
                }
            }

            public void Pop()
            {
                if (end.previousNode != null) end.previousNode.nextNode = null;
                end = end.previousNode;
                size--;

                if (end == null && size == 0) start = null;
            }
            public void Shift()
            {
                if (start.nextNode != null) start.nextNode.previousNode = null;
                start = start.nextNode;
                size--;

                if (start == null && size == 0) end = null;
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
