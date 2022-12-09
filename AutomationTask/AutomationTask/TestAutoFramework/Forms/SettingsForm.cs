using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class SettingsForm : Form
    {
        public SettingsForm() : base(By.XPath("//div[contains(@data-actionable,'RegistrationPage.SettingsSection.PromotionSection.ThirdParty')]"), "Settings data")
        {
        }
        private List<ICheckBox> AllNoMarketingCheckBoxes => (List<ICheckBox>)ElementFactory.FindElements<ICheckBox>(By.XPath("//div[contains(@data-actionable,'RegistrationPage.PromotionsSelector.noMarketing')]"));
        private IButton Register => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'RegistrationPage.NavigationButtonsPage5.Register')]"), "Register");
        public void CheckAllNoMarketingBoxes()
        {
            foreach (var checkbox in AllNoMarketingCheckBoxes)
            {
                checkbox.Check();
            }
        }

        public void ToVerificationForm()
        {
            AqualityServices.ConditionalWait.
                      WaitFor(() => AllNoMarketingCheckBoxes[0].State.IsDisplayed == false, TimeSpan.FromSeconds(3));
            Register.ClickAndWait();
        }
    }
}
