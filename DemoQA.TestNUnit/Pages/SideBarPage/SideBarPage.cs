namespace DemoQA.TestNUnit.Pages.SideBarPage
{
    using OpenQA.Selenium;

    public partial class SideBarPage : BasePage
    {
        private IWebDriver _driver;

        public SideBarPage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url;
        }
    }
}
