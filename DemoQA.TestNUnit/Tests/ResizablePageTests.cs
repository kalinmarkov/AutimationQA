namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.ResizablePage;
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    class ResizablePageTests
    {
        private IWebDriver _driver;
        private ResizablePage _resizablePage;
        private SideBarPage _sideBarPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _resizablePage = new ResizablePage(_driver);
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
        public void OpenResizablePage()
        {
            _sideBarPage.NavigateTo();
            _sideBarPage.ResizableButton.Click();

            Assert.IsTrue(_resizablePage.HeaderMessage.Displayed);
            Assert.AreEqual("Resizable", _resizablePage.HeaderMessage.Text);
        }       

        [Test]
        [TestCase(150, 100)]
        public void AnimateFunctionalityByPixels(int xTransition, int yTransition)
        {
            _resizablePage.NavigateTo();
            _resizablePage.AnimateButton.Click();

            int startXCoordinate = _resizablePage.ResizablePoint.Location.X + xTransition;
            int startYCoordinate = _resizablePage.ResizablePoint.Location.Y + yTransition;
            _resizablePage.DragElementByOffset(_resizablePage.ResizablePoint, xTransition, yTransition);
            int endXCoordinate = _resizablePage.ResizablePoint.Location.X;
            int endYCoordinate = _resizablePage.ResizablePoint.Location.Y;

            Assert.AreEqual(startXCoordinate, endXCoordinate, 3);
            Assert.AreEqual(startYCoordinate, endYCoordinate, 3);
        }
    }
}
