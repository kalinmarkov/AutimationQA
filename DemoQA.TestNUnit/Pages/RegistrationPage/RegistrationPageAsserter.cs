namespace DemoQA.TestNUnit.Pages.RegistrationPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public static class RegistrationPageAsserter
    {
        public static bool ValidationTextAsserter(this RegistrationPage page, string expectedMessage, IWebElement defaultMessage)
        {
            Assert.IsTrue(defaultMessage.Displayed);
            Assert.AreEqual(expectedMessage, defaultMessage.Text);
            return true;
        }
    }
}
