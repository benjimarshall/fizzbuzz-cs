using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz
{
    class FizzBuzzer : IEnumerator<string>
    {
        private int sequencePosition = 0;
        private readonly int max;
        private readonly Dictionary<int, bool> rules;

        public FizzBuzzer(int max, Dictionary<int, bool> rules)
        {
            this.max = max;
            this.rules = rules;
        }

        public bool MoveNext()
        {
            if (sequencePosition < max)
            {
                sequencePosition++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            sequencePosition = 0;
        }

        private static string FizzBuzz(int i, Dictionary<int, bool> rules)
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

            return string.Join("", results);
        }

        public string Current => FizzBuzz(sequencePosition, rules);

        object? IEnumerator.Current => Current;

        public void Dispose() { }
    }
}
