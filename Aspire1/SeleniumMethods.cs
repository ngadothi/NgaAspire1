using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;



namespace NgaDo.Aspire1
{
    class SeleniumMethods
    {
      

        public static void ClearText(IWebDriver driver, By locator)
        {
            WaitElementEnabled(driver, locator);
            driver.FindElement(locator).Clear();
        }

        public static void InputText(IWebDriver driver, By locator, string inputText)
        {
            WaitElementEnabled(driver, locator);
            driver.FindElement(locator).SendKeys(inputText);
        }

        public static void RefieldText(IWebDriver driver, By locator, string inputText)
        {
            WaitElementEnabled(driver, locator);
            driver.FindElement(locator).Click();
            System.Threading.Thread.Sleep(100);
            driver.FindElement(locator).Clear();
            System.Threading.Thread.Sleep(100);
            driver.FindElement(locator).SendKeys(inputText);
            System.Threading.Thread.Sleep(100);
        }



        public static void ClickElement(IWebDriver driver, By locator)
        {
            WaitElementEnabled(driver, locator);
            driver.FindElement(locator).Click();
        }
        public static void WaitPageLoadComplete(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Global.DefaultWaitTimeInSeconds));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public static void WaitElementDisplayed(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Global.DefaultWaitTimeInSeconds));
            wait.Until(driver1 => driver.FindElement(locator).Displayed);
        }

        public static void WaitElementEnabled(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Global.DefaultWaitTimeInSeconds));
            wait.Until(driver1 => driver.FindElement(locator).Enabled);
        }

       
        public static void MouseOver(IWebDriver driver, By locator)
        {
            WaitElementDisplayed(driver, locator);
            IWebElement element = driver.FindElement(locator);
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }
        public static void RightClick(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Global.DefaultWaitTimeInSeconds));
            wait.Until(driver1 => driver.FindElement(locator).Enabled);
            IWebElement Element = driver.FindElement(locator);
            Actions builder = new Actions(driver);
            builder.MoveToElement(Element).Perform();
            builder.ContextClick(Element).Perform();
        }

        public static void SelectValueFromDropdown(IWebDriver driver, string value, By locatorDrpdown, By locatorValue)
        {
            SeleniumMethods.WaitElementEnabled(driver, locatorDrpdown);
            SeleniumMethods.ClickElement(driver, locatorDrpdown);
            SeleniumMethods.InputText(driver, locatorDrpdown, value);
            SeleniumMethods.WaitElementDisplayed(driver, locatorValue);
            SeleniumMethods.ClickElement(driver, locatorValue);
        }
        public static void WaitForLoading(IWebDriver driver,By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Global.DefaultWaitTimeInSeconds));
            wait.Until(driver1 => driver.FindElement(locator).Displayed);
            wait.Until(driver1 => !driver.FindElement(locator).Displayed);
        }

        public static string GetElementText(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Global.DefaultWaitTimeInSeconds));
            wait.Until(driver1 => driver.FindElement(locator).Displayed);
            string value = driver.FindElement(locator).Text;
            return value;
        }
    }
}
