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
                StringBuilder sb = new StringBuilder();
                if (i % 3 == 0)
                {
                    sb.Append("Fizz");
                }
                if (i % 5 == 0)
                {
                    sb.Append("Buzz");
                }
                
                if (sb.Length == 0)
                {
                    sb.Append(i);
                }

                Console.WriteLine(sb);
            }
        }
    }
}
