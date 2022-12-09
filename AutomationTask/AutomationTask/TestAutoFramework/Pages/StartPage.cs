using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Pages
{
    public class StartPage : Form
    {
        public StartPage() : base(By.Id("nav-header"), "Base oddsking page")
        {
        }
        private ILabel Join => ElementFactory.GetLabel(By.XPath("//a[contains(@data-actionable,'Header.LoggedOut.buttonJoin')]"), "Registration button");
        private IButton AcceptCookies => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'Header.CookieBanner.accept_cookies')]"), "Accept cookies");

        public void GoToRegistration()
        {
            AcceptCookies.Click();
            Join.ClickAndWait();   
        }
    }
}
