namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.DatepickerPage;
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using FluentAssertions;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    class DatepickerPageTests
    {
        private IWebDriver _driver;
        private DatepickerPage _datepickerPage;
        private SideBarPage _sideBarPage;

        [SetUp]
        public void SetUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(Path.GetPathRoot(@"..\..\..\Screenshots") + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            }

            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _datepickerPage = new DatepickerPage(_driver);
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
        public void OpenTooltipPage()
        {
            //Arrange
            _sideBarPage.NavigateTo();

            //Act
            _sideBarPage.DatepickerButton.Click();

            //Assert
            _datepickerPage.HeaderMessage.Displayed.Should().BeTrue();
            _datepickerPage.HeaderMessage.Text.Should().Be("Tooltip");
        }

        [Test]
        public void FRAME()
        {
            var currentFrame = _driver.FindElement(By.XPath("//frame[@name='contentFrame']"));
            _driver.SwitchTo().Frame(currentFrame);
            _driver.FindElement(By.XPath("")).Click();
            _driver.SwitchTo().ParentFrame();
            _driver.SwitchTo().DefaultContent();
        }
    }
}
