using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeSearch
{
    class Program
    {
        class Node
        {
            public int key = -1;
            public int value = -1;
            public Node left = null;
            public Node right = null;
        };

        static Random random = new Random();

        static void Main(string[] args)
        {
            Node root = new Node();

            for (var i = 0; i < 7; i++)
            {
                Insert(random.Next(1000), i, ref root);
            }

            Print(ref root);

            Console.Read();
        }

        static void Insert(int value, int key, ref Node node)
        {
            if (node.value == -1)
            {
                node.value = value;
                node.key = key;
                return;
            }
                        
            if (value < node.value)
            {
                if (node.left == null)
                {
                    node.left = new Node();
                    node.left.value = value;
                    node.left.key = key;
                }
                else
                {
                    Insert(value, key, ref node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node();
                    node.right.value = value;
                    node.right.key = key;
                }
                else
                {
                    Insert(value, key, ref node.right);
                }
            }
        }

        // left - center - right
        static void Print(ref Node node)
        {
            if (node.left != null)
                Print(ref node.left);

            Console.WriteLine(node.key + " : " + node.value);
                        
            if (node.right != null)
                Print(ref node.right);
        }
    }
}
