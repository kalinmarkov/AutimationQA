namespace DemoQA.TestNUnit.Pages
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

        public string Url => "http://demoqa.com/";   
        
        //public void NavigateTo()
        //{
        //    this.Driver.Url = this.Url;
        //}

        public WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

        public Actions Builder => new Actions(Driver);
    }
}
