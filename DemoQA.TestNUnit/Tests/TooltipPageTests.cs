namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using DemoQA.TestNUnit.Pages.Tooltip;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;
    using FluentAssertions;

    [TestFixture]
    class TooltipPageTests
    {
        private IWebDriver _driver;
        private TooltipPage _tooltipPage;
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
            _tooltipPage = new TooltipPage(_driver);
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
            _sideBarPage.TooltipButton.Click();

            //Assert
            _tooltipPage.HeaderMessage.Displayed.Should().BeTrue();
            _tooltipPage.HeaderMessage.Text.Should().Be("Tooltip");
        }

        [Test]
        public void VerifyTextInTooltip()
        {
            //Assert
            _tooltipPage.NavigateTo();

            //Act
            string tooltipText = _tooltipPage.GetTooltipText();

            //Assert
            tooltipText.Should().Be("We ask for your age only for statistical purposes.");
        }

        
    }
}
