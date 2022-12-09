using Aquality.Selenium.Browsers;
using AutomationTask.DataModel;
using AutomationTask.TestAutoFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public sealed class RegistrationSteps
    {
        ConfigData configData = new ConfigData();
        RedistrationPage RedistrationPage = new RedistrationPage();
        StartPage StartPage = new StartPage();

        [Given("Base web page is opened")]
        public void OpenWebPage()
        {
            AqualityServices.Browser.GoTo(configData.BaseUrl);
        }

        [When("Button Join is pressed")]
        public void StartRegistrationProcess()
        {
            StartPage.GoToRegistration();
        }

        [When("Following Account info is entered:")]
        public void EnterAccountInfo(Table table)
        {
            RedistrationPage.AccountForm.EnterEmail(table.Rows[0]["Email"]);
            RedistrationPage.AccountForm.EnterUserName(table.Rows[0]["Username"]);
            RedistrationPage.AccountForm.EnterPassword(table.Rows[0]["Password"]);
            RedistrationPage.AccountForm.AcceptTermsAndConditions();
            RedistrationPage.AccountForm.ClickContinue();
        }

        [When("Following Personal info is entered:")]
        public void EnterPersonalInfo(Table table)
        {
            RedistrationPage.PersonalForm.EnterFirstName(table.Rows[0]["FirstName"]);
            RedistrationPage.PersonalForm.EnterLastName(table.Rows[0]["LastName"]);
            RedistrationPage.PersonalForm.EnterDateOfBirth(table.Rows[0]["DateOfBirth"]);
            RedistrationPage.PersonalForm.ClickContinue();
        }

        [When("Following Contact info is entered:")]
        public void EnterContactInfo(Table table)
        {
            RedistrationPage.ContactForm.EnterTelephoneNumber(table.Rows[0]["TelephoneNo"]);
            RedistrationPage.ContactForm.ChooseSecurityQuestion();
            RedistrationPage.ContactForm.EnterSecurityAnswer(table.Rows[0]["SecurityQuestionAnswer"]);
            RedistrationPage.ContactForm.ClickContinue();
        }

        [When("Post code '(.*)' is entered")]
        public void EnterPostCode(string postCode)
        {
            RedistrationPage.AddressForm.EnterAdressOrPostcode(postCode);
            RedistrationPage.AddressForm.ClickContinue();
        }

        [When("All No Marketing checkboxes are checked")]
        public void CheckNoMarketingCheckBoxes()
        {
            RedistrationPage.SettingsForm.CheckAllNoMarketingBoxes();
        }

        [When("Button Register is pressed")]
        public void ToVerificationForm()
        {
            RedistrationPage.SettingsForm.ToVerificationForm();
        }

        [Then("Personal info verification page is shown")]
        public void IsRegistrationCompletedSucsessfully()
        {
            Assert.IsTrue(RedistrationPage.VerificationForm.IsVerificationPageUp(), "Verification form is not up, registration is failed");
        }

    }
}