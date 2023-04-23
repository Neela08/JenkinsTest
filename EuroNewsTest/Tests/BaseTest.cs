using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TestProjectAqualityFramework.Utilities;
using Newtonsoft.Json.Linq;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using Level2_Task1.Utilities;

namespace TestProjectAqualityFramework.Tests
{
    public abstract class BaseTest
    {   

        [SetUp]
        public void setup()
        {

            String PathToConfig = Path.Combine(ProjectPath.GetProjectPath(), "Resources","config.json");
            String url=ReadFile.getFile(PathToConfig).GetValue<String>("Url");
            AqualityServices.Browser.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

            AqualityServices.Browser.GoTo(url);
            


        }




        //[TearDown]
        public void CleanUp()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
