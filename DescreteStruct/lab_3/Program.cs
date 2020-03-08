using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class RBtree
        {
            public void Add()
            {

            }

            public class Node
            {
                public byte data;
                public Node parent, left, right;
                bool isBlack;

                public Node(Node parent, byte data, bool isBlack)
                {
                    this.data = data;
                    this.isBlack = isBlack;
                }
            }
        }

    }
}
