using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quicksort
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
            Quicksort(array, 0, array.Length-1);
            long e = DateTime.Now.Millisecond;
            Console.WriteLine("elapsed: " + (e - s));
            Print(array);

            Console.Read();
        }

        static void Quicksort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                Quicksort(array, left, pivot - 1);
                Quicksort(array, pivot + 1, right);
            }
        }

        static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }

            array[right] = array[i];
            array[i] = pivot;
            return i;
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
