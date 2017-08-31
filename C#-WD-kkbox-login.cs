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
    public class Login
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://play.kkbox.com/";
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
        public void TheLoginTest()
        {
            driver.Navigate().GoToUrl("https://play.kkbox.com/");
            driver.FindElement(By.Id("uid")).Clear();
            driver.FindElement(By.Id("uid")).SendKeys("0933751972");
            driver.FindElement(By.Id("pwd")).Clear();
            driver.FindElement(By.Id("pwd")).SendKeys("peter528");
            driver.FindElement(By.Id("login-btn")).Click();
            driver.FindElement(By.LinkText("我的音樂庫")).Click();
            // ERROR: Caught exception [Error: unknown strategy [class] for locator [class=section-title ng-binding]]
            // 我的音樂庫 Found success
            driver.FindElement(By.LinkText("線上精選")).Click();
            // ERROR: Caught exception [Error: unknown strategy [class] for locator [class=section-title ng-binding]]
            // 線上精選Found success
            driver.FindElement(By.LinkText("電台")).Click();
            // ERROR: Caught exception [Error: unknown strategy [class] for locator [class=section-title ng-binding]]
            // 電台Found success
            driver.FindElement(By.LinkText("一起聽")).Click();
            Assert.AreEqual("選擇台長類型", driver.FindElement(By.XPath("//div[@id='container']/div[2]/div/div/div/div/div/div[2]/h2")).Text);
            // 一起聽 Found success
            // Finshded Test case - login and find the main page
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
