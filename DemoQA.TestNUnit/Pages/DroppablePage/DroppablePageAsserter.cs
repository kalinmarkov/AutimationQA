
namespace DemoQA.TestNUnit.Pages.DroppablePage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public static class DroppablePageAsserter
    {
        public static bool TextAsserter(this DroppablePage page, string expected, IWebElement actual)
        {
            Assert.AreEqual(expected, actual.Text);
            return true;
        }
    }
}
