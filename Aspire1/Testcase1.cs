using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Xunit;

namespace NgaDo.Aspire1
{

    class Testcase1
    {

        public IWebDriver _chromeDriver { get; private set; }

        public IDictionary<String, Object> vars { get; private set; }
        public static DateTime Now { get; }


        public Testcase1(IWebDriver chromeDriver)
        {
            _chromeDriver = chromeDriver;
        }

        public void Start()
        {
            ExecuteTest(_chromeDriver);
        }

        /// <summary>
        /// TESTCASE 

        public void ExecuteTest(IWebDriver driver)
        {
            DateTime dateTime = DateTime.Now;
            //Created data
            string productName = "ND_AT_Test_" + dateTime.ToString("yyyyMMddhhmmss");
            double quantity = 11.15;
            string location = "WH/Stock";

            //Step 1: Login to web application
            string url = Global.SiteURL;
            string userName = Global.SiteUserName;
            string passWord = Global.SitePassword;

            Global.Init.Test(driver);
            AspireFunctions.LoginSite(driver, url, userName, passWord);

            //Step 2: Navigate Inventory" feature
            AspireFunctions.AccessToMenuFromHomePage(driver,"Inventory");

            //Step 3: Select Products>Products and create new Product
            AspireFunctions.SelectChildMenu(driver, "Products", "Products");
            AspireFunctions.CreateNewProduct(driver, productName);

            // step 4: Update Quantiry
            AspireFunctions.UpdateQuantity(driver, location, quantity);

            // step 5: Click on Application
            AspireFunctions.GoToHomePage(driver);

            //Step 6: Navigate "Manufacturing" feature and create new manufacturing
            AspireFunctions.AccessToMenuFromHomePage(driver, "Manufacturing");
            AspireFunctions.CreateNewManufacturing(driver, productName, quantity);

            //Step 7: Update manufacturing oder to Done
            AspireFunctions.MarkMenufacturingDone(driver);

            //Step 8: validate Data: Update manufacturing oder to Done
            
            Assert.Equal(productName, AspireFunctions.GetProductNameInManufacturing(driver));
            Assert.Equal(productName, AspireFunctions.GetProductNameInManufacturingComponent(driver));
            Assert.Equal(quantity.ToString(), AspireFunctions.GetQuantityInManufacturingComponent(driver));

        }
    } 
    
    
}
