using System;

namespace Summator
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = Summator.Sum(new int[] { 10, 20, 30 });

            if (result == 60)
            {
                Console.WriteLine("THE TEST PASS");
            }
            else
            {
                Console.WriteLine("THE TEST FAIL");
            }

            int averageResult = Summator.Average(new int[] { 10, 20, 30 });

            if (averageResult == 20)
            {
                Console.WriteLine("THE TEST PASS");
            }
            else
            {
                Console.WriteLine("THE TEST FAIL");
            }

            int evenSum = Summator.EvenNumbers(new int[] { 2, 7, 10, 17, 28, 33, 46, 148, 232 });

            if (evenSum == 466)
            {
                Console.WriteLine("THE TEST PASS");
            }
            else
            {
                Console.WriteLine("THE TEST FAIL");
            }

        }
    }
}
