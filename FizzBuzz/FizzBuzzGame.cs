using System.Collections;
using System.Collections.Generic;

namespace FizzBuzz
{
    class FizzBuzzGame : IEnumerable<string>
    {
        private readonly int max;
        private readonly Dictionary<int, bool> rules;

        public FizzBuzzGame(int max, Dictionary<int, bool> rules)
        {
            this.max = max;
            this.rules = rules;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new FizzBuzzer(max, rules);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
