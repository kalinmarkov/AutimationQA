namespace DemoQA.TestNUnit.Pages.SideBarPage
{
    using OpenQA.Selenium;

    public partial class SideBarPage
    {
        public IWebElement RegistrationButton => _driver.FindElement(By.Id("menu-item-374"));

        public IWebElement DraggableButton => _driver.FindElement(By.Id("menu-item-140"));

        public IWebElement DroppableButton => _driver.FindElement(By.Id("menu-item-141"));

        public IWebElement ResizableButton => _driver.FindElement(By.Id("menu-item-143"));

        public IWebElement SelectableButton => _driver.FindElement(By.Id("menu-item-142"));

        public IWebElement SortableButton => _driver.FindElement(By.Id("menu-item-151"));

        public IWebElement TooltipButton => _driver.FindElement(By.Id("menu-item-99"));

        public IWebElement DatepickerButton => _driver.FindElement(By.Id("menu-item-146"));

    }
}
