namespace DemoQA.TestNUnit.Pages.RegistrationPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.Generic;
    using System.Linq;

    public partial class RegistrationPage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement FirstName => _driver.FindElement(By.Id("name_3_firstname"));

        public IWebElement LastName => _driver.FindElement(By.Id("name_3_lastname"));
        
        public List<IWebElement> MaritalStatus => this.Driver.FindElements(By.Name("radio_4[]")).ToList();

        public List<IWebElement> Hobbies => _driver.FindElements(By.Name("checkbox_5[]")).ToList();

        public IWebElement Country => _driver.FindElement(By.Id("dropdown_7"));

        public SelectElement CountryOption => new SelectElement(Country);

        public IWebElement Month => _driver.FindElement(By.Id("mm_date_8"));

        public SelectElement MonthOption => new SelectElement(Month);

        public IWebElement Day => _driver.FindElement(By.Id("dd_date_8"));

        public SelectElement DayOption => new SelectElement(Day);

        public IWebElement Year => _driver.FindElement(By.Id("yy_date_8"));

        public SelectElement YearOption => new SelectElement(Year);

        public IWebElement Phone => _driver.FindElement(By.Id("phone_9"));

        public IWebElement UserName => _driver.FindElement(By.Id("username"));

        public IWebElement Email => _driver.FindElement(By.Id("email_1"));

        public IWebElement UploadPicButton => _driver.FindElement(By.Id("profile_pic_10"));

        public IWebElement Description => Wait.Until(d => d.FindElement(By.Id("description")));

        public IWebElement Password => _driver.FindElement(By.Id("password_2"));

        public IWebElement ConfirmPassword => _driver.FindElement(By.Id("confirm_password_password_2"));

        public IWebElement SubmitButton => _driver.FindElement(By.Name("pie_submit"));
      
        public IWebElement NameValidationMessage => _driver.FindElement(By.CssSelector("#pie_register li:nth-child(1) span"));

        public IWebElement PhoneValidationMessage => _driver.FindElement(By.CssSelector("#pie_register li:nth-child(6) span"));

        public IWebElement EmailValidationMessage => _driver.FindElement(By.CssSelector("#pie_register li:nth-child(8) span"));

        public IWebElement PasswordValidationMessage => _driver.FindElement(By.CssSelector("#pie_register li:nth-child(11) span"));

        public IWebElement ConfirmPasswordValidationMessage => _driver.FindElement(By.CssSelector("#pie_register li:nth-child(12) span"));

        public IWebElement FailedRegistrationMessage => _driver.FindElement(By.ClassName("piereg_login_error"));

        public IWebElement SuccessRegistrationMessage => Wait.Until(d => d.FindElement(By.ClassName("piereg_message")));
    }
}
