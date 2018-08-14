namespace DemoQA.TestNUnit.Pages.DroppablePage
{
    using OpenQA.Selenium;
    using System.Threading;

    public partial class DroppablePage : BasePage
    {
        private IWebDriver _driver;

        public DroppablePage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "droppable/";
        }

        public string GetTextAndMoveElementToBasket(IWebElement element, IWebElement target)
        {
            string elementName = element.Text;
            Builder.DragAndDrop(element, target).Perform();
            Thread.Sleep(500);
            return elementName;
        }

        public void DragAndDropElement(IWebElement element, IWebElement target)
        {
            Builder.DragAndDrop(element, target).Perform();
            Thread.Sleep(1000);
        }
    }
}
