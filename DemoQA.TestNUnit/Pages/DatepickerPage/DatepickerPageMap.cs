namespace DemoQA.TestNUnit.Pages.DatepickerPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DatepickerPage
    {
        public IWebElement HeaderMessage => _driver.FindElement(By.ClassName("entry-title"));

        public IWebElement FormatDate => _driver.FindElement(By.Id("dragevent"));

        public IWebElement PreviousMonth => _driver.FindElement(By.CssSelector("#ui-datepicker-div div a:nth-child(1)"));

        public IWebElement NextMonth => _driver.FindElement(By.CssSelector("#ui-datepicker-div div a:nth-child(2)"));

        public List<IWebElement> DaysOfWeek => _driver.FindElements(By.CssSelector("#ui-datepicker-div th")).ToList();

        public List<IWebElement> DaysOfMonth => _driver.FindElements(By.XPath(@"//td[@data-handler=""selectDay""]")).ToList();

        public IWebElement Format => _driver.FindElement(By.Id("format"));

        public SelectElement FormatOption => new SelectElement(Format);
    }
}
