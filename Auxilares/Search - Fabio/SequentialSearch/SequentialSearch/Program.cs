//#define USE_LOOP

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequentialSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[16];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = i * 10 + rand.Next(10);

            Print(array);

    #if USE_LOOP
            LOOP:
    #else
            while (true)
            {
    #endif
                int target = rand.Next(array.Length * 10);

                Console.WriteLine("-----------------------------");
                Console.WriteLine("Numero procurado: " + target);

                if (SequentialSearch(array, target))
                {
                    Console.WriteLine("Numero " + target + " encontrado!");
    #if !USE_LOOP
                    break;
    #endif
                }
                else
                {
                    Console.WriteLine("Numero " + target + " nao existe nesse conjunto!");
    #if USE_LOOP
                    goto LOOP;
    #endif
                }
    #if !USE_LOOP
            }
    #endif
                Console.Read();
        }

        static bool SequentialSearch(int[] array, int target)
        {
            int i;

            for (i = 0; i < array.Length; i++)
            {
                // teste para conjuntos ordenados
                if (target < array[i])
                {
                    break;
                }

                if (target == array[i])
                {
                    Console.WriteLine((++i).ToString() + " elemento(s) testado(s).");
                    return true;
                }
            }
            if (i == array.Length)
            {
                Console.WriteLine(i.ToString() + " elemento(s) testado(s).");
            }
            else
            {
                Console.WriteLine((++i).ToString() + " elemento(s) testado(s).");
            }
            return false;
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
