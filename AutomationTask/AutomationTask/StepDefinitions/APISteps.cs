using Exam;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public sealed class APISteps
    {
        public List<string> Responses => new();

        [When("Request '(.*)' to '(.*)' URL is made")]
        public async Task MakingRequestAsync(string specifiedRequest, string URL)
        {
            Responses.Add(await ApiUtils.GetAsync(URL, specifiedRequest));
        }

        [When("Request '(.*)' to '(.*)' URL is made for each of following parameters:")]
        public async Task MakingRequestsForMultipleParametersAsync(string specifiedRequest, string URL, Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                Responses.Add(await ApiUtils.GetAsync(URL, $"{specifiedRequest}{table.Rows[i]["parameter"]}"));
            }           
        }

        [Then("Service key is returned with status OK")]
        public void CheckStatus()
        {
            Assert.IsTrue(Responses.First().Contains("\"service\":\"OK\""), "Service status is not \"OK\"");
        }

        [Then("Country count is same for all responses")]
        public void CheckIsCountryCountIsSimilar()
        {
            List<int> countryCounts = new();
            foreach (var response in Responses)
            {
                countryCounts.Add(Regex.Matches(response, "true").Count);
            }
            foreach (var count in countryCounts)
            {
                Assert.IsTrue(countryCounts[1] == count, "Country count does not match between responses");
            }
        }
    }
}
