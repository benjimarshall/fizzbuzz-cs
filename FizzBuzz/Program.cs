﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = GetMaxFromUser();
            for (int i = 1; i <= max; i++)
            {
                Console.WriteLine(FizzBuzz(i));
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
                    return (int)inputInt;
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

        static string FizzBuzz(int i)
        {
            var results = new List<string>();
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
                var firstBIndex = results.FindIndex(s => s.StartsWith("B"));

                // If none of the strings start with a "B" then index == -1
                // So change index to be the end of the list to append "Fezz" to
                firstBIndex = firstBIndex == -1 ? results.Count : firstBIndex;

                results.Insert(firstBIndex, "Fezz");
            }

            if (i % 17 == 0)
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
