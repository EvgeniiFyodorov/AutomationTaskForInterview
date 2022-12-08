using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using AutomationTask.TestAutoFramework.Utility;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Forms
{
    public class SelectFromDateForm : Form
    {
        public SelectFromDateForm() : base(By.XPath("//button[contains(@data-actionable,'Form.Datepicker.Continue')]"), "'From' date picker")
        {
        }
        public const int SixDays = 6;
        private IButton Done => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'Form.Datepicker.Continue')]"), "Done picking date");
        private By DateButtonLocator => By.XPath("//button[contains(@class,'react-calendar__tile react-calendar__month-view__days')]");

        public void PickingDateSevenDaysAgo()
        {
            var rawDateButtons = AqualityServices.Browser.Driver.FindElements(DateButtonLocator);
            List<IWebElement> actualDateButtons = new List<IWebElement>();
            foreach (var date in rawDateButtons)
            {
                if (date.Enabled)
                {
                    actualDateButtons.Add(date);
                }
            }
            actualDateButtons[actualDateButtons.Count - SixDays].Click();
        }

        public void FinishPickingDate()
        {
            //Utils.ClickUntilInvisibility(Done.Locator, DateButtonLocator);
            Done.Click();
        }
    }
}
