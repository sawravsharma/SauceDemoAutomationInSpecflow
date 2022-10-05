using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoAutomationWithSpecflow.StepDefinitions
{
    [Binding]
    public class LoggingInStepDefinitions
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        IWebDriver webDriver;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Given(@"User searches for ""([^""]*)""")]
        public void GivenUserSearches(string url)
        {
            webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
        }

        [When(@"I have entered (.*) and (.*)")]
        public void GivenIHaveEnteredSecret_SauceIntoThe(string UserName,string Password)
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            webElement.SendKeys(UserName);
            IWebElement webElement1 = webDriver.FindElement(By.XPath("//input[@id='password']"));
            webElement1.SendKeys(Password);
        }

        [Then(@"I click Login button")]
        public void WhenIPress()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//input[@id='login-button']" ));
            webElement.Click();
        }

        //[Then(@"I  should be on ""([^""]*)""")]
        //public void ThenIShouldBeOnHttpsWww_Saucedemo_ComInventory_Html(string expectedUrl)
        //{
        //    webDriver.Url.Should().Be(expectedUrl);
        //}

    }
}
