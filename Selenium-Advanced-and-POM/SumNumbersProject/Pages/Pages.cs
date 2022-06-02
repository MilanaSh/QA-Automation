
using OpenQA.Selenium;
using System;

namespace Calc.NumbersPage
{
    public class SumNumbersPage
    {
        private readonly IWebDriver driver;

        public SumNumbersPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        const string PageUrl = "https://sum-numbers.nakov.repl.co";

        public IWebElement FieldNum1 => driver.FindElement(By.Id("number1"));
        public IWebElement FieldNum2 => driver.FindElement(By.Id("number2"));
        public IWebElement CalcButton => driver.FindElement(By.Id("calcButton"));
        public IWebElement ResetButton => driver.FindElement(By.Id("resetButton"));
        public IWebElement ResultField => driver.FindElement(By.CssSelector("#result"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
        public void ResetPage()
        {
            ResetButton.Click();
        }

        public string AddNumbers(string num1, string num2)
        {
            FieldNum1.SendKeys(num1);
            FieldNum2.SendKeys(num2);
            CalcButton.Click();
            string result = ResultField.Text;
            return result;
        }
        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + ResultField.Text == "";
        }
    }
}