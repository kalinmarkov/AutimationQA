namespace DemoQA.TestNUnit.Pages.RegistrationPage
{
    using DemoQA.TestNUnit.Models;
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class RegistrationPage : BasePage
    {

        private IWebDriver _driver;

        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
            this._driver = driver;
        }

        public void NavigateTo()
        {
            this._driver.Url = base.Url + "registration/";
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            SureType(FirstName, user.FirstName);
            SureType(LastName, user.LastName);
            FillManyOptionElements(MaritalStatus, user.MatrialStatus);
            FillManyOptionElements(Hobbies, user.Hobbies);
            CountryOption.SelectByText(user.Country);
            MonthOption.SelectByValue(user.Month);
            DayOption.SelectByValue(user.Day);
            YearOption.SelectByValue(user.Year);
            SureType(Phone, user.Phone);
            //You need to change this for every test
            SureType(UserName, user.UserName);
            //You need to change this for every test
            SureType(Email, user.Email);
            this.UploadPicButton.Click();
            _driver.SwitchTo().ActiveElement().SendKeys(user.PicturePath);
            SureType(Description, user.Description);
            SureType(Password, user.Password);
            SureType(ConfirmPassword, user.ConfirmPassword);
            this.SubmitButton.Click();
            
        }

        public void SureType(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        private void FillManyOptionElements(List<IWebElement> elements, List<bool> values)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (values[i])
                {
                    elements[i].Click();
                }
            }
        }
    }
}
