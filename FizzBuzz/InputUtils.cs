using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class InputUtils
    {
        public static Dictionary<int, bool> GetRules(List<string> args)
        {
            if (HasParameter("-r", args))
            {
                var rulesInput = GetValuesFromCmdArguments("-r", args);

                var rules = ParseRulesInput(rulesInput);
                if (rules != null) return rules;
            }

            // If the input parsing failed somewhere, or if no argument was provided, enable all rules
            return new Dictionary<int, bool>()
            {
                {3, true},
                {5, true},
                {7, true},
                {11, true},
                {13, true},
                {17, true},
            };
        }

        static Dictionary<int, bool> ParseRulesInput(List<int> rulesInput)
        {
            // If the arguments weren't parsed, stop
            if (rulesInput == null) return null;

            var rules = new Dictionary<int, bool>()
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

            return rules;
        }

        public static int GetMax(List<string> args)
        {
            if (HasParameter("-m", args))
            {
                var maxList = GetValuesFromCmdArguments("-m", args);

                var max = ParseMaxInput(maxList);

                if (max != null) return max.Value;
            }

            // If the input parsing failed somewhere, or if no argument was provided, ask the user directly
            return GetMaxFromUser();
        }

        static int? ParseMaxInput(List<int> maxInput)
        {
            // If the arguments weren't parsed, stop
            if (maxInput == null) return null;

            switch (maxInput.Count)
            {
                case 0:
                    Console.WriteLine("There was no value given for option -m");
                    return null;
                case 1:
                    return maxInput[0];
                default:
                    Console.WriteLine("Warning, more than one argument given for -m");
                    return maxInput[0];
            }
        }

        static bool HasParameter(string optionName, List<string> args)
        {
            return args.Contains(optionName);
        }

        static List<int> GetValuesFromCmdArguments(string optionName, List<string> args)
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

    }
}
