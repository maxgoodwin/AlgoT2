using System;

namespace Tut2
{
    class Program
    {
        private static int SortAnalysis(int[] array)
        {
            int count = 0;
            int n = array.Length;

            for (int i = 1; i < n; i++)
            {
                int v = array[i];
                int j = i - 1;

                while (j >= 0 && ++count > 0 && array[j] > v) // count increment needs to occur before count i.e. ++count rather than count++. In the case of count++, the comparison is made before count is incremented
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = v;
            }

            return count;
        }

        private static double ArrayAnalysis(int noOfArrays, int startingArraySize, int increment, int randSize = 1000)
        {
            Random randomNum = new Random();
            double bigO;
            double average = 0;
            int[] results = new int[noOfArrays];
            int largestArraySize = startingArraySize + ((noOfArrays - 1) * increment);

            // Create random arrays of sizes startingArraySize to largestArraySize, incremented by 1000
            for (int i = startingArraySize; i <= largestArraySize; i += increment)
            {
                int[] myArray = new int[i];

                for (int j = 0; j < i; j++)
                {
                    int ranInt = randomNum.Next(0, randSize);
                    myArray[j] = ranInt;
                }

                results[(i / startingArraySize) - 1] = SortAnalysis(myArray);
                Console.WriteLine("Array of input size {0:d} comparisons = {1:d}", i, results[(i / startingArraySize) - 1]);

                if (i % (startingArraySize * 2) == 0)
                {
                    bigO = (double)results[(i / startingArraySize) - 1] / results[((i / startingArraySize) / 2) - 1];
                    //Console.WriteLine("Efficiency is {0}", bigO);
                    average += bigO;
                }
            }

            average /= increment/2;
            Console.WriteLine();
            Console.WriteLine("The efficiency is {0}", average);

            return average;

        }

        static void Main(string[] args)
        {

            ArrayAnalysis(20, 1000, 1000);

            /*
            Random randomNum = new Random();
            //int numberOfArrays = 20;
            double bigO;
            double average = 0;
            int[] results = new int[20];

            // Create random arrays of sizes 1000 to 20000, incremented by 1000
            for (int i = 1000; i <= 20000; i+= 1000)
            {
                int[] myArray = new int[i];

                for (int j = 0; j < i; j++)
                {
                    int ranInt = randomNum.Next(0, 1000);
                    myArray[j] = ranInt;
                }

                results[(i / 1000) - 1] = SortAnalysis(myArray);
                Console.WriteLine("Array of input size {0:d} comparisons = {1:d}", i, results[(i / 1000) - 1]);

                if (i % 2000 == 0)
                {
                    bigO = (double) results[(i / 1000) - 1] / results[((i / 1000) / 2) - 1];
                    //Console.WriteLine("Efficiency is {0}", bigO);
                    average += bigO;
                }
            }

            average /= 10;
            Console.WriteLine();
            Console.WriteLine("The efficiency is {0}", average);
            */

        }
    }
}
