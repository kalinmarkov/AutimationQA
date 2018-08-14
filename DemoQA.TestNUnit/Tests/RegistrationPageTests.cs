namespace DemoQA.TestNUnit.Tests
{
    using DemoQA.TestNUnit.Factory;
    using DemoQA.TestNUnit.Models;
    using DemoQA.TestNUnit.Pages.RegistrationPage;
    using DemoQA.TestNUnit.Pages.SideBarPage;
    using NPOI.SS.UserModel;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    class RegistrationPageTests
    {
        private IWebDriver _driver;
        private RegistrationPage _registrationPage;
        private SideBarPage _sideBarPage;
        private RegistrationUser _user;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _registrationPage = new RegistrationPage(_driver);
            _sideBarPage = new SideBarPage(_driver);
            _user = new RegistrationUser();
            _user = UserFactory.GenerateRegUser();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var path = Path.GetPathRoot(@"..\..\..\Screenshots\");
                screenshot.SaveAsFile(path + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            }

            _driver.Close();
            _driver.Quit();
        }

        //[Test]
        //public void NavigateToregistrationPage()
        //{
        //    var path = Path.GetFullPath(@"\QAautomation\DemoQA.TestNUnit\demo.xlsx");
        //    using (var file = new FileStream(path, FileMode.Open))
        //    {
        //        IWorkbook workbook = WorkbookFactory.Create(file);
        //        ISheet sheet = workbook.GetSheet("DemoSheet");

        //        for (int i = 6; i < 7; i++)
        //        {
        //            IRow row = sheet.GetRow(i);
        //            _user.FirstName = row.GetCell(0).StringCellValue;
        //            _user.LastName = row.GetCell(1).StringCellValue;
        //            // _user.MatrialStatus = row.GetCell(2).StringCellValue;
        //            // _user.Hobbies = row.GetCell(3).StringCellValue;
        //            _user.Country = row.GetCell(4).StringCellValue;
        //            _user.Month = row.GetCell(5).StringCellValue;
        //            _user.Day = row.GetCell(6).StringCellValue;
        //            _user.Year = row.GetCell(7).StringCellValue;
        //            _user.Phone = row.GetCell(8).StringCellValue;
        //            _user.UserName = row.GetCell(9).StringCellValue;
        //            _user.Email = row.GetCell(10).StringCellValue;
        //            _user.PicturePath = row.GetCell(11).StringCellValue;
        //            _user.Description = row.GetCell(12).StringCellValue;
        //            _user.Password = row.GetCell(13).StringCellValue;
        //            _user.ConfirmPassword = row.GetCell(14).StringCellValue;


        //        }

        //        for (int i = 1; i < 4; i++)
        //        {
        //            IRow row = sheet.GetRow(i);
        //            var person = new DemoExcel();
        //            person.Name = row.GetCell(0).StringCellValue;
        //            person.Age = row.GetCell(1).StringCellValue;
        //            person.JobTitle = row.GetCell(2).StringCellValue;
        //        }

        //    }

        //    //_sideBarPage.RegistrationButton.Click();

        //    //Assert.IsTrue(_registrationPage.HeaderMessage.Displayed);
        //    //StringAssert.Contains("Registration", _registrationPage.HeaderMessage.Text);
        //}

        [Test]
        public void OpenRegistrationPage()
        {
            _sideBarPage.NavigateTo();
            _sideBarPage.RegistrationButton.Click();

            _registrationPage.ValidationTextAsserter("Registratio", _registrationPage.HeaderMessage);
        }

        [Test]
        public void RegistrateWithValidDataShouldPass()
        {
            _registrationPage.NavigateTo();

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("Thank you for your registration", _registrationPage.SuccessRegistrationMessage);
        }

        [Test]
        public void RegistrateWithExistingDataShouldFail()
        {
            _registrationPage.NavigateTo();

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("Error: Username already exists", _registrationPage.FailedRegistrationMessage);
        }

        [Test]
        [TestCase("", "")]
        [TestCase("Gosho", "")]
        public void CheckNameFieldValidation(string firstName, string lastName)
        {
            _registrationPage.NavigateTo();
            _user.FirstName = firstName;
            _user.LastName = lastName;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* This field is required", _registrationPage.NameValidationMessage);
        }

        [Test]
        [TestCase("")]
        public void CheckEmptyPhoneFieldValidation(string phone)
        {
            _registrationPage.NavigateTo();
            _user.Phone = phone;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* This field is required", _registrationPage.PhoneValidationMessage);
        }

        [Test]
        [TestCase("0")]
        [TestCase("123456789")]
        [TestCase("qwertyuiop")]
        public void CheckPhoneFieldRequiredDigitsValidation(string phone)
        {
            _registrationPage.NavigateTo();
            _user.Phone = phone;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* Minimum 10 Digits starting with Country Code", _registrationPage.PhoneValidationMessage);
        }

        [Test]
        [TestCase("")]
        public void CheckEmptyEmailFieldValidation(string email)
        {
            _registrationPage.NavigateTo();
            _user.Email = email;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* This field is required", _registrationPage.EmailValidationMessage);
        }

        [Test]
        [TestCase("a")]
        [TestCase("a.a")]
        [TestCase("a@a:")]
        [TestCase("a@a.")]
        [TestCase("a@a.1")]
        public void CheckEmailFieldValidationWithInvalidData(string email)
        {
            _registrationPage.NavigateTo();
            _user.Email = email;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* Invalid email address", _registrationPage.EmailValidationMessage);
        }

        [Test]
        [TestCase("")]
        public void CheckEmptyPasswordFieldValidation(string password)
        {
            _registrationPage.NavigateTo();
            _user.Password = password;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* This field is required", _registrationPage.PasswordValidationMessage);
        }

        [Test]
        [TestCase("123")]
        [TestCase("1")]
        [TestCase("1234567")]
        public void CheckPasswordFieldRequiredSymbolsValidation(string password)
        {
            _registrationPage.NavigateTo();
            _user.Password = password;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* Minimum 8 characters required", _registrationPage.PasswordValidationMessage);
        }

        [Test]
        [TestCase("")]
        public void CheckEmptyChangePasswordFieldValidation(string confirmPassword)
        {
            _registrationPage.NavigateTo();
            _user.ConfirmPassword = confirmPassword;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* This field is required", _registrationPage.ConfirmPasswordValidationMessage);
        }

        [Test]
        [TestCase("hahahaha", "gogo")]
        [TestCase("password", "password1")]
        public void CheckPasswordMatchingValidation(string password, string confirmPassword)
        {
            _registrationPage.NavigateTo();
            _user.Password = password;
            _user.ConfirmPassword = confirmPassword;

            _registrationPage.FillRegistrationForm(_user);

            _registrationPage.ValidationTextAsserter("* Fields do not match", _registrationPage.ConfirmPasswordValidationMessage);
        }

    }
}
