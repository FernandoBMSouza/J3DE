using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Random r = new Random();

            for (int i = 0; i < array.Length / 2; i++)
                array[i] = r.Next(10000);
                //array[i] = i * 10;
            for (int i = array.Length / 2; i < array.Length; i++)
                //array[i] = array[i - array.Length / 2] + 5;
                array[i] = r.Next(10000);
            Print(array);
            Console.WriteLine("Long: " + long.MinValue + " / " + long.MaxValue);
            long s = DateTime.Now.Millisecond;
            //Console.WriteLine("start: " + DateTime.Now.Ticks);
            Mergesort(0, array.Length, array);
            long e = DateTime.Now.Millisecond;
            //Console.WriteLine("end: " + DateTime.Now.Ticks);
            Console.WriteLine("elapsed: " + (e - s));
            Print(array);

            Console.Read();
        }

        static void Mergesort(int p, int r, int[] array)
        {
            if (p < r - 1)
            {
                int q = (p + r) / 2;
                Mergesort(p, q, array);
                Mergesort(q, r, array);
                Merge(p, q, r, array);
            }
        }

        static void Merge(int p, int q, int r, int[] array)
        {
            int i = p;
            int j = q;
            int k = 0;
            int[] w = new int[r - p];

            while (i < q && j < r)
            {
                if (array[i] <= array[j])
                {
                    w[k++] = array[i++];
                }
                else
                {
                    w[k++] = array[j++];
                }
            }

            while (i < q)
            {
                w[k++] = array[i++];
            }

            while (j < r)
            {
                w[k++] = array[j++];
            }

            for (i = p; i < r; i++)
                array[i] = w[i - p];
        }

        static void Print(int[] array)
        {
            Console.WriteLine("-----------------------------");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(i + " : " + array[i]);
            }
        }
    }
}
