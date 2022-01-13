
using OpenQA.Selenium;


namespace NgaDo.Aspire1
{
    public class Global
    {

        public static string SiteURL = "https://aspireapp.odoo.com";

        public static string SiteUserName = "user@aspireapp.com";
        public static string SitePassword = "@sp1r3app";

        public static int DefaultWaitTimeInSeconds = 10;

        public class Init
        {
            public static IWebDriver Test(IWebDriver driver)
            {
                driver.Manage().Window.Maximize();
                return driver;
            }
        }

    }
}
