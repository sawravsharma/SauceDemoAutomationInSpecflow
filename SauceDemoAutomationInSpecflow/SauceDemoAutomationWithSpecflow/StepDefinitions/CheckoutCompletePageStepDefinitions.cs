namespace SauceDemoAutomationWithSpecflow.StepDefinitions
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using static EnumsPackage.EnumClass;

    [Binding]
    public class CheckoutCompletePageStepDefinitions
    {
        IWebDriver webDriver;
        private string commonXpath = "(//button[contains(text(),'Add to cart')])";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private string url = "https://www.saucedemo.com/";
        private string userName = "standard_user";
        private string passWord = "secret_sauce";
        private string firstName = "Saurav";
        private string lastName = "Sharma";
        private string postCode = "1234";
        private string expectedUrlCompletePageUrl = "https://www.saucedemo.com/checkout-complete.html";

        [Given(@"User is on  a transaction complete page")]
        public void GivenUserIsOnATransactionCompletePage()
        {
            webDriver = new FirefoxDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(url);
            IWebElement webElement = webDriver.FindElement(By.XPath("//input[@id='user-name']"));
            webElement.SendKeys(userName);
            IWebElement webElement11 = webDriver.FindElement(By.XPath("//input[@id='password']"));
            webElement11.SendKeys(passWord);
            IWebElement webElement22 = webDriver.FindElement(By.XPath("//input[@id='login-button']"));
            webElement22.Click();

            try
            {
                for (int i = 1; i <= commonXpath.Count(); i++)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
                    // string title = (string)js.ExecuteScript("return document.title");
                    js.ExecuteScript("arguments[0].click();", webDriver.FindElement(By.XPath(commonXpath + "[" + i + "]")));
                    //  webElement.Click();
                }
            }
            catch
            {
                Console.WriteLine("Product not available");
            }
            Thread.Sleep(10000);
            IWebElement webElement1 = webDriver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));
            webElement1.Click();
            IWebElement webElement2 = webDriver.FindElement(By.XPath("//*[@id='checkout']"));
            webElement2.Click();
            IWebElement webElement3 = webDriver.FindElement(By.XPath("//*[@id='first-name']"));
            webElement3.SendKeys(firstName);
            Thread.Sleep(5000);
            IWebElement webElement4 = webDriver.FindElement(By.XPath("//*[@id='last-name']"));
            webElement4.SendKeys(lastName);

            IWebElement webElement5 = webDriver.FindElement(By.XPath("//*[@id='postal-code']"));
            webElement5.SendKeys(postCode);
            Thread.Sleep(5000);

            IWebElement webElement6 = webDriver.FindElement(By.XPath("//*[@id='continue']"));
            webElement6.Click();
            IWebElement webElement7 = webDriver.FindElement(By.XPath("//*[@id='finish']"));
            webElement7.Click();

        }

        [When(@"User is on Checkout complete page")]
        public void WhenUserIsOnCheckoutCompletePage()
        {
            webDriver.Url.Should().Be(expectedUrlCompletePageUrl);
            Console.WriteLine("Transaction successfull");
        }

        [Then(@"User click on back home button")]
        public void ThenUserClickOnBackHomeButton()
        {
            IWebElement webElement = webDriver.FindElement(By.XPath("//button[text()='Back Home']"));
            webElement.Click();
        }
    }

}

