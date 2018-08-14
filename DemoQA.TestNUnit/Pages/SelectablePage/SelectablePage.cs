namespace DemoQA.TestNUnit.Pages.SelectablePage
{
    using OpenQA.Selenium;

    public partial class SelectablePage : BasePage
    {
        private IWebDriver _driver;

        public SelectablePage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "selectable/";
        }
    }
}
