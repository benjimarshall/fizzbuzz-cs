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

                if (results.Count == 0)
                {
                    results.Add(i.ToString());
                }

                Console.WriteLine(String.Join("", results));
            }
        }
    }
}
