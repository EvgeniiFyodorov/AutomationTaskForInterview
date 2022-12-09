using System.Reflection;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace AutomationTask.DataModel
{
    public class ConfigData
    {
        private static ISettingsFile ConfFile => new JsonSettingsFile(@"Resources.Config.json", Assembly.GetCallingAssembly());

        public string ApiUrl => ConfFile.GetValue<string>("ApiUrl");
        public string BaseUrl => ConfFile.GetValue<string>("BaseUrl");
        public string LottoUrl => ConfFile.GetValue<string>("LottoUrl");
        public int LongTime => ConfFile.GetValue<int>("LongTime");
        public int ShortTime => ConfFile.GetValue<int>("ShortTime");
    }
}