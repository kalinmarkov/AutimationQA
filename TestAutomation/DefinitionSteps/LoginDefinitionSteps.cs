namespace TestAutomation.DefinitionSteps
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;
    using TestAutomation.Entities;
    using TestAutomation.Pages.LoginPage;
    using TestAutomation.PageSteps;

    [Binding]
    public class LoginDefinitionSteps
    {
        private LoginPage loginPage;

        public IWebDriver driver;

        public LoginPageSteps loginPageSteps;

        [Before]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            loginPageSteps = new LoginPageSteps(driver, loginPage);
        }

        [After]
        public void Teardown()
        {
            driver.Quit();
        }

        [Given(@"I Navigate to the Login page")]
        public void GivenINavigateToTheLoginPage()
        {
            loginPageSteps.NavigateToSite();
        }
        
        [When(@"I Login with Username '(.*)' and Password '(.*)' on the Login Page")]
        public void WhenILoginWithUsernameAndPasswordOnTheLoginPage(string username, string password)
        {
            loginPageSteps.LogInOnSite(username, password);
        }

        [When(@"I Login with valid Username and Password")]
        public void WhenILoginWithValidUsernameAndPassword(Table table)
        {
            //var users = table.CreateSet<User>();
            dynamic data = table.CreateDynamicInstance();

            //foreach (var user in users)
            //{
            //    System.Console.WriteLine(user.Name);
            //    System.Console.WriteLine(user.Password);
            //}

            loginPageSteps.LogInOnSite(data.Username, data.Password);
        }

        [When(@"I Unsucessfully Login with Username '(.*)' and Password '(.*)' on the Login Page")]
        public void WhenIUnsucessfullyLoginWithUsernameAndPasswordOnTheLoginPage(string username, string password)
        {
            loginPageSteps.LogInOnSite(username, password);
        }

        [Then(@"the User Name '(.*)' Should be seen on the Dashboard Page")]
        public void ThenTheUserNameShouldBeSeenOnTheDashboardPage(string username)
        {
            loginPage.AssertUsername(username);
        }

        [Then(@"I Should See Error Message '(.*)' for '(.*)'")]
        public void ThenIShouldSeeErrorMessageOnTheLoginPage(string errorMessage, string reason)
        {
            loginPage.AssertErrorMessage(reason, errorMessage);
        }
    }
}
