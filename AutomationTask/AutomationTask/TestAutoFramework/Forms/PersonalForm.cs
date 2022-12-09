using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class PersonalForm : Form
    {
        public PersonalForm() : base(By.XPath("//button[contains(@data-actionable,'RegistrationPage.PersonalSection.title.Mr')]"), "Personal data")
        {
        }
        private IButton Continue => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'RegistrationPage.NavigationButtonsPage2.Continue')]"), "Continue");
        private ITextBox FirstName => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.PersonalSection.first_name')]"), "First name");
        private ITextBox LastName => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.PersonalSection.last_name')]"), "First name");
        private ITextBox BirthDay => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.DateOfBirthInput.day')]"), "Birth Day");
        private ITextBox BirthMonth => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.DateOfBirthInput.month')]"), "Birth month");
        private ITextBox BirthYear => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.DateOfBirthInput.year')]"), "Birth month");
        public void EnterFirstName(string firstNameData)
        {
            FirstName.Type(firstNameData);
        }

        public void EnterLastName(string lastNameData)
        {
            LastName.Type(lastNameData);
        }

        public void EnterDateOfBirth(string dateOfBirthData)
        {
            var splitDateOfBirth = dateOfBirthData.Split('.');
            BirthDay.Type(splitDateOfBirth[0]);
            BirthMonth.Type(splitDateOfBirth[1]);
            BirthYear.Type(splitDateOfBirth[2]);
        }

        public void ClickContinue()
        {
            Continue.Click();
            AqualityServices.ConditionalWait.
                      WaitFor(() => FirstName.State.IsDisplayed == false, TimeSpan.FromSeconds(3));
            Continue.ClickAndWait();
        }
    }
}
