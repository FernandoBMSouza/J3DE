using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bubblesort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(10000);

            Print(array);
            long s = DateTime.Now.Millisecond;
            BubbleSort(array);
            long e = DateTime.Now.Millisecond;
            Print(array);
            //Console.WriteLine("elapsed: " + (e - s));

            Console.Read();
        }

        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        
                        //array[i] ^= array[j];
                        //array[j] ^= array[i];
                        //array[i] ^= array[j];
                    }
                }
            }
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
