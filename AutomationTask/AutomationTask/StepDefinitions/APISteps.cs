using AutomationTask.DataModel;
using AutomationTask.TestAutoFramework.Utility;
using NUnit.Framework;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace AutomationTask.StepDefinitions
{
    [Binding]
    public sealed class APISteps
    {
        ConfigData configData = new ConfigData();
        private readonly ScenarioContext scenarioContext;
        public APISteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [When("Request '(.*)' to specified URL is made")]
        public async Task MakingRequestAsync(string specifiedRequest)
        {
            scenarioContext.Add("StatusResponce", await ApiUtils.GetAsync(configData.ApiUrl, specifiedRequest));
        }

        [When("Request '(.*)' to specified URL is made for each of following parameters:")]
        public async Task MakingRequestsForMultipleParametersAsync(string specifiedRequest, Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                scenarioContext.Add($"LangResponce{i}", await ApiUtils.GetAsync(configData.ApiUrl, $"{specifiedRequest}{table.Rows[i]["parameter"]}"));
            }           
        }

        [Then("Service key is returned with status OK")]
        public void CheckStatus()
        {
            Assert.IsTrue(scenarioContext.Get<string>("StatusResponce").Contains("\"service\":\"OK\""), "Service status is not \"OK\"");
        }

        [Then("Country count is same for all responses")]
        public void CheckIsCountryCountIsSimilar()
        {
            List<int> countryCounts = new();
            for (int i = 0; i < 3; i++)
            {
                countryCounts.Add(Regex.Matches(scenarioContext.Get<string>($"LangResponce{i}"), "true").Count);
            }
            foreach (var count in countryCounts)
            {
                Assert.IsTrue(countryCounts[1] == count, "Country count does not match between responses");
            }
        }
    }
}
