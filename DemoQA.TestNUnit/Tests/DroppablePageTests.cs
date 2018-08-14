namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.DroppablePage;
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    class DroppablePageTests
    {
        private IWebDriver _driver;
        private DroppablePage _droppablePage;
        private SideBarPage _sideBarPage;

        [SetUp]
        public void SetUp()
        {            
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _droppablePage = new DroppablePage(_driver);
            _sideBarPage = new SideBarPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(Path.GetPathRoot(@"..\..\..\Screenshots\") + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            }

            _driver.Close();
            _driver.Quit();
        }

        [Test]
        public void OpenDroppablePage()
        {
            _sideBarPage.NavigateTo();
            _sideBarPage.DroppableButton.Click();

            Assert.IsTrue(_droppablePage.HeaderMessage.Displayed);
            _droppablePage.TextAsserter("Droppable", _droppablePage.HeaderMessage);
        }

        [Test]
        public void CheckDefaultFunctionalityPageIsDisplayed()
        {
            _droppablePage.NavigateTo();
            _droppablePage.DefaultFunctionalityButton.Click();

            Assert.IsTrue(_droppablePage.DropHereField.Displayed);
        }

        [Test]
        public void CheckRevertDraggablePossition()
        {
            _droppablePage.NavigateTo();
            _droppablePage.RevertDraggablePostionButton.Click();

            var startLocation = _droppablePage.FirstDroppableElement.Location;
            var dropFieldNameBefore = _droppablePage.DropMeHereField.Text;
            _droppablePage.DragAndDropElement(_droppablePage.FirstDroppableElement, _droppablePage.DropMeHereField);
            var dropFieldNameAfter = _droppablePage.DropMeHereField.Text;            
            var endLocation = _droppablePage.FirstDroppableElement.Location;

            Assert.AreNotEqual(dropFieldNameBefore, dropFieldNameAfter);
            Assert.AreEqual(startLocation, endLocation);
        }

        [Test]
        public void ShoppingCartFunctionality()
        {
            _droppablePage.NavigateTo();
            _droppablePage.ShoppingCartDemoButton.Click();

            _droppablePage.TShirtCategorie.Click();
            string cheezeburgerShirt = _droppablePage.GetTextAndMoveElementToBasket(_droppablePage.CheezeburgerShirt, _droppablePage.ShoppingCartField);
            _droppablePage.GadgetsCategorie.Click();
            var iPad = _droppablePage.GetTextAndMoveElementToBasket(_droppablePage.IPad, _droppablePage.ShoppingCartField); 
            _droppablePage.BagsCategorie.Click();
            var zebraStriped = _droppablePage.GetTextAndMoveElementToBasket(_droppablePage.ZebraStriped, _droppablePage.ShoppingCartField);

            _droppablePage.TextAsserter(cheezeburgerShirt, _droppablePage.ShoppingCartProductList[0]);
            _droppablePage.TextAsserter(iPad, _droppablePage.ShoppingCartProductList[1]);
            _droppablePage.TextAsserter(zebraStriped, _droppablePage.ShoppingCartProductList[2]);
        }
    }
}
