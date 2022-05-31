using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace WaitSamples
{
    public class Examples
    {
        private WebDriver driver;
        private WebDriverWait wait;


        [Test]
        public void Test_Wait_Thread_Sleep()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            var link = driver.FindElement(By.PartialLinkText("This is"));
            link.Click();

            Thread.Sleep(15000);
            var element = driver.FindElement(By.ClassName("ContactUs")).Text;
            // Assert.IsNotNull(element);
            StringAssert.Contains("Selenium is a portable", element);

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            driver.FindElement(By.PartialLinkText("This is")).Click();

            Thread.Sleep(15000);
            var element1 = driver.FindElement(By.ClassName("ContactUs")).Text;
            StringAssert.Contains("Selenium is a portable", element1);

            driver.Quit();
        }

        [Test]
        public void Test_Wait_ImplicitWait()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            var link = driver.FindElement(By.PartialLinkText("This is"));
            link.Click();

            var element = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsNotNull(element);
            StringAssert.Contains("Selenium is a portable", element);

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var element1 = driver.FindElement(By.ClassName("ContactUs")).Text;
            Assert.IsNotNull(element1);
            StringAssert.Contains("Selenium is a portable", element1);

            driver.Quit();
        }

        [Test]

        public void Test_Wait_ExplicitWait()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");
            var link = driver.FindElement(By.PartialLinkText("This is"));
            link.Click();

            var element = this.wait.Until(d =>
          {
              return d.FindElement(By.ClassName("ContactUs")).Text;
          });

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            driver.FindElement(By.PartialLinkText("This is")).Click();


            var element1 = this.wait.Until(d =>
            {
                return d.FindElement(By.ClassName("ContactUs")).Text;
            });

            Assert.IsNotNull(element1);
            StringAssert.Contains("Selenium is a portable", element1);

            driver.Quit();

        }


        [Test]
        public void Test_Wait_UsingExtras()
        {
            this.driver = new ChromeDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            var link = driver.FindElement(By.PartialLinkText("This is"));
            link.Click();

            var element = this.wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs"))).Text;

            Assert.IsNotNull(element);
            StringAssert.Contains("Selenium is a portable", element);

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Contact");

            driver.FindElement(By.PartialLinkText("This is")).Click();

            var element1 = this.wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("ContactUs"))).Text;

            Assert.IsNotNull(element1);
            StringAssert.Contains("Selenium is a portable", element1);


            driver.Quit();
        }
    }
}