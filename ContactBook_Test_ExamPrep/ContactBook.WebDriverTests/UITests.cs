using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ContactBook.WebDriverTests
{
    public class UITests
    {
        private const string url = "http://localhost:8080";
        private WebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
        }

        [TearDown]

        public void CloseBrowser()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_ListContacts_CheckFirstContact()
        {
            //Arrange

            //driver.Navigate().GoToUrl(url);
            var contactsLink = driver.FindElement(By.LinkText("Contacts"));

            //Act
            contactsLink.Click();

            //Assert
            var firstName = driver.FindElement(By.CssSelector("#contact1 > tbody > tr.fname > td")).Text;
            var lastName = driver.FindElement(By.CssSelector("#contact1 > tbody > tr.lname > td")).Text;

            Assert.That(firstName, Is.EqualTo("Steve"));
            Assert.That(lastName, Is.EqualTo("Jobs"));
        }


        [Test]
        public void Test_SearchContacts_CheckFirstContact()
        {
            //Arrange

            //driver.Navigate().GoToUrl(url);
            var searchLink = driver.FindElement(By.LinkText("Search"));

            //Act
            searchLink.Click();
            var searchfield = driver.FindElement(By.Id("keyword"));
            searchfield.Click();
            searchfield.SendKeys("albert");

            var searchButton = driver.FindElement(By.Id("search"));
            searchButton.Click();

            //Assert
            var searchResult = driver.FindElement(By.Id("searchResult")).Text;

            var expected = "1 contacts found.";
            Assert.That(searchResult, Is.EqualTo(expected));

            var firstName = driver.FindElement(By.CssSelector("tr.fname > td")).Text;
            // <- both ways ->
            var lastName = driver.FindElement(By.CssSelector("#contact3 > tbody > tr.lname > td")).Text;

            Assert.That(firstName, Is.EqualTo("Albert"));
            Assert.That(lastName, Is.EqualTo("Einstein"));
        }

        [Test]
        public void Test_SearchContacts_InvalidData()
        {
            //Arrange

           // driver.Navigate().GoToUrl(url);
            var searchLink = driver.FindElement(By.LinkText("Search"));

            //Act
            searchLink.Click();
            var searchfield = driver.FindElement(By.Id("keyword"));
            searchfield.Click();
            searchfield.SendKeys("invalid2635");

            var searchButton = driver.FindElement(By.Id("search"));
            searchButton.Click();

            //Assert
            var searchResult = driver.FindElement(By.Id("searchResult")).Text;

            var expected = "No contacts found.";
            Assert.That(searchResult, Is.EqualTo(expected));

        }
        [Test]
        public void Test_SearchContact_InvalidData_WithSelenium()
        {
            //driver.Navigate().GoToUrl("http://localhost:8080/");
            //driver.Navigate().GoToUrl(url);

            driver.FindElement(By.LinkText("Search")).Click();
            driver.FindElement(By.Id("keyword")).Click();
            driver.FindElement(By.Id("keyword")).SendKeys("invalid2635");
            driver.FindElement(By.Id("search")).Click();
            driver.FindElement(By.Id("searchResult")).Click();
            Assert.That(driver.FindElement(By.Id("searchResult")).Text, Is.EqualTo("No contacts found."));
           
        }

        [Test]
        public void Test_CreateContact_InvalidData()
        {     
            //driver.Navigate().GoToUrl(url);

            var createButton = driver.FindElement(By.LinkText("Create"));
            createButton.Click();

            var firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Alabala");

            var buttonCreate = driver.FindElement(By.Id("create"));
            buttonCreate.Click();

            var error = driver.FindElement(By.CssSelector("body > main > div")).Text;

            Assert.That(error, Is.EqualTo("Error: Last name cannot be empty!"));
        }

        [Test]
        public void Test_CreateContact_ValidData()
        {
            //driver.Navigate().GoToUrl(url);

            var createButton = driver.FindElement(By.LinkText("Create"));
            createButton.Click();

            var firstName = "FirstName" + DateTime.Now.Ticks;
            var lastName = "LastName" + DateTime.Now.Ticks;
            var email = DateTime.Now.Ticks + "gulia@abv.bg";
            var phone = "12345";

            // Act
            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("phone")).SendKeys(phone);

            var buttonCreate = driver.FindElement(By.Id("create"));
            buttonCreate.Click();

            var pageTitle = driver.FindElement(By.CssSelector("body > header > h1")).Text;

            Assert.That(pageTitle, Is.EqualTo("View Contacts"));

            var allContacts = driver.FindElements(By.CssSelector("table.contact-entry"));
            var lastContact = allContacts.Last();

            var firstNameLabel = lastContact.FindElement(By.CssSelector("tr.fname > td")).Text;
            var lastNameLabel = lastContact.FindElement(By.CssSelector("tr.lname > td")).Text;

            Assert.That(firstNameLabel, Is.EqualTo(firstName));
            Assert.That(lastNameLabel, Is.EqualTo(lastName));
        }
    }

}