using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using AutomationTask.TestAutoFramework.Utility;
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
        public void EnterAdressOrPostcode(string adressPostcodeData)
        {

            foreach (var symbol in adressPostcodeData)
            {
                AdressPostcode.Type(symbol.ToString());
                Utils.WaitUntilVisible(By.XPath($"//*[contains(@title, '{adressPostcodeData}')]"));
            }
            AdressPostcode.SendKeys(Keys.Enter);
        }

        public void ClickContinue()
        {
            Utils.WaitUntilVisible(TrySearchAgain.Locator, 3);
            Utils.ClickUntilInvisibility(Continue.Locator, TrySearchAgain.Locator);
        }
    }
}
