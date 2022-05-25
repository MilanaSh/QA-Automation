using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wikipedia_Tests
{
    public class SeleniumTests
    {
  
        [Test]
        public void Test_SearchForQA_Wiki()
        {
            var driver = new ChromeDriver();

            driver.Url = "https://wikipedia.org";

            driver.FindElement(By.Id("searchInput")).Click();

            driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);
            
            var expected = "https://en.wikipedia.org/wiki/Quality_assurance";
            
            Assert.That(expected, Is.EqualTo(driver.Url));

            driver.Quit();
        }

        [Test]
        public void Test_Find_QAHistory_Button_Wiki()
        {
            var driver = new ChromeDriver();

            driver.Url = "https://wikipedia.org";

            driver.FindElement(By.Id("searchInput")).Click();

            driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);

            driver.FindElement(By.Id("ca-history")).Click();


            var expected = "https://en.wikipedia.org/w/index.php?title=Quality_assurance&action=history";

            Assert.That(expected, Is.EqualTo(driver.Url));

            driver.Quit();
        }
    }
}