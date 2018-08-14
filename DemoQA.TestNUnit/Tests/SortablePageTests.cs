namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using DemoQA.TestNUnit.Pages.SortablePage;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    class SortablePageTests
    {
        private IWebDriver _driver;
        private SortablePage _sortablePage;
        private SideBarPage _sideBarPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _sortablePage = new SortablePage(_driver);
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
        public void OpenSortablePage()
        {
            _sideBarPage.NavigateTo();
            _sideBarPage.SortableButton.Click();

            Assert.IsTrue(_sortablePage.HeaderMessage.Displayed);
            Assert.AreEqual("Sortable", _sortablePage.HeaderMessage.Text);
        }

        [Test]
        public void ConnectListsChangeSizeOfLists()
        {
            _sortablePage.NavigateTo();
            _sortablePage.ConnectListsButton.Click();

            _sortablePage.ChangeSizeOfLists();

            Assert.AreNotEqual(_sortablePage.FirstList.Count, _sortablePage.SecondList.Count);
        }
    }
}
