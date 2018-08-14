namespace DemoQA.TestNUnit.Pages.Tooltip
{
    using OpenQA.Selenium;

    public partial class TooltipPage : BasePage
    {
        private IWebDriver _driver;

        public TooltipPage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "tooltip/";
        }

        public string GetTooltipText()
        {
            Builder.MoveToElement(AgeField).Perform();
            string tooltipText = TooltipElement.Text;
            return tooltipText;
        }
    }
}
