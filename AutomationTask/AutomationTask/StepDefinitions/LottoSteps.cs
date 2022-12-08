using AutomationTask.TestAutoFramework.Pages;
using AutomationTask.TestAutoFramework.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public sealed class LottoSteps
    {
        LottoPage LottoPage = new LottoPage();
        LottoResultsPage LottoResultsPage = new LottoResultsPage();
        public const int DaysBeforeSeventhDay = 6;

        [When("Button Results is pressed")]
        public void StartRegistrationProcess()
        {
            LottoPage.GoToLottoResults();
        }

        [When("Date period is set")]
        public void SetDatePeriod()
        {
            LottoResultsPage.ClickSetDateFromButton();
            Utils.WaitUntilVisible(LottoPage.Locator);
            LottoResultsPage.SelectFromDateForm.PickingDateSevenDaysAgo();
            Utils.WaitUntilVisible(LottoPage.Locator);
            LottoResultsPage.SelectFromDateForm.FinishPickingDate();
            Utils.WaitUntilVisible(LottoPage.Locator);
        }

        [When("View filtered resuls button is pressed")]
        public void ViewFilteredResults()
        {
            LottoResultsPage.ViewLottoResults();
        }

        [Then("There are no results shown that fall outside of a set date period")]
        public void CheckThatResultsAreInCorrectDate()
        {
            Utils.WaitUntilVisible(LottoPage.Locator);
            var dateNow = DateTime.Now;
            var dateForm = DateTime.Now.AddDays(-DaysBeforeSeventhDay);
            var ResultsTextHeadersPreviousMonth = LottoResultsPage.GetAllElementsForSpecificMonth(dateForm.ToString("MMM yyyy"));
            var ResultsTextHeadersCurrentMonth = LottoResultsPage.GetAllElementsForSpecificMonth(dateNow.ToString("MMM yyyy"));
            foreach (var item in ResultsTextHeadersCurrentMonth)
            {
                var splitItem = item.Split(null);
                Assert.IsTrue(int.Parse(splitItem.First()) <= int.Parse(dateNow.ToString("%d")), $"Item has a date later that {dateNow:dd MMM yyyy}");
            }
            foreach (var item in ResultsTextHeadersPreviousMonth)
            {
                var splitItem = item.Split(null);
                Assert.IsTrue(int.Parse(splitItem.First()) >= int.Parse(dateForm.ToString("%d")), $"Item has a date earlier that {dateForm:dd MMM yyyy}");
            }
        }
    }
}
