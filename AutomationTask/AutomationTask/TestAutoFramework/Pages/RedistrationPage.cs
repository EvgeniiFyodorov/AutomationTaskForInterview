using Aquality.Selenium.Forms;
using AutomationTask.TestAutoFramework.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Pages
{
    public class RedistrationPage : Form
    {
        public RedistrationPage() : base(By.XPath("//h3[contains(@data-actionable,'RegistrationPage.RegisterHeader.title')]"), "Registration page")
        {
        }

        public AccountForm AccountForm = new AccountForm();
        public PersonalForm PersonalForm = new PersonalForm();  
        public ContactForm ContactForm = new ContactForm();
        public AddressForm AddressForm = new AddressForm();
        public SettingsForm SettingsForm = new SettingsForm();
        public VerificationForm VerificationForm = new VerificationForm();
    }
}
