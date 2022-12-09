using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace AutomationTask.TestAutoFramework.Pages
{
    public class LottoPage : Form
    {
        public LottoPage() : base(By.XPath("//div[contains(@data-actionable,'Lotto.LottoBanner')]"), "Lotto")
        {
        }

        ILabel LottoResults => ElementFactory.GetLabel(By.XPath("//a[contains(@data-actionable,'Lotto.SelectLottoBanner.Results')]"), "Lotto");
        private IButton AcceptCookies => ElementFactory.GetButton(By.XPath("//button[contains(@data-actionable,'Header.CookieBanner.accept_cookies')]"), "Accept cookies");

        public void GoToLottoResults()
        {
            AcceptCookies.Click();
            LottoResults.ClickAndWait();
        }
    }
}
