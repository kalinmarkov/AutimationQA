namespace DemoQA.TestNUnit.Pages.ResizablePage
{
    using OpenQA.Selenium;
    using System.Threading;

    public partial class ResizablePage : BasePage
    {
        private IWebDriver _driver;

        public ResizablePage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "resizable/";
        }

        public void DragElementByOffset(IWebElement element, int x, int y)
        {
            Builder.DragAndDropToOffset(element, x, y).Perform();
            Thread.Sleep(1500);
        }
    }
}
