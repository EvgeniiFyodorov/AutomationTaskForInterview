using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class AddressForm : Form
    {
        public AddressForm() : base(By.XPath("//button[contains(@data-actionable,'InputLabel.outsidetheuk?')]"), "Adress data")
        {
        }
        private IButton Continue => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'RegistrationPage.NavigationButtonsPage4.Continue')]"), "Continue");
        private ITextBox AdressPostcode => ElementFactory.GetTextBox(By.XPath("//input[contains(@data-actionable,'RegistrationPage.search_address')]"), "Adress or postcode");
        private IButton TrySearchAgain => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'core.registration.AddressViewer.button.searchAgain')]"), "Try search again");
        private ILabel SearchedAdress(string adressPostcodeData) => ElementFactory.GetLabel(By.XPath($"//*[contains(@title, '{adressPostcodeData}')]"), "Searched adress");
        public void EnterAdressOrPostcode(string adressPostcodeData, int waitTime)
        {
            foreach (var symbol in adressPostcodeData)
            {
                AdressPostcode.Type(symbol.ToString());
                AqualityServices.ConditionalWait.
                    WaitFor(() => SearchedAdress(adressPostcodeData).State.IsDisplayed == false, TimeSpan.FromSeconds(waitTime));
            }
            AdressPostcode.SendKeys(Keys.Enter);
        }

        public void ClickContinue(int waitTime)
        {
            AqualityServices.ConditionalWait.
                      WaitFor(() => TrySearchAgain.State.IsDisplayed == false, TimeSpan.FromSeconds(waitTime));
            Continue.ClickAndWait();
        }
    }
}
