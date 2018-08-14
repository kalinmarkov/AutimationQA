namespace DemoQA.TestNUnit.Pages.DroppablePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DroppablePage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-header"));

        public IWebElement DefaultFunctionalityButton => _driver.FindElement(By.Id("ui-id-1"));

        public IWebElement DropHereField => _driver.FindElement(By.CssSelector(@"div #droppableview"));

        public IWebElement AcceptButton => _driver.FindElement(By.Id("ui-id-2"));

        public IWebElement PreventPropagationButton => _driver.FindElement(By.Id("ui-id-3"));

        public IWebElement RevertDraggablePostionButton => _driver.FindElement(By.Id("ui-id-4"));

        public IWebElement DropMeHereField => _driver.FindElement(By.CssSelector("div #droppablerevert"));

        public IWebElement ShoppingCartDemoButton => _driver.FindElement(By.Id("ui-id-5"));

        public IWebElement FirstDroppableElement => _driver.FindElement(By.Id("draggablerevert"));

        public IWebElement TShirtCategorie => _driver.FindElement(By.Id("ui-id-6"));

        public IWebElement CheezeburgerShirt => _driver.FindElement(By.CssSelector("#ui-id-7 li:nth-child(2)"));

        public IWebElement BagsCategorie => _driver.FindElement(By.Id("ui-id-8"));

        public IWebElement ZebraStriped => _driver.FindElement(By.CssSelector("#ui-id-9 li:nth-child(1)"));

        public IWebElement GadgetsCategorie => _driver.FindElement(By.Id("ui-id-10"));

        public IWebElement IPad => _driver.FindElement(By.CssSelector("#ui-id-11 li:nth-child(3)"));

        public IWebElement ShoppingCartField => _driver.FindElement(By.CssSelector("#cart .ui-widget-content"));

        public List<IWebElement> ShoppingCartProductList => _driver.FindElements(By.CssSelector("#cart li")).ToList();

    }
}
