using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.DefaultWaitHelpers;

namespace AutomationTask.TestAutoFramework.Utility
{
    public static class Utils
    {
        public static bool ClickUntilInvisibility(By clickLocator, By waitLocator, int time = 3)
        {
            WebDriverWait wait = new WebDriverWait(AqualityServices.Browser.Driver, TimeSpan.FromSeconds(time));
            bool flag = false;
            for (int i = 0; i < 15; i++)
            {
                try
                {
                    AqualityServices.Browser.Driver.FindElement(clickLocator).Click();
                    flag = wait.Until(ExpectedConditionsSearchContext.InvisibilityOfElementLocated(waitLocator));
                }
                catch (Exception)
                {
                    continue;
                }
                
                if (flag)
                {
                    return flag;
                }
            }
            return false;
        }

        public static bool WaitUntilVisible(By locator, int time = 1)
        {
            WebDriverWait wait = new WebDriverWait(AqualityServices.Browser.Driver, TimeSpan.FromSeconds(time));
            try
            {
                wait.Until(ExpectedConditionsSearchContext.ElementIsVisible(locator));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
