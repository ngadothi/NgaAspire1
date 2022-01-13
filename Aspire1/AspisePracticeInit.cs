using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace NgaDo.Aspire1
{
    [TestFixture]
    public class AspirePracticeInit
    {
        #region Script Interfaces
        public IWebDriver chromeDriver { get; private set; }
        #endregion

        string driver_path = "C:\\Drivers";

        [SetUp]
        public void SetUp()
        {

            //Chrome Driver
            chromeDriver = new ChromeDriver(driver_path);

        }

        [Test]
        public void Testcase1()
        {
            Aspire1.Testcase1 testRun = new Aspire1.Testcase1(chromeDriver);
            testRun.Start();
        }


        [TearDown]
        public void Done()
        {
            if (chromeDriver != null)
            {
                
                    chromeDriver.Quit();
            }
        }
    }    
}
