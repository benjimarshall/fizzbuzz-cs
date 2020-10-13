using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                List<string> results = new List<string>();
                if (i % 3 == 0)
                {
                    results.Add("Fizz");
                }

                if (i % 5 == 0)
                {
                    results.Add("Buzz");
                }

                if (i % 7 == 0)
                {
                    results.Add("Bang");
                }

                if (i % 11 == 0)
                {
                    results.Clear();
                    results.Add("Bong");
                }

                if (i % 13 == 0)
                {
                    var index = results.FindIndex(s => s.StartsWith("B"));

                    // If none of the strings start with a "B" then index == -1
                    // So change index to be the end of the list to append "Fezz" to
                    index = index == -1 ? results.Count : index;

                    results.Insert(index, "Fezz");
                }

                if (results.Count == 0)
                {
                    results.Add(i.ToString());
                }

                Console.WriteLine(String.Join("", results));
            }
        }
    }
}
