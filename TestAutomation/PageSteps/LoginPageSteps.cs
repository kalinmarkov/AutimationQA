namespace TestAutomation.PageSteps
{
    using OpenQA.Selenium;
    using TestAutomation.Entities;
    using TestAutomation.Pages.LoginPage;

    public class LoginPageSteps
    {
        //FeatureOne
        private readonly IWebDriver _driver;

        public LoginPage LoginPage;
        public User user;

        public LoginPageSteps(IWebDriver driver, LoginPage loginPage)
        {
            this._driver = driver;
            this.LoginPage = loginPage;
        }

        public void LogInOnSite(string username, string password)
        {
            LoginPage.Login(username, password);
            //LoginPage.Login()
        }

        public void NavigateToSite()
        {
            LoginPage.NavigateTo();
        }
    }
}
