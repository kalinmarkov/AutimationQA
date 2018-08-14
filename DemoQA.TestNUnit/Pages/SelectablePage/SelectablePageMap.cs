
namespace DemoQA.TestNUnit.Pages.SelectablePage
{
    using OpenQA.Selenium;

    public partial class SelectablePage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement DisplayAsGridButton => _driver.FindElement(By.LinkText("Display as grid"));

        public IWebElement FirstElement => _driver.FindElement(By.CssSelector("#selectable_grid li:nth-child(1)"));
    }
}
