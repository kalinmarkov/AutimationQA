
namespace TestAutomation.Pages.LoginPage
{
    using OpenQA.Selenium;
    using System;
    using FluentAssertions;

    public partial class LoginPage : BasePage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "login.php";
        }

        public void Login(string username, string password)
        {
            SureType(this.Username, username);
            SureType(this.Password, password);
            LoginBtn.Click();
        }

        public void AssertUsername(string username)
        {
            ProfileName.Text.Should().BeEquivalentTo(username);
        }

        public void AssertErrorMessage(string reason, string defaultMessage)
        {
            switch (reason)
            {
                case "Blank Username":
                    UsernameError.Text.Should().Be(defaultMessage);
                    break;
                case "Blank Password":
                    PasswordError.Text.Should().Be(defaultMessage);
                    break;
                case "invalid Password":
                    WrongUsernameOrPassword.Text.Should().Be(defaultMessage);
                    break;         
                default:
                    Console.WriteLine("This feature is not implemented yet");
                    break;
            }
        }

        public void SureType(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
