namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.SelectablePage;
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    class SelectablePageTests
    {
        private IWebDriver _driver;
        private SelectablePage _selectablePage;
        private SideBarPage _sideBarPage;

        [SetUp]
        public void SetUp()
        {            
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _selectablePage = new SelectablePage(_driver);
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
        public void OpenSelectablePage()
        {
            _sideBarPage.NavigateTo();
            _sideBarPage.SelectableButton.Click();

            Assert.IsTrue(_selectablePage.HeaderMessage.Displayed);
            Assert.AreEqual("Selectable", _selectablePage.HeaderMessage.Text);
        }

        [Test]
        public void AnimateFunctionality()
        {
            _selectablePage.NavigateTo();
            _selectablePage.DisplayAsGridButton.Click();
            
            var classBefore = _selectablePage.FirstElement.GetAttribute("class");
            _selectablePage.FirstElement.Click();
            var classAfter = _selectablePage.FirstElement.GetAttribute("class");

            Assert.AreNotEqual(classBefore, classAfter);
        }
    }
}
