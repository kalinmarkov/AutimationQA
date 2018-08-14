namespace DemoQA.TestNUnit.Pages.DraggablePage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DraggablePage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement DraggablePlusSortableButton => _driver.FindElement(By.LinkText("Draggable + Sortable"));

        public IWebElement EventsButton => _driver.FindElement(By.LinkText("Events"));

        public IWebElement FirstDragItem => _driver.FindElement(By.CssSelector("#sortablebox li:nth-child(1)"));

        public IWebElement LastDragItem => _driver.FindElement(By.CssSelector("#sortablebox li:nth-child(5)"));

        public List<IWebElement> DragItemsList => _driver.FindElements(By.CssSelector("#sortablebox li")).ToList();

        public IWebElement DragBox => _driver.FindElement(By.Id("dragevent"));

        public IWebElement StartInvokedCount => _driver.FindElement(By.CssSelector("#event-start .count"));
    }
}
