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

            Console.WriteLine(
              string.Join("\n",
                Enumerable.Range(1, max)
                  .Zip(Enumerable.Repeat("", max)) // Produce list of form [(1, ""), (2, ""), ...
                  .Select<(int n, string message), (int, string)>(tuple => (tuple.n, tuple.message + (tuple.n % 3 == 0 ? "Fizz" : "")))
                  .Select<(int n, string message), (int, string)>(tuple => (tuple.n, tuple.message + (tuple.n % 5 == 0 ? "Buzz" : "")))
                  .Select<(int n, string message), (int, string)>(tuple => (tuple.n, tuple.message + (tuple.n % 7 == 0 ? "Bang" : "")))
                  // Add numbers in if they are not Fizz/Buzz/Bang
                  .Select<(int n, string message), (int, string)>(tuple => (tuple.n, tuple.message == "" ? tuple.n.ToString() : x.msg))
                  .Select<(int n, string message), string>(tuple => tuple.message.ToString())
              )
            );
        }
    }
}
