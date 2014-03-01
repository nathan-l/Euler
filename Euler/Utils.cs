using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    static class Utils
    {
        public static int[] FiboValues { get; private set; }

        public static int Fibonacci(int n)
        {
            if (FiboValues == null)
                FiboValues = new int[50];
            if (n <= 1) return 1;
            else
            {
                if (FiboValues[n] != 0) return FiboValues[n];
                else
                {
                    FiboValues[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                    return FiboValues[n];
                }
            }
        }

        public static List<long> primeFactors(long number)
        {
            long n = number;
            List<long> factors = new List<long>();
            for (long i = 2; i <= n; i++)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }
            return factors;
        }

        public static bool IsPalindrome(int number)
        {
            string nbToString = number.ToString();
            for (int i = 0; i < nbToString.Length / 2; i++)
            {
                if (nbToString[i] != nbToString[nbToString.Length-1 - i])
                    return false;
            }
            return true;
        }

        public static bool IsEuclidlyDivisibleBy(int number, int divider)
        {

            var f = (double)number / (double)divider;
            if (f%1!=0) return false;
            else return true;
        }

        public static bool IsEuclidlyDivisibleByUpTo(int number, int divider)
        {
            for (int i = 1; i <= divider; i++)
                if (!IsEuclidlyDivisibleBy(number, i)) return false;
            return true;
        }

        public static int LeastCommonMultiple(int[] numbers)
        {
            int lcm = 1;
            //lcm = LeastCommonMultiple(numbers[0], numbers[1]);

            for (int i = 0; i < numbers.Length;i++ )
            {
                lcm = LeastCommonMultiple(lcm, numbers[i]);
            }
            return lcm;
        }

        public static int LeastCommonMultiple(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }

        private static List<int> _primeNumbers = new List<int>();
        public static List<int> PrimeNumbers { get { return _primeNumbers; } set { _primeNumbers = value; } }

        public static List<int> GetPrimeNumbers(int limit)
        {
            //Sieve of Erathostene
            bool[] isPrime = new bool[limit + 1];
            for (int i = 2; i <= limit; i++)
            {
                isPrime[i] = true;
            }

            // mark non-primes <= N using Sieve of Eratosthenes
            for (int i = 2; i * i <= limit; i++)
            {
                // if i is prime, then mark multiples of i as nonprime
                // suffices to consider mutiples i, i+1, ..., N/i
                if (isPrime[i])
                {
                    for (int j = i; i * j <= limit; j++)
                    {
                        isPrime[i * j] = false;
                    }
                }
            }

            // count primes
            for (int i = 2; i <= limit; i++)
            {
                if (isPrime[i] && !PrimeNumbers.Contains(i)) PrimeNumbers.Add(i) ;
            }
            return PrimeNumbers;
        }

        public static bool IsPrime(int number)
        {
            var list = GetPrimeNumbers(number);
            return list.Contains(number);
        }
    }
}
