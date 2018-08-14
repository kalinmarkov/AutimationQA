namespace TestAutomation.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System;

    public class BasePage
    {
        public IWebDriver Driver { get; private set; }

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public string Url => "http://192.168.10.158/BeerShop/";

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

        public Actions Builder => new Actions(Driver);
    }
}
