using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace SeleniumTests
{
[TestFixture]
public class dislike
{
private ISelenium selenium;
private StringBuilder verificationErrors;

[SetUp]
public void SetupTest()
{
selenium = new DefaultSelenium("localhost", 4444, "*chrome", "https://play.kkbox.com/");
selenium.Start();
verificationErrors = new StringBuilder();
}

[TearDown]
public void TeardownTest()
{
try
{
selenium.Stop();
}
catch (Exception)
{
// Ignore errors if unable to close the browser
}
Assert.AreEqual("", verificationErrors.ToString());
}

[Test]
public void TheDislikeTest()
{
			selenium.Open("https://play.kkbox.com/");
			selenium.Type("name=nickName", "0933751972");
			selenium.Type("name=password", "peter528");
			selenium.Click("id=login-btn");
			selenium.Click("link=電台");
			selenium.Click("css=a.btn-radio");
			selenium.Click("//div[@id='player']/div[6]/a/i");
}
}
}
