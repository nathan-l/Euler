using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Program
    {

        static void Main(string[] args)
        {
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 2 :" + Problem2());
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 3 :" + Problem3());
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 4 :" + Problem4());
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 5 :" + Problem5());
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 6 :" + Problem6());
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 7 :" + Problem7());
            Debug.WriteLine("\n------------------------------------\n");
            Debug.WriteLine("Problem 8 :" + Problem8());
        }

        static int Problem2()
        {
            var n = 0;
            while (Utils.Fibonacci(n) < 4000000)
            {
                n++;
            }
            Debug.WriteLine("le n = " + n);
            var result = 0;
            for (int i = 0; i < Utils.FiboValues.Length; i++)
            {
                if (Utils.FiboValues[i] % 2 == 0)
                    result += Utils.FiboValues[i];
            }
            return result;
        }

        static long Problem3()
        {
            var primeFactorList = Utils.primeFactors(600851475143);
            return primeFactorList.Max();
        }

        static int Problem4()
        {
            var products = new List<int>();
            for (int nb1 = 1; nb1 < 1000; nb1++)
                for (int nb2 = nb1; nb2 < 1000; nb2++)
                    products.Add(nb1 * nb2);

            var lastPalindrome = 0;
            foreach (var nb in products)
            {
                if (Utils.IsPalindrome(nb) && nb > lastPalindrome) lastPalindrome = nb;
            }
            return lastPalindrome;
        }

        //TODO : better algo, its so slow
        static int Problem5()
        {
            //int i=1;
            //while (!Utils.IsEuclidlyDivisibleByUpTo(i, 20)) i++;
            //return i;
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            return Utils.LeastCommonMultiple(myList);
        }

        static int Problem6()
        {
            var sumOfSquare = 0;
            var squareOfSum = 0;
            for (int i = 0; i <= 100; i++)
            {
                sumOfSquare += i * i;
                squareOfSum += i;
            }
            squareOfSum *= squareOfSum;
            return squareOfSum - sumOfSquare;
        }

        static int Problem7()
        {
            //limit found empirically :x
            Utils.GetPrimeNumbers(105000);
            return Utils.PrimeNumbers[10000];
        }


		static int Problem8()
		{
			string bigNumber = "73167176531330624919225119674426574742355349194934" +
                                "96983520312774506326239578318016984801869478851843" +
                                "85861560789112949495459501737958331952853208805511" +
                                "12540698747158523863050715693290963295227443043557" +
                                "66896648950445244523161731856403098711121722383113" +
                                "62229893423380308135336276614282806444486645238749" +
                                "30358907296290491560440772390713810515859307960866" +
                                "70172427121883998797908792274921901699720888093776" +
                                "65727333001053367881220235421809751254540594752243" +
                                "52584907711670556013604839586446706324415722155397" +
                                "53697817977846174064955149290862569321978468622482" +
                                "83972241375657056057490261407972968652414535100474" +
                                "82166370484403199890008895243450658541227588666881" +
                                "16427171479924442928230863465674813919123162824586" +
                                "17866458359124566529476545682848912883142607690042" +
                                "24219022671055626321111109370544217506941658960408" +
                                "07198403850962455444362981230987879927244284909188" +
                                "84580156166097919133875499200524063689912560717606" +
                                "05886116467109405077541002256983155200055935729725" +
                                "71636269561882670428252483600823257530420752963450";
            var fiveChars="";
            var max =0;
            for (int i = 0; i < bigNumber.Length-5;i++ )
            {
                fiveChars = bigNumber.Substring(i, 5);
                var e = fiveChars.Select(digit => int.Parse(digit.ToString())).ToList();
                var product = e[0] * e[1] * e[2] * e[3] * e[4];
                if(product > max)
                    max = product;
            }
                return max;
        }

    }
}
