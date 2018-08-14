namespace DemoQA.TestNUnit.Factory
{
    using DemoQA.TestNUnit.Models;
    using System.Collections.Generic;
    using System.IO;

    public class UserFactory
    {
        public static RegistrationUser GenerateRegUser()
        {
            var _user = new RegistrationUser();
            _user.FirstName = "Goshii";
            _user.LastName = "Goshiiv";
            _user.MatrialStatus = new List<bool>() { false, true, false };
            _user.Hobbies = new List<bool>() { false, true, false };
            _user.Country = "Bulgaria";
            _user.Month = "9";
            _user.Day = "2";
            _user.Year = "1969";
            _user.Phone = "359999999999";
            _user.UserName = "Goshiito";
            _user.Email = "goshiito@goshov.gesh";
            _user.PicturePath = Path.GetPathRoot(@"..\..\..\logo.jpg");
            _user.Description = "Description";
            _user.Password = "Goshistiq";
            _user.ConfirmPassword = "Goshistiq";
            return _user;
        }
    }
}
