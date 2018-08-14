namespace DemoQA.TestNUnit.Pages.DraggablePage
{
    using NUnit.Framework;
    using OpenQA.Selenium;

    public static class DraggablePageAsserter
    {
        public static bool TextAsserter(this DraggablePage page, string expected, IWebElement actual)
        {
            Assert.AreEqual(expected, actual.Text);
            return true;
        }
    }
}
