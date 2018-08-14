namespace DemoQA.TestNUnit.Pages.SortablePage
{
    using OpenQA.Selenium;

    public partial class SortablePage : BasePage
    {
        private IWebDriver _driver;

        public SortablePage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "sortable/";
        }

        public void ChangeSizeOfLists()
        {
            var elementToDrag = FirstList[2];
            var target = SecondList[1];
            Builder.DragAndDrop(elementToDrag, target).Perform();
        }
    }
}
