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

            var max = InputUtils.GetMax(argsList);

            var rules = InputUtils.GetRules(argsList);

            FizzBuzzGame game = new FizzBuzzGame(max, rules);

            foreach (var value in game)
            {
                Console.WriteLine(value);
            }
        }
    }
}
