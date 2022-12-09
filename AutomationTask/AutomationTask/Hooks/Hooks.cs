using Aquality.Selenium.Browsers;
using TechTalk.SpecFlow;

namespace AutomationTask.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario("Front")]
        public static void BeforeFeature()
        {
            AqualityServices.Browser.Maximize();
        }

        [AfterScenario("Front")]
        public static void AfterFeature()
        {
            AqualityServices.Browser.Quit();
        }
    }
}