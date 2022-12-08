using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using AutomationTask.TestAutoFramework.Utility;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class AccountForm : Form
    {
        public AccountForm() : base(By.XPath("//div[contains(@data-actionable,'RegistrationPage.AccountSection')]"), "Account data")
        {
        }
        private IButton Continue => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'RegistrationPage.NavigationButtonsPage1.Continue')]"), "Continue");
        private ITextBox Email => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.AccountSection.email')]"), "Email");
        private ITextBox UserName => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.AccountSection.username')]"), "Usermane");
        private ITextBox Password => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.AccountSection.password')]"), "Password");
        private ICheckBox TermsAndConditions => ElementFactory.GetCheckBox(By.XPath("//div[contains(@data-actionable,'RegistrationPage.TermsAndConditions.agree_terms')]"), "Terms and conditions");

        public void EnterEmail(string emailData)
        {
            Email.Type(emailData);
        }

        public void EnterUserName(string userNameData)
        {
            UserName.Type(userNameData);
        }

        public void EnterPassword(string passwordData)
        {
            Password.Type(passwordData);
        }

        public void AcceptTermsAndConditions()
        {
            TermsAndConditions.Check();
        }

        public void ClickContinue()
        {
            Utils.ClickUntilInvisibility(Continue.Locator, Email.Locator);
        }
    }
}
