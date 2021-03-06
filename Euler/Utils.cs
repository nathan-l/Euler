﻿using System;
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

        private static List<long> _primeNumbers = new List<long>();
        public static List<long> PrimeNumbers { get { return _primeNumbers; } set { _primeNumbers = value; } }

        public static List<long> GetPrimeNumbers(int limit)
        {
            //for (long number = 2; number < limit; number++)
            //{
            //    bool isPrime = true;
            //    double sqrt = Math.Sqrt(number);
            //    for (int mod = 2; mod <= sqrt; mod++)
            //    {
            //        if (number % mod == 0)
            //        {
            //            isPrime = false;
            //            break;
            //        }
            //    }
            //    if (isPrime)
            //    {
            //        PrimeNumbers.Add(number);
            //    }
            //}
            //return PrimeNumbers;

            for (int i = 2; i < limit; i++)
            {
                PrimeNumbers.Add(i);
            }

            long currentPrime = 2;
            while (currentPrime <= Math.Sqrt(limit))
            {
                PrimeNumbers.RemoveAll(x => x % currentPrime == 0 && x != currentPrime);
                currentPrime = PrimeNumbers.First(x => x > currentPrime);
            }
            return PrimeNumbers;
        }

        public static bool IsPrime(int number)
        {
            var list = GetPrimeNumbers(number);
            return list.Contains(number);
        }


        public static List<List<int>> PythagoreanTriplet(int limit)
        {
            var list = new List<List<int>>();
            for (int i = 2; i <= limit; i++)
                for (int j = i; j <= limit; j++)
                    for (int k = 2; k <= limit; k++)
                        if (i * i + j * j - k * k == 0) list.Add(new List<int> { i, j, k });
            return list;
        }

        public static long PrimeNumberSum(int limit)
        {
            long sum = 0;
            for (long number = 2; number < limit; number++)
            {
                bool isPrime = true;
                double sqrt = Math.Sqrt(number);
                for (int mod = 2; mod <= sqrt; mod++)
                {
                    if (number % mod == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    sum += number;
                }
            }
            return sum;
        }
    }
}
