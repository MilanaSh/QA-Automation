using Calc.NumbersPage;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace SumNumbers_Tests
{
    public class Tests
    {
        private ChromeDriver driver;

        public object FieldNum1 { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void Close()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Valid_Numbers()
        {
            var sumpage = new SumNumbersPage(this.driver);
            sumpage.OpenPage();
            var result = sumpage.AddNumbers("5", "6");

            Assert.That(result, Is.EqualTo("Sum: 11"));
        }
        [TestCase("3", "10", "Sum: 13")]
        [TestCase("1.4", "10", "Sum: 11.4")]
        [TestCase("-3", "-9", "Sum: -12")]
        [TestCase("3", "-3", "Sum: 0")]
        public void TestCases(string num1, string num2, string result)
        {
            var sumpage = new SumNumbersPage(this.driver);
            sumpage.OpenPage();

            var results = sumpage.AddNumbers(num1, num2);

            Assert.That(results, Is.EqualTo(result));

            sumpage.ResetPage();
            
        }

        [TestCase("aa", "aaa", "Sum: invalid input")]
        [TestCase("mmm", "10", "Sum: invalid input")]
        [TestCase("1.001e+37", "dd", "Sum: invalid input")]
        public void Test_Invalid_Input(string num1, string num2, string result)
        {
            var sumpage = new SumNumbersPage(this.driver);
            sumpage.OpenPage();

            var results = sumpage.AddNumbers(num1, num2);

            Assert.That(results, Is.EqualTo(result));

            sumpage.ResetPage();

        }

        [TestCase("1.001e+37", "1.001e+37", "Sum: 2.002e+37")]
        [TestCase("1.001e+37", "2.002e+37", "Sum: 3.003e+37")]        
        public void Test_Special_Input(string num1, string num2, string result)
        {
            var sumpage = new SumNumbersPage(this.driver);
            sumpage.OpenPage();

            var results = sumpage.AddNumbers(num1, num2);

            Assert.That(results, Is.EqualTo(result));

            sumpage.ResetPage();

        }
    }
}