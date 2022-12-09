using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class ContactForm : Form
    {
        public ContactForm() : base(By.XPath("//label[contains(@for,'RegistrationPage.TelephoneNumberInput.telephone.mobile-telephone')]"), "Contact data")
        {
        }
        private IButton Continue => ElementFactory.GetButton(By.XPath("//div[@class='_17c15pi']//button[contains(@data-actionable,'RegistrationPage.NavigationButtonsPage3.Continue')]"), "Continue");
        private ITextBox TelephoneNumber => ElementFactory.GetTextBox(By.Id("RegistrationPage.TelephoneNumberInput.telephone.desktop-telephone"), "Telephone number");
        private IElement SecurityQestionsElement => ElementFactory.GetLabel(By.XPath("//select[contains(@data-actionable,'RegistrationPage.Dropdown.desktop-securityQuestion')]"), "SecrityQuestions selector");
        private SelectElement SecrityQuestionsSelect => new SelectElement(SecurityQestionsElement.GetElement());
        private ITextBox SecurityAnswer => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.ContactSection.desktop_security_answer')]"), "SecurityAnswer");

        public void EnterTelephoneNumber(string telephoneNumberData)
        {
            TelephoneNumber.Type(telephoneNumberData);
        }

        public void EnterSecurityAnswer(string securityAnswerData)
        {
            SecurityAnswer.Type(securityAnswerData);
        }

        public void ChooseSecurityQuestion(int securityQuestionIndex = 1)
        {
            SecrityQuestionsSelect.SelectByIndex(securityQuestionIndex);
        }

        public void ClickContinue()
        {
            AqualityServices.ConditionalWait.
                      WaitFor(() => TelephoneNumber.State.IsDisplayed == false, TimeSpan.FromSeconds(3));
            Continue.ClickAndWait();
        }
    }
}
