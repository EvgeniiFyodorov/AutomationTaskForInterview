using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class VerificationForm : Form
    {
        public VerificationForm() : base(By.XPath("//button[contains(@data-actionable,'AgeVerificationBlock.PageVariant.chat.start')]"), "Verification")
        {
        }
        private IButton StartLiveChat => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'AgeVerificationBlock.PageVariant.chat.start')]"), "Live chat");
        private IButton BrowseSite => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'RegistrationPage.RegistrationSuccess.browse.desktop')]"), "Browse site");
        public bool IsVerificationPageUp()
        {
            return StartLiveChat.State.IsDisplayed || BrowseSite.State.IsDisplayed;            
        }
    }
}
