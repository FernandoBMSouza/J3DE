using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heapsort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random rand = new Random();
            
            for (int i = 1; i < array.Length; i++)
                array[i] = rand.Next(10000);

            Print(array);
            long s = DateTime.Now.Millisecond;
            Heapsort(array.Length-1, array);
            long e = DateTime.Now.Millisecond;
            //Console.WriteLine("elapsed: " + (e - s));
            Print(array);

            Console.Read();
        }

        static void InsertHeap(int m, int[] array)
        {
            int f = m + 1;

            while (f > 1 && array[f/2] < array[f])
            {
                int t = array[f / 2];
                array[f / 2] = array[f];
                array[f] = t;
                f = f / 2;
            }
        }

        static void ShakeHeap(int m, int[] array)
        {
            int f = 2;

            while (f <= m)
            {
                if (f < m && array[f] < array[f + 1])
                    ++f;

                if (array[f / 2] >= array[f])
                    break;

                int t = array[f / 2];
                array[f / 2] = array[f];
                array[f] = t;
                f *= 2;
            }
        }

        static void Heapsort(int n, int[] array)
        {
            for (int i = 1; i < n; i++)
                InsertHeap(i, array);

            for (int i = n; i > 1; i--)
            {
                int t = array[1];
                array[1] = array[i];
                array[i] = t;
                ShakeHeap(i - 1, array);
            }
        }

        static void Print(int[] array)
        {
            Console.WriteLine("-----------------------------");

            for (int i = 1; i < array.Length; i++)
            {
                Console.WriteLine(i + " : " + array[i]);
            }
        }
    }
}
