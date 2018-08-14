
namespace DemoQA.TestNUnit.Pages.Tooltip
{
    using OpenQA.Selenium;

    public partial class TooltipPage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement AgeField => _driver.FindElement(By.Id("age"));

        public IWebElement TooltipElement => Wait.Until(d => d.FindElement(By.CssSelector(".ui-tooltip")));

    }
}
