namespace DemoQA.TestNUnit.Pages.SortablePage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SortablePage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement ConnectListsButton => _driver.FindElement(By.LinkText("Connect Lists"));

        public List<IWebElement> FirstList => _driver.FindElements(By.CssSelector("#sortable1 li")).ToList();       

        public List<IWebElement> SecondList => _driver.FindElements(By.CssSelector("#sortable2 li")).ToList();
    }
}
