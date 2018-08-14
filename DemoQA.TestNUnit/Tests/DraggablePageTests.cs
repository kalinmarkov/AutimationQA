namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.DraggablePage;
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    class DraggablePageTests
    {
        private IWebDriver _driver;
        private DraggablePage _draggablePage;
        private SideBarPage _sideBarPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _draggablePage = new DraggablePage(_driver);
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
        public void OpenDraggablePage()
        {
            _sideBarPage.NavigateTo();
            _sideBarPage.DraggableButton.Click();

            _draggablePage.TextAsserter("Draggable", _draggablePage.HeaderMessage);
        }

        [Test]
        public void DraggablePlusSortableChangeFirstAndLastItems()
        {
            _draggablePage.NavigateTo();
            _draggablePage.DraggablePlusSortableButton.Click();

            string firtsDragItemName = _draggablePage.FirstDragItem.Text;
            _draggablePage.DragElementByOffset(_draggablePage.FirstDragItem, 0, 70);
            string lastDragItemName = _draggablePage.LastDragItem.Text;
            _draggablePage.DragElementByOffset(_draggablePage.LastDragItem, 0, -100);

            _draggablePage.TextAsserter(firtsDragItemName, _draggablePage.DragItemsList[4]);
            _draggablePage.TextAsserter(lastDragItemName, _draggablePage.DragItemsList[0]);
        }


        [Test]
        public void EventFunctionalityCountInvokes()
        {
            _draggablePage.NavigateTo();
            _draggablePage.EventsButton.Click();

            var startCount = _draggablePage.StartInvokedCount.Text;
            _draggablePage.DragElementByOffset(_draggablePage.DragBox, 30, 70);
            _draggablePage.DragElementByOffset(_draggablePage.DragBox, 60, -30);
            var totalCount = _draggablePage.StartInvokedCount.Text;
            
            Assert.AreEqual("0", startCount);
            Assert.AreEqual("2", totalCount);
        }
    }
}
