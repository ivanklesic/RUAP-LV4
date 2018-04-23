using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class RuapLv4Z1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://demo.opencart.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRuapLv4Z1Test()
        {
            string name = "", lname = "", email = "", pass = "", tel = "";
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                name = "John" + rand.Next(0, 1000).ToString();
                lname = "Doe" + rand.Next(0, 1000).ToString();
                email = name + lname + "@gmail.com";
                tel = rand.Next(0, 1000).ToString();
                
                driver.Navigate().GoToUrl("https://demo.opencart.com/");
                driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
                driver.FindElement(By.LinkText("Register")).Click();
                driver.FindElement(By.Id("input-firstname")).Click();
                driver.FindElement(By.Id("input-firstname")).SendKeys(name);
                driver.FindElement(By.Id("input-lastname")).SendKeys(lname);
                driver.FindElement(By.Id("input-email")).SendKeys(email);
                driver.FindElement(By.Id("input-telephone")).SendKeys(tel);
                driver.FindElement(By.Id("input-password")).SendKeys("qwertz");
                driver.FindElement(By.Id("input-confirm")).SendKeys("qwertz");
                driver.FindElement(By.Name("newsletter")).Click();
                driver.FindElement(By.Name("agree")).Click();
                driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
                driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/span")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
