using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;

namespace ContactBook.AndroidTests
{
    public class Adroid_Tests
    {
        private const string AppiumUrl = "http://127.0.0.1:4723/wd/hub";
        private const string ContactsBookUrl = "https://contactbook.nakov.repl.co/api";
        private const string appLocation = @"C:\Work\contactbook-androidclient.apk";

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void StartApp()
        {
            options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", appLocation);

            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumUrl), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
            [TearDown]
        public void CloseApp()
        {
            driver.Quit();
        }

        [Test]
        public void Test_SearchContact_VerifyFirstResult()
        {
            var urlField = driver.FindElement(By.Id("contactbook.androidclient:id/editTextApiUrl"));
            urlField.Clear();
            urlField.SendKeys(ContactsBookUrl);

            var connectButton = driver.FindElement(By.Id("contactbook.androidclient:id/buttonConnect"));
            connectButton.Click();

            var editTextButton = driver.FindElement(By.Id("contactbook.androidclient:id/editTextKeyword"));
            editTextButton.Clear();
            editTextButton.SendKeys("steve");

            var buttonSearch = driver.FindElement(By.Id("contactbook.androidclient:id/buttonSearch"));
            buttonSearch.Click();

            var firstName = driver.FindElement(By.Id("contactbook.androidclient:id/textViewFirstName"));
            var lastName = driver.FindElement(By.Id("contactbook.androidclient:id/textViewLastName")).Text;

            Assert.That(firstName.Text, Is.EqualTo("Steve"));
            Assert.That(lastName, Is.EqualTo("Jobs"));
        }
    }
}