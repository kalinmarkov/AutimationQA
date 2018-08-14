namespace DemoQA.TestNUnit.Pages.DraggablePage
{
    using OpenQA.Selenium;
    using System.Threading;

    public partial class DraggablePage : BasePage
    {
        private IWebDriver _driver;

        public DraggablePage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "draggable/";
        }

        public void DragElementByOffset(IWebElement element, int x, int y)
        {
            Builder.DragAndDropToOffset(element, x, y).Perform();
            Thread.Sleep(1500);
        }
        
    }
}
