#define USE_RECURSIVE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[16];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = i * 10 + rand.Next(10); // i

            Print(array);

            while (true)
            {
                int target = rand.Next(array.Length * 10);

                Console.WriteLine("-----------------------------");
                Console.WriteLine("Numero procurado: " + target);

                int times = 0;

    #if USE_RECURSIVE
                int index = BinarySearch(array, target, 0, array.Length, ref times);
    #else
                int index = BinarySearch(array, target, out times);
    #endif
                Console.WriteLine(times.ToString() + " elemento(s) testado(s).");
                                
                if (index < array.Length && array[index] == target)
                {
                    Console.WriteLine("Numero " + target + " encontrado!");
                    break;
                }
                else
                {
                    Console.WriteLine("Numero " + target + " nao existe nesse conjunto!");
                }
            }

            Console.Read();
        }

#if !USE_RECURSIVE
        static int BinarySearch(int[] array, int target, out int times)
        {
            int left, middle, right;
            left= -1;
            right = array.Length;

            times = 0;

            while (left < right - 1)
            {
                times++;

                middle = (left + right) / 2;

                if (array[middle] == target)
                {
                    right = middle;
                    break;
                } 
                else if (array[middle] < target)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }

            return right;
        }
#endif

#if USE_RECURSIVE
        // versão recursiva
        static int BinarySearch(int[] array, int target, int left, int right, ref int times)
        {
            if (left == right - 1)
            {
                return right;
            }
            else
            {
                times++;

                int middle = (left + right) / 2;

                if (array[middle] == target)
                {
                    return middle;
                }
                else if (array[middle] < target)
                {
                    return BinarySearch(array, target, middle, right, ref times);
                }
                else
                {
                    return BinarySearch(array, target, left, middle, ref times);
                }
            }
        }
#endif

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
