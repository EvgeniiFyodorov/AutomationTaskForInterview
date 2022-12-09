using Aquality.Selenium.Browsers;
using AutomationTask.DataModel;
using AutomationTask.TestAutoFramework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public sealed class LottoSteps
    {
        ConfigData configData = new ConfigData();
        LottoPage LottoPage = new LottoPage();
        LottoResultsPage LottoResultsPage = new LottoResultsPage();
        public const int DaysBeforeSeventhDay = 6;

        [Given("Lotto web page is opened")]
        public void OpenWebPage()
        {
            AqualityServices.Browser.GoTo(configData.LottoUrl);
        }

        [When("Button Results is pressed")]
        public void StartRegistrationProcess()
        {
            LottoPage.GoToLottoResults();
        }

        [When("Date period is set")]
        public void SetDatePeriod()
        {
            LottoResultsPage.ClickSetDateFromButton();
            AqualityServices.ConditionalWait.
                   WaitFor(() => LottoPage.State.IsDisplayed == true, TimeSpan.FromSeconds(configData.ShortTime));
            LottoResultsPage.SelectFromDateForm.PickingDateSevenDaysAgo();
            AqualityServices.ConditionalWait.
                   WaitFor(() => LottoPage.State.IsDisplayed == true, TimeSpan.FromSeconds(configData.ShortTime));
            LottoResultsPage.SelectFromDateForm.FinishPickingDate();
            AqualityServices.ConditionalWait.
                   WaitFor(() => LottoPage.State.IsDisplayed == true, TimeSpan.FromSeconds(configData.ShortTime));
        }

        [When("View filtered resuls button is pressed")]
        public void ViewFilteredResults()
        {
            LottoResultsPage.ViewLottoResults();
        }

        [Then("There are no results shown that fall outside of a set date period")]
        public void CheckThatResultsAreInCorrectDate()
        {
            AqualityServices.ConditionalWait.
                   WaitFor(() => LottoPage.State.IsDisplayed == true, TimeSpan.FromSeconds(configData.ShortTime));
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
