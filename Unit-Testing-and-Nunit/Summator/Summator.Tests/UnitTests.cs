using NUnit.Framework;

namespace Summator.Tests
{
    public class Tests
    {
        [Test]
        public void Test_Sum_TwoPossitiveNumbers()
        {
            long result = Summator.Sum(new int[] { 6, 4 });

            Assert.That(result == 10);
        }

        [Test]
        public void Test_Sum_FourPossitiveNumbers()
        {
            long actual = Summator.Sum(new int[] { 6, 4, 5, 7 });
            int expected = 22;

            Assert.That(actual == expected);
        }
        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            long actual = Summator.Sum(new int[] { -1, -7 });

            Assert.That(actual == -8);
        }

        [Test]
        public void Test_Sum_NegativeAndPossitiveNumbers()
        {
            long actual = Summator.Sum(new int[] { -10, 5 });

            Assert.That(actual == -5);
        }

        [Test]
        public void Test_Sum_EmptyArray()
        {
            long actual = Summator.Sum(new int[] { });

            Assert.That(actual == 0);
        }
        [Test]
        public void Test_Sum_BigNumers()
        {
            long actual = Summator.Sum(new int[] { 1000000000, 2000000000, 2000000000 });
            long expected = 5000000000;

            Assert.That(actual == expected);
        }
        [Test]
        public void Test_Average_FivePossitiveNumbers()
        {
            long actual = Summator.Average(new int[] { 10, 15, 20, 25, 30 });
            long expected = 20;

            Assert.That(actual == expected);
        }
        [Test]
        public void Test_Average_NegativePossitiveNumbers()
        {
            long actual = Summator.Average(new int[] { -10, 20 });
            long expected = 5;

            Assert.That(actual == expected);
        }
        [Test]
        public void Test_Average_NegativeNumbers()
        {
            long actual = Summator.Average(new int[] { -100, -80, - 34, -22 });
            long expected = -59;

            Assert.That(actual == expected);
        }

        [Test]
        public void Test_Average_EvenPossitiveNumbers()
        {
            long actual = Summator.Average(new int[] { 122, 146, 178, 110 });
            long expected = 139;

            Assert.That(actual == expected);
        }
        [Test]
        public void Test_Average_EvenOddPossitiveNumbers()
        {
            long actual = Summator.Average(new int[] { 7, 8 });
            long expected = 7;

            Assert.That(actual == expected);
        }

        [Test]
        public void Test_EvenSum_ThreeNumbers()
        {
            long actual = Summator.EvenNumbers(new int[] { 9, 6, 20 });
            long expected = 26;

            Assert.That(actual == expected);
        }

        [Test]
        public void Test_EvenSum_BigNumbers()
        {
            long actual = Summator.EvenNumbers(new int[] { 180000, 12369871, 235698, 456986, 2000000038 });
            long expected = 2000872722;

            Assert.That(actual == expected);
        }

    }
}