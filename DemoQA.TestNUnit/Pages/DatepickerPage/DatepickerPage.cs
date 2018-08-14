namespace DemoQA.TestNUnit.Pages.DatepickerPage
{
    using OpenQA.Selenium;

    public partial class DatepickerPage : BasePage
    {
        private IWebDriver _driver;

        public DatepickerPage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "datepicker/";
        }
    }
}
