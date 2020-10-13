using System;
using System.Text;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                StringBuilder result = new StringBuilder();
                if (i % 3 == 0)
                {
                    result.Append("Fizz");
                }

                if (i % 5 == 0)
                {
                    result.Append("Buzz");
                }

                if (i % 7 == 0)
                {
                    result.Append("Bang");
                }

                if (i % 11 == 0)
                {
                    result.Clear();
                    result.Append("Bong");
                }

                if (result.Length == 0)
                {
                    result.Append(i);
                }

                Console.WriteLine(result);
            }
        }
    }
}
