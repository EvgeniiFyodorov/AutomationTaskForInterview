using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using AutomationTask.TestAutoFramework.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Pages
{
    public class LottoResultsPage : Form
    {
        public LottoResultsPage() : base(By.XPath("//div[contains(@data-actionable,'Lotto.ResultsDateFilter.SetDateFrom')]"), "Lotto results")
        {
        }

        public SelectFromDateForm SelectFromDateForm = new SelectFromDateForm();

        private IButton SetDateFrom => ElementFactory.GetButton(By.XPath("//div[contains(@data-actionable,'Lotto.ResultsDateFilter.SetDateFrom')]"), "Set date from");
        private IButton ViewResults => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'LottoApp.ResultsPage.DateFilter.submit')]"), "View results");
        By ResultsLabelLocator(string monthYear) => By.XPath($"//div[contains(@data-actionable,'Lotto.DrawTile-IRISHLOTTERY')]//*[contains(text(),'{monthYear}')]");
        public void ClickSetDateFromButton()
        {
            SetDateFrom.Click();
        }

        public void ViewLottoResults()
        {
            ViewResults.Click();
        }

        public List<string> GetAllElementsForSpecificMonth(string monthYear)
        {
            var elements = AqualityServices.Browser.Driver.FindElements(ResultsLabelLocator(monthYear));
            List<string> elementsTexts = new();
            foreach (var elem in elements)
            {
                elementsTexts.Add(elem.Text);
            }
            return elementsTexts;
        }
    }
}
