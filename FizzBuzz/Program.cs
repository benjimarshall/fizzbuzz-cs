using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var argsList = new List<string>(args);

            var max = GetMax(argsList);
            // If the arguments weren't parsed, stop
            if (max == null) return;

            var rules = GetRules(argsList);
            // If the arguments weren't parsed, stop
            if (rules == null) return;

            for (int i = 1; i <= max; i++)
            {
                Console.WriteLine(FizzBuzz(i, rules));
            }
        }

        static Dictionary<int, bool> GetRules(List<string> args)
        {
            Dictionary<int, bool> rules;

            if (HasParameter("-r", args))
            {
                var rulesInput = GetParameters("-r", args);

                // If the arguments weren't parsed, stop
                if (rulesInput == null) return null;

                rules = new Dictionary<int, bool>()
                {
                    { 3, false },
                    { 5, false },
                    { 7, false },
                    { 11, false },
                    { 13, false },
                    { 17, false },
                };

                foreach (int ruleNumber in rulesInput)
                {
                    if (rules.Keys.Contains(ruleNumber))
                    {
                        rules[ruleNumber] = true;
                    }
                    else
                    {
                        Console.WriteLine($"Warning: rule {ruleNumber} is not a recognised rule");
                    }
                }
            }
            else
            {
                rules = new Dictionary<int, bool>()
                {
                    { 3, true },
                    { 5, true },
                    { 7, true },
                    { 11, true },
                    { 13, true },
                    { 17, true },
                };
            }

            return rules;
        }

        static int? GetMax(List<string> args)
        {
            int max;
            if (HasParameter("-m", args))
            {
                var maxList = GetParameters("-m", args);

                // If the arguments weren't parsed, stop
                if (maxList == null) return null;

                switch (maxList.Count)
                {
                    case 0:
                        Console.WriteLine("There was no value given for option -m");
                        max = GetMaxFromUser();
                        break;
                    case 1:
                        max = maxList[0];
                        break;
                    default:
                        Console.WriteLine("Warning, more than one argument given for -m");
                        max = maxList[0];
                        break;
                }
            }
            else
            {
                max = GetMaxFromUser();
            }

            return max;
        }

        static bool HasParameter(string optionName, List<string> args)
        {
            return args.Contains(optionName);
        }

        static List<int> GetParameters(string optionName, List<string> args)
        {
            var list = new List<int>();

            var startIndex = args.IndexOf(optionName) + 1;
            var endIndex = args.FindIndex(startIndex, s => s.StartsWith("-"));
            // If no more arguments are found (-1) the set the end index as the end of the list
            endIndex = endIndex == -1 ? args.Count : endIndex;

            for (int currentIndex = startIndex; currentIndex < endIndex; currentIndex++)
            {
                var currentValue = ReadInt(args[currentIndex]);
                if (currentValue == null)
                {
                    Console.WriteLine($"Invalid parameter {args[currentIndex]} for option {optionName}");
                    return null;
                }
                else
                {
                    list.Add(currentValue.Value);
                }
            }

            return list;
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
