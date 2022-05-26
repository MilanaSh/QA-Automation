using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class Chitanka
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            driver = new ChromeDriver();
            driver.Url = "http://chitanka.info/";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }


        [Test]
        public void Test_AssertMainPageTitle()
        {
            var expextedTitle = "Моята библиотека";

            Assert.That(driver.Title, Is.EqualTo(expextedTitle));
        }

        [Test]
        public void Test_AssertAuthorsPageTitle()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/nav/div[4]/div[1]/ul/li[1]/a")).Click();

            var expextedUrl = "http://chitanka.info/authors";
       
            Assert.That(driver.Url, Is.EqualTo(expextedUrl));
            
        }

        [Test]
        public void Test_SearchField_Manual()
        {
            var searchBar = driver.FindElement(By.Id("q"));
            searchBar.Click();

            searchBar.SendKeys("Agatha Christie" + Keys.Enter);

            var expexted = "Търсене на „Agatha Christie“ — Моята библиотека";

            Assert.That(driver.Title, Is.EqualTo(expexted));
        }

        [Test]
        public void testLoginInvalidUsernameAndPassword()
        {
            driver.Navigate().GoToUrl("http://chitanka.info/");
            driver.Manage().Window.Size = new System.Drawing.Size(1382, 744);
            driver.FindElement(By.LinkText("Вход")).Click();
            driver.FindElement(By.Id("username")).SendKeys("user123");
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys("user123");
            driver.FindElement(By.CssSelector(".btn-lg")).Click();
            driver.FindElement(By.CssSelector(".messages")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".messages")).Text, Is.EqualTo("Не съществува потребител с име user123."));

        }
    }
}