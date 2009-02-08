using System;
using System.Collections.Generic;

namespace EulerMath.Integer.Sequence
{
    public class PrimeNumber:ISequence
    {
        private long current = 1;
        private List<long> primes = new List<long>();
        private List<long> squaredPrimes = new List<long>();

        public long Next()
        {
            if (current < 3)
            {
                current++;
            }
            else
            {
                do
                {
                    current += 2;
                } while (IsFactorable(current));
            }
            primes.Add(current);
            squaredPrimes.Add(current * current);
            return current;
        }

        public long Calc(int index)
        {
            var total = index + 1;
            while(total > primes.Count)
            {
                Next();
            }
            return primes[index];
        }

        public bool IsFactorable(long number)
        {
            var index = 1;
            do
            {
                if (number % primes[index] == 0)
                {
                    return true;
                }
                index++;
            } while (index < primes.Count);
            return false;
        }
    }
}
