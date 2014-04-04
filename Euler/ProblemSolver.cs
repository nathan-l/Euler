using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class ProblemSolver
    {
        int Problem1()
        {
            int cnt = 1000;
            int totalValue = 0;

            for (int i = 0; i < cnt; i++)
            {
                if ((i % 3) == 0)
                {
                    totalValue = totalValue + i;
                }
                else if ((i % 5) == 0)
                {
                    totalValue = totalValue + i;
                }
            }
            return totalValue;
        }

        int Problem2()
        {
            var n = 0;
            while (Utils.Fibonacci(n) < 4000000)
            {
                n++;
            }
            var result = 0;
            for (int i = 0; i < Utils.FiboValues.Length; i++)
            {
                if (Utils.FiboValues[i] % 2 == 0)
                    result += Utils.FiboValues[i];
            }
            return result;
        }

        long Problem3()
        {
            var primeFactorList = Utils.primeFactors(600851475143);
            return primeFactorList.Max();
        }

        int Problem4()
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
        int Problem5()
        {
            //int i=1;
            //while (!Utils.IsEuclidlyDivisibleByUpTo(i, 20)) i++;
            //return i;
            var myList = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            return Utils.LeastCommonMultiple(myList);
        }

        int Problem6()
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

        long Problem7()
        {
            //limit found empirically :x
            Utils.GetPrimeNumbers(105000);
            return Utils.PrimeNumbers[10000];
        }


        int Problem8()
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
            var fiveChars = "";
            var max = 0;
            for (int i = 0; i < bigNumber.Length - 5; i++)
            {
                fiveChars = bigNumber.Substring(i, 5);
                var e = fiveChars.Select(digit => int.Parse(digit.ToString())).ToList();
                var product = e[0] * e[1] * e[2] * e[3] * e[4];
                if (product > max)
                    max = product;
            }
            return max;
        }

        //TODO optimize this, takes 2sec.
        int Problem9()
        {
            var triplets = Utils.PythagoreanTriplet(999);
            var goodTriplet = new List<int>();
            foreach (var triplet in triplets)
            {
                if (triplet.Sum() == 1000)
                {
                    goodTriplet = triplet;
                    break;
                }
            }
            return goodTriplet[0] * goodTriplet[1] * goodTriplet[2];
        }

        long Problem10()
        {
            var belowX = 2000000;
            var primes = new List<long>();
            for (int i = 2; i < belowX; i++)
            {
                primes.Add(i);
            }

            long currentPrime = 2;
            while (currentPrime <= Math.Sqrt(belowX))
            {
                primes.RemoveAll(x => x % currentPrime == 0 && x != currentPrime);
                currentPrime = primes.First(x => x > currentPrime);
            }

            return primes.Sum();
            //return Utils.PrimeNumberSum(2000000);
        }

        long Problem11()
        {
            string values = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08 " +
"49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00 " +
"81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65 " +
"52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91 " +
"22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 " +
"24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50 " +
"32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 " +
"67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21 " +
"24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 " +
"21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95 " +
"78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92 " +
"16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57 " +
"86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58 " +
"19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40 " +
"04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66 " +
"88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69 " +
"04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36 " +
"20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16 " +
"20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54 " +
"01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
            var arr = values.Split(new[] { ' ' });
            int[,] table2x2 = new int[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                    table2x2[i, j] = int.Parse(arr[i * 20 + j]);
            }
            var max = 0;
            for (int a = 0; a < 20 - 3; a++)
            {
                for (int b = 0; b < 20 - 3; b++)
                {
                    var prodLine = table2x2[a, b] * table2x2[a, b + 1] * table2x2[a, b + 2] * table2x2[a, b + 3];
                    var prodColumn = table2x2[a, b] * table2x2[a + 1, b] * table2x2[a + 2, b] * table2x2[a + 3, b];
                    var tempMax1 = Math.Max(prodLine, prodColumn);
                    var prodDiag = table2x2[a, b] * table2x2[a + 1, b + 1] * table2x2[a + 2, b + 2] * table2x2[a + 3, b + 3];
                    var tempMax2 = Math.Max(tempMax1, prodDiag);
                    var tempMax3 = 0;
                    if (b > 3)
                    {
                        var prodDiagGauche = table2x2[a, b] * table2x2[a + 1, b - 1] * table2x2[a + 2, b - 2] * table2x2[a + 3, b - 3];
                        tempMax3 = Math.Max(tempMax2, prodDiagGauche);
                    }
                    max = Math.Max(max, tempMax3);
                }
            }

            return max;
        }

        long Problem12()
        {
            long triangle = 0;
            for (int i = 0; i < 100000; i++)
            {
                triangle += i;
                var nbDivisor = 0;
                for (int j = 1; j <= Math.Sqrt(triangle); j++)
                {
                    if (triangle % j == 0) nbDivisor += 2;
                }
                if (Math.Sqrt(triangle) * Math.Sqrt(triangle) == triangle) nbDivisor--;
                if (nbDivisor > 500)
                    break;
            }
            return triangle;
        }

        long Problem13()
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\pb13.txt";
            BigInteger result = new BigInteger();
            StreamReader r = new StreamReader(filename);
            string line;
            while ((line = r.ReadLine()) != null)
            {
                result += BigInteger.Parse(line);
            }
            r.Close();
            var retour = result.ToString().Substring(0, 10);
            return long.Parse(retour);
        }
        int Problem14()
        {
            var limit = 1000000;
            var max = 1;
            var result = 1;
            long number;
            var chainLength = 1;
            for (int startingNumber = 1; startingNumber < limit; startingNumber++)
            {
                //code to generate chain
                number = startingNumber;
                chainLength = 1;
                while (number != 1)
                {
                    chainLength++;
                    if (number % 2 == 0) number /= 2;
                    else number = 3 * number + 1;

                }
                if (chainLength > max)
                {
                    max = chainLength;
                    result = startingNumber;
                }
            }
            return result;
        }


        long Problem15()
        {
            //Binomial 20 parmis 40
            var gridSize = 20;

            var grid = new long[gridSize + 1, gridSize + 1];
            for (int i = 0; i < gridSize; i++)
            {
                grid[i, gridSize] = 1;
                grid[gridSize, i] = 1;
            }
            for (int i = gridSize - 1; i >= 0; i--)
            {
                for (int j = gridSize - 1; j >= 0; j--)
                {
                    grid[i, j] = grid[i + 1, j] + grid[i, j + 1];
                }
            }
            return grid[0, 0];
        }

        long Problem16()
        {
            int result = 0;

            BigInteger number = BigInteger.Pow(2, 1000);

            while (number > 0)
            {
                result += (int)(number % 10);
                number /= 10;
            }
            return result;
        }

        long Problem18()
        {
            string filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\problem18.txt";
            string line;
            string[] linePieces;
            int lines = 0;

            StreamReader r = new StreamReader(filename);
            while ((line = r.ReadLine()) != null)
            {
                lines++;
            }

            int[,] inputTriangle = new int[lines, lines];
            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((line = r.ReadLine()) != null)
            {
                linePieces = line.Split(' ');
                for (int i = 0; i < linePieces.Length; i++)
                {
                    inputTriangle[j, i] = int.Parse(linePieces[i]);
                }
                j++;
            }
            r.Close();
            int liness = inputTriangle.GetLength(0);

            for (int i = liness - 2; i >= 0; i--)
            {
                for (int aj = 0; aj <= i; aj++)
                {
                    inputTriangle[i, aj] += Math.Max(inputTriangle[i + 1, aj], inputTriangle[i + 1, aj + 1]);
                }
            }

            return inputTriangle[0,0];
        }
    }
}
