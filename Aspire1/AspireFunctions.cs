using OpenQA.Selenium;
using System;

namespace NgaDo.Aspire1
{
    public static class AspireFunctions
    {
        //XPATH
        //Login
        static By txtbxEmail = By.XPath("//input[@id='login']");
        static By txtbxPassword = By.XPath("//input[@id='password']");
        static By btnLogin = By.XPath("//button[.='Log in']");
        // Homepage
       
        static By btnApplications = By.XPath("//a[@title='Applications']");

        
        //Inventory Page
        static By btnInventoryInTop = By.XPath("//a[.='Inventory']");
        static By btnCreateProduct = By.XPath("//button[contains(.,'Create')]");
        static By txtbxProductName = By.XPath("//input[@placeholder='Product Name']");
        static By btnSaveProduct = By.XPath("//button[contains(.,'Save')]");
        static By txtUpdateQantity = By.XPath("//button/span[.='Update Quantity']");
        static By txtbxLocationID = By.XPath("//div[@name='location_id']//input[@class='o_input ui-autocomplete-input']");
        static By txtbxInventoryQuantity = By.XPath("//input[@name='inventory_quantity']");
        static By btnLocationIDExternalLink = By.XPath("//div[@name='location_id']/button[@title='External link']");
        //Manufacturing page
        static By txtbxProductNameManufacturing = By.XPath("//div[@name='product_id']//input");
        static By btnProductIDExternalLink = By.XPath("//div[@name='product_id']/button[@title='External link']");
        static By btnNext= By.XPath("//button[@title='Next']");
        static By btnPrevious = By.XPath("//button[@title='Previous']");
        static By btnMarkAsDone = By.XPath("//button/span[.='Mark as Done']");
        static By btnOk = By.XPath("//button/span[.='Ok']");
        static By btnConfirm = By.XPath("//button/span[.='Confirm']");
        static By btnApply = By.XPath("//button/span[.='Apply']");
        static By txtbxQuantityManufacturing = By.XPath("//input[@name='qty_producing']");
        static By txtbxLotSerialNumber = By.XPath("//input[@id='o_field_input_2227']");
        static By btnSerialNumberExternalLink = By.XPath("//div[@name='lot_producing_id']/button[@title='External link']");
        static By btnAddALineHyperlink = By.XPath("//div[@name='move_raw_ids']//a[.='Add a line']");
        static By txtbxProductNameComponentManufacturing = By.XPath("//div[@class='table-responsive']//div[@name='product_id']//input");
        static By btnProductIDComponentExternalLink = By.XPath("//tr[@data-id='stock.move_54']//div[@name='product_id']/button[@title='External link']");
        static By txtbxQuantityManufacturingComponent = By.XPath("//input[@name='product_uom_qty']");
        static By lblLoading = By.XPath("//div[@class='o_loading'][.='Loading']");
       static By lblProducNameManufacturing = By.XPath("//a[@name='product_id']/span");
        static By lblProducNameManufacturingComponent = By.XPath("//tr[@class='o_data_row']/td[1]");
        static By lblQuantityManufacturingComponent = By.XPath("//tr[@class='o_data_row']/td[2]/span/span");

        public static By btn_navigationHOme(string nameOfMenu)
        {
            return By.XPath("//div[.='"+ nameOfMenu + "']");
        }
        public static By td_selectMenu(string nameOfMenu)
        {
            return By.XPath("//a[@role='button'][contains(.,'"+ nameOfMenu + "')]");
        }
        public static By td_selectSubMenu(string nameOfSubMenu)
        {
            return By.XPath("//a[@role='menuitem']/span[.='"+ nameOfSubMenu + "']");
        }
        public static By td_selectLocationID(string locationID)
        {
            return By.XPath("//a[@class='ui-menu-item-wrapper'][.='"+ locationID + "']");
        }
        public static By td_selectProductName(string productname)
        {
            return By.XPath("//li[@class='ui-menu-item']/a[.='"+ productname + "']");
        }
        public static By td_selectProductNameComponent(string productname)
        {
            return By.XPath("(//li[@class='ui-menu-item']/a[.='"+ productname + "'])[last()]");
        }


        
        public static void LoginSite(IWebDriver driver, string url, string Username, string Password)
        {
            Console.Write("\n--Login to application--");
            driver.Navigate().GoToUrl(url);
            SeleniumMethods.ClearText(driver, txtbxEmail);
            SeleniumMethods.InputText(driver, txtbxEmail, Username);
            SeleniumMethods.ClearText(driver, txtbxPassword);
            SeleniumMethods.InputText(driver, txtbxPassword, Password);
            SeleniumMethods.ClickElement(driver, btnLogin);
            SeleniumMethods.WaitPageLoadComplete(driver);
        }

        public static void AccessToMenuFromHomePage(IWebDriver driver, string menu)
        {
            Console.Write("\n--Navigate to " + menu);
            SeleniumMethods.ClickElement(driver, btn_navigationHOme(menu));
            // SeleniumMethods.WaitElementDisplayed(driver, btnApplications);
            SeleniumMethods.WaitForLoading(driver, lblLoading);
        }

        public static void GoToHomePage(IWebDriver driver)
        {
            Console.Write("\n--Navigate to Iventory--");
            SeleniumMethods.ClickElement(driver, btnApplications);
        }

        public static void SelectChildMenu(IWebDriver driver, string MainMenu, string ChildMenu)
        {
            Console.Write("\n--Select " + MainMenu + ">"+ ChildMenu+"--");
            SeleniumMethods.ClickElement(driver, td_selectMenu(MainMenu));
            SeleniumMethods.ClickElement(driver, td_selectSubMenu(ChildMenu));
            SeleniumMethods.WaitForLoading(driver, lblLoading);

        }

        public static void CreateNewProduct(IWebDriver driver, string ProductName)
        {
            Console.Write("\n--Create Product " + ProductName+"--");
            SeleniumMethods.ClickElement(driver, btnCreateProduct);
            SeleniumMethods.InputText(driver, txtbxProductName, ProductName);

        }


        
        public static void UpdateQuantity(IWebDriver driver, string Location, double Quantity)
        {
            Console.Write("\n\tUpdate quatity at location " + Location + " with value " + Quantity.ToString());
            SeleniumMethods.ClickElement(driver,txtUpdateQantity);
            SeleniumMethods.WaitForLoading(driver, lblLoading);
            SeleniumMethods.ClickElement(driver, btnCreateProduct);
            SeleniumMethods.WaitForLoading(driver, lblLoading);
            SeleniumMethods.SelectValueFromDropdown(driver, Location,txtbxLocationID, td_selectLocationID(Location));
            SeleniumMethods.ClickElement(driver, txtbxInventoryQuantity);
            SeleniumMethods.ClearText(driver, txtbxInventoryQuantity);
            SeleniumMethods.InputText(driver, txtbxInventoryQuantity, Quantity.ToString());
            //SeleniumMethods.RefieldText(driver, txtbxInventoryQuantity, Quantity.ToString());
            
            SeleniumMethods.ClickElement(driver, btnSaveProduct);
            SeleniumMethods.WaitForLoading(driver, lblLoading);

        }

        public static void CreateNewManufacturing(IWebDriver driver, string ProductName, double Quantity)
        {
            Console.Write("\n--Create Manufacturing " + ProductName + "--");
            SeleniumMethods.ClickElement(driver, btnCreateProduct);
            SeleniumMethods.SelectValueFromDropdown(driver, ProductName, txtbxProductNameManufacturing, td_selectProductName(ProductName));
            SeleniumMethods.ClickElement(driver, btnAddALineHyperlink);
            SeleniumMethods.SelectValueFromDropdown(driver, ProductName, txtbxProductNameComponentManufacturing, td_selectProductNameComponent(ProductName));
            SeleniumMethods.ClickElement(driver, txtbxQuantityManufacturingComponent);
            SeleniumMethods.ClearText(driver, txtbxQuantityManufacturingComponent);
            SeleniumMethods.InputText(driver, txtbxQuantityManufacturingComponent, Quantity.ToString());
            SeleniumMethods.ClickElement(driver, btnConfirm);
            SeleniumMethods.WaitForLoading(driver, lblLoading);

        }

        public static void MarkMenufacturingDone(IWebDriver driver)
        {
            Console.Write("\n--Mark Menufacturing Done" );
            SeleniumMethods.ClickElement(driver, btnMarkAsDone);
            SeleniumMethods.WaitForLoading(driver, lblLoading);
            SeleniumMethods.ClickElement(driver, btnApply);
            SeleniumMethods.WaitForLoading(driver, lblLoading);
        }
        public static string GetProductNameInManufacturing(IWebDriver driver)
        {
             return SeleniumMethods.GetElementText(driver, lblProducNameManufacturing);
        }
        public static string GetProductNameInManufacturingComponent(IWebDriver driver)
        {
            return SeleniumMethods.GetElementText(driver, lblProducNameManufacturingComponent);
        }

        public static string GetQuantityInManufacturingComponent(IWebDriver driver)
        {
            return SeleniumMethods.GetElementText(driver, lblQuantityManufacturingComponent).ToString();
        }

    }
}
