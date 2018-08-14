namespace TestAutomation.Pages.LoginPage
{
    using OpenQA.Selenium;

    public partial class LoginPage
    {
        private IWebElement Username => _driver.FindElement(By.Id("inputEmail"));

        private IWebElement Password => _driver.FindElement(By.Id("password"));

        private IWebElement LoginBtn => _driver.FindElement(By.Name("login"));

        private IWebElement ProfileName => _driver.FindElement(By.Id("profile"));

        private IWebElement UsernameError => _driver.FindElement(By.Id("inputEmail-error"));

        private IWebElement PasswordError => _driver.FindElement(By.Id("password-error"));

        private IWebElement WrongUsernameOrPassword => _driver.FindElement(By.TagName("strong"));
    }
}
