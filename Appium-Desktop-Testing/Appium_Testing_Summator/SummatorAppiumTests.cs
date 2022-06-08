using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;

namespace Appium_Testing_Summator
{
    public class SummatorAppiumTests
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\SummatorDesktopApp.exe");
            
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [TearDown]
        public void TearDown ()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_SumTwoPossitiveNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("10");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("16");

            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var expected = "26";

            Assert.That(expected, Is.EqualTo(result.Text));
        }

        [Test]
        public void Test_SumTwoNegativeNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("-9");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("-2");

            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var expected = "-11";

            Assert.That(expected, Is.EqualTo(result.Text));
        }

        [Test]
        public void Test_SumPossitiveNegativeNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("-10");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("16");
 
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var expected = "6";

            Assert.That(expected, Is.EqualTo(result.Text));
        }

        [Test]
        public void Test_SumRealNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("10.9643");

            //Find second field, click and fill value
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("16.766545");

            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var expected = "27.730845";

            Assert.That(expected, Is.EqualTo(result.Text));
        }

        [Test]
        public void Test_SumUnValidNumbers()
        {
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            num1.Click();
            num1.SendKeys("asdf");

            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            num2.SendKeys("mnbv");

            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");
            calcButton.Click();

            var result = driver.FindElementByAccessibilityId("textBoxSum");
            var expected = "error";

            Assert.That(expected, Is.EqualTo(result.Text));
        }
    }
}