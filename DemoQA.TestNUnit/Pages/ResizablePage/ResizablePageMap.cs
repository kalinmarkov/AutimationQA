namespace DemoQA.TestNUnit.Pages.ResizablePage
{
    using OpenQA.Selenium;

    public partial class ResizablePage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement AnimateButton => _driver.FindElement(By.LinkText("Animate"));

        public IWebElement ResizablePoint => _driver.FindElement(By.CssSelector("#resizableani .ui-icon-gripsmall-diagonal-se"));

    }
}
