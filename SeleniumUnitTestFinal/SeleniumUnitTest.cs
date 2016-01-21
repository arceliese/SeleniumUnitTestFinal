using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//Step a
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Linq;
using NUnit.Framework;

namespace NUnitSelenium
{
    [TestFixture]
    public class SeleniumTest
    {
        private IWebDriver driver;

        static void Main(string[] args)
        {

        }

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();

        }

        [Test]
        public void CheckDownloadsPage()
        {
            //Step c : Making driver to navigate
            driver.Navigate().GoToUrl("http://docs.seleniumhq.org/");

            //Step d 
            IWebElement myLink = driver.FindElement(By.LinkText("Download"));
            myLink.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = driver.FindElement(By.XPath("//*[@id='mainContent']/h2"));

            Assert.True(driver.Title.Equals("Downloads"));
        }

        [TearDown]
        public void CleanUp()
        {
            //Step e
            driver.Quit();
            Console.WriteLine("====================================");
            Console.WriteLine("|    T E S T   C O M M I T  16      |");
            Console.WriteLine("====================================");
        }

    }

    [TestFixture, Description("Tests Google Search with String data")]
    public class GoogleTests
    {
        private IWebDriver driver;

        public GoogleTests() { }

        [SetUp]
        public void LoadDriver() { driver = new ChromeDriver(); }

        [TestCase("planit")]   // searchString = Google
        [TestCase("auckland")]     // searchString = Bing
        public void Search(string searchString)
        {
            // execute Search twice with testdata: Google, Bing

            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Name("q")).SendKeys(searchString);
            driver.FindElement(By.Name("q")).Submit();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = driver.FindElement(By.Id("resultStats"));

            Assert.True(driver.Title.Contains(searchString));
        }

        [TearDown]
        public void UnloadDriver() { driver.Quit(); }
    }
}