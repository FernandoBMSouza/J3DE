#define USE_AVENGERS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HashBasedSearch
{
    class Program
    {
    #if USE_AVENGERS
        static string[] avengers = new string[] 
        {
            "Hulk",
            "Ironman",
            "Thor",
            "Captain America",
            "Hawkeye",
            "Blackwidow",
        };
    #else
        static string[] avengers = new string[] 
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "W", "V", "X", "Y", "Z"
        };
    #endif

        static int NUM_CHAR = 4;//avengers.Length;
        static List<string>[] collection = new List<string>[NUM_CHAR];
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("---    HASH  TABLE    ---");
            Console.WriteLine("-------------------------");

            Start();

            Print(collection);

            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine("--- HASH BASED SEARCH ---");
            Console.WriteLine("-------------------------");

            string hero = "Spiderman";
            Console.WriteLine(hero + " : " + (HashSearch(hero) ? "" : "não") + " encontrado");

            hero = avengers[random.Next(avengers.Length)];
            Console.WriteLine(hero + " : " + (HashSearch(hero) ? "" : "não") + " encontrado");

            Console.Read();
        }

        static void Start()
        {
            for (var i = 0; i < avengers.Length; i++)
            {
                int h = HashCode(avengers[i]);

                if (h > -1)
                {
                    if (collection[h] == null)
                    {
                        collection[h] = new List<string>();
                    }

                    collection[h].Add(avengers[i]);
                }
            }
        }

        static int HashCode(string value)
        {           
            if (value.Length > 0)
            {
                int result = Math.Abs(value[0]) % NUM_CHAR;
                Console.WriteLine(value + ": " + (int)value[0] + " - " + result);
                return result;
            }

            return -1;
        }


        static bool HashSearch(string value)
        {
            int h = HashCode(value);

            if (h > -1 && collection[h] != null) {
                foreach (string s in collection[h]) {
                    if (s == value) {
                        return true;
                    }
                }
            }
            return false;
        }


        static void Print(List<string>[] collection)
        {
            var i = 0;

            foreach (List<string> l in collection)
            {
                Console.Write("[" + i++ + "] : ");

                if (l != null)
                {
                    // insira o tipo de pesquisa que julgue
                    // mais interessante para o problema 
                    foreach (string s in l)
                    {
                        Console.Write(s + ", ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
