using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoAutomationWithSpecflow.StepDefinitions
{
    [Binding]
    public class OverviewPageStepDefinitions
    {
        private string commonXpath = "(//button[contains(text(),'Add to cart')])";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private string url = "https://www.saucedemo.com/";
        private string userName = "standard_user";
        private string passWord = "secret_sauce";
        private string expectedUrlOverviewPage = "https://www.saucedemo.com/checkout-step-two.html";
        private string firstName = "Saurav";
        private string lastName = "Sharma";
        private string postCode = "1234";
        IWebDriver webDriver;

        [Given(@"User has done checkout")]
        public void GivenUserHasDoneCheckout()
        {
            webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
            IWebElement webElement = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            webElement.SendKeys(userName);
            IWebElement webElement1 = webDriver.FindElement(By.XPath("//input[@id='password']"));
            webElement1.SendKeys(passWord);
            IWebElement webElement2 = webDriver.FindElement(By.XPath("//input[@id='login-button']"));
            webElement2.Click();

            try
            {
                for (int i = 1; i <= commonXpath.Count(); i++)
                {
                    IWebElement webElement3 = webDriver.FindElement(By.XPath(commonXpath + "[" + i + "]"));
                    IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                    // string title = (string)js.ExecuteScript("return document.title");
                    js.ExecuteScript("arguments[0].click();", webElement3);
                    //  webElement.Click();
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                Console.WriteLine("Product not available");
            }
            IWebElement webElement4 = webDriver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));
            webElement4.Click();

            IWebElement webElement5 = webDriver.FindElement(By.XPath("//*[@id='checkout']"));
            webElement5.Click();

            IWebElement webElement6 = webDriver.FindElement(By.XPath("//*[@id='first-name']"));
            webElement6.SendKeys(firstName);
            Thread.Sleep(5000);
            IWebElement webElement7 = webDriver.FindElement(By.XPath("//*[@id='last-name']"));
            webElement7.SendKeys(lastName);

            IWebElement webElement8 = webDriver.FindElement(By.XPath("//*[@id='postal-code']"));
            webElement8.SendKeys(postCode);
            Thread.Sleep(5000);
 
            IWebElement webElement9 = webDriver.FindElement(By.XPath("//*[@id='continue']"));
            webElement9.Click();
        }

        [Given(@"User is on the checkout overview page")]
        public void GivenUserIsOnTheCheckoutOverviewPage()
        {
            webDriver.Url.Should().Be(expectedUrlOverviewPage);
        }

        [When(@"User clicks on the finish button")]
        public void WhenUserClicksOnTheFinishButton()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//*[@id='finish']"));
            webElement.Click();
        }

        [Then(@"User gets redirects to ""([^""]*)""")]
        public void ThenUserGetsRedirectsTo(string expectedUrl)
        {
            webDriver.Url.Should().Be(expectedUrl);
        }

    }
}
