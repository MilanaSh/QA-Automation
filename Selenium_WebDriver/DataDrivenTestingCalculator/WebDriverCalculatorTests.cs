using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests
    {
        private ChromeDriver driver;        
        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultfield;
        IWebElement clearField;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            field1 = driver.FindElement(By.Id("number1"));
            field2 = driver.FindElement(By.Id("number2"));
            operation = driver.FindElement(By.Id("operation"));
            calculate = driver.FindElement(By.Id("calcButton"));
            clearField = driver.FindElement(By.Id("resetButton"));
            resultfield = driver.FindElement(By.Id("result"));

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestCase("7", "+", "3", "Result: 10")]
        [TestCase("11", "+", "11", "Result: 22")]
        [TestCase("0", "+", "1", "Result: 1")]
        [TestCase("0", "+", "0", "Result: 0")]
        [TestCase("5", "+", "-6", "Result: -1")]
        [TestCase("-13", "+", "-65", "Result: -78")]
        public void Test_Add_Valid_Integers(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }

        [TestCase("7", "-", "3", "Result: 4")]
        [TestCase("11", "-", "11", "Result: 0")]
        [TestCase("0", "-", "1", "Result: -1")]
        [TestCase("-18", "-", "-1", "Result: -17")]
        public void Test_Subtract_Valid_Integers(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }

        [TestCase("10", "*", "3", "Result: 30")]
        [TestCase("11", "*", "-1", "Result: -11")]
        [TestCase("0", "*", "1", "Result: 0")]
        [TestCase("-18", "*", "-1", "Result: 18")]
        public void Test__MultiPlyValid_Integers(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }

        [TestCase("10", "/", "5", "Result: 2")]
        [TestCase("110", "/", "-10", "Result: -11")]
        [TestCase("0", "/", "1", "Result: 0")]
        [TestCase("18", "/", "0", "Result: Infinity")]
        [TestCase("-76", "/", "-2", "Result: 38")]
        public void Test__DivideValid_Integers(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }

        [TestCase("10.33333", "+", "5.689", "Result: 16.02233")]
        [TestCase("110.38", "/", "-10", "Result: -11.038")]
        [TestCase("0", "-", "-23598.36", "Result: 23598.36")]       
        public void Test__Calc_RealNum(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }

        [TestCase("hello", "+", "5.689", "Result: invalid input")]
        [TestCase("alalabala", "/", "tralalal", "Result: invalid input")]
        public void Test__Calc_InvalidInput(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }

        [TestCase("10", "add", "10", "Result: invalid operation")]
        [TestCase("1000", "@", "23", "Result: invalid operation")]
        public void Test__Calc_InvalidOperation(string num1, string operat, string num2, string result)
        {
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);

            calculate.Click();

            Assert.That(result, Is.EqualTo(resultfield.Text));

            clearField.Click();
        }
    }

}