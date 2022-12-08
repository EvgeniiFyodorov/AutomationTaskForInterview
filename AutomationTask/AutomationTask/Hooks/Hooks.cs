using Aquality.Selenium.Browsers;
using TechTalk.SpecFlow;

namespace AutomationTask.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeFeature]
        public static void BeforeFeature()
        {
            AqualityServices.Browser.Maximize();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            AqualityServices.Browser.Quit();
        }
    }
}