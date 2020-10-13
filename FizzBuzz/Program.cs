using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = GetMaxFromUser();
            var rules = new Dictionary<int, bool>()
            {
                { 3, true },
                { 5, true },
                { 7, true },
                { 11, true },
                { 13, true },
                { 17, true },
            };
            for (int i = 1; i <= max; i++)
            {
                Console.WriteLine(FizzBuzz(i, rules));
            }
        }

        static int GetMaxFromUser()
        {
            while (true)
            {
                Console.Write("Maximum FizzBuzz number: ");

                var inputInt = ReadInt(Console.ReadLine());
                if (inputInt == null)
                {
                    Console.WriteLine("Please enter an integer.");
                }
                else if (inputInt >= 1)
                {
                    return inputInt.Value;
                }
                else
                {
                    Console.WriteLine("Please enter an integer >= 1.");
                }
            }
        }

        static int? ReadInt(string inputLine)
        {
            try
            {
                return int.Parse(inputLine);
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        static string FizzBuzz(int i, Dictionary<int, bool> rules)
        {
            var results = new List<string>();
            if (i % 3 == 0 && rules[3])
            {
                results.Add("Fizz");
            }

            if (i % 5 == 0 && rules[5])
            {
                results.Add("Buzz");
            }

            if (i % 7 == 0 && rules[7])
            {
                results.Add("Bang");
            }

            if (i % 11 == 0 && rules[11])
            {
                results.Clear();
                results.Add("Bong");
            }

            if (i % 13 == 0 && rules[13])
            {
                var firstBIndex = results.FindIndex(s => s.StartsWith("B"));

                // If none of the strings start with a "B" then index == -1
                // So change index to be the end of the list to append "Fezz" to
                firstBIndex = firstBIndex == -1 ? results.Count : firstBIndex;

                results.Insert(firstBIndex, "Fezz");
            }

            if (i % 17 == 0 && rules[17])
            {
                results.Reverse();
            }

            if (!results.Any())
            {
                results.Add(i.ToString());
            }

            return String.Join("", results);
        }
    }
}
