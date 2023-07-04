using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace InterviewPracticeSelenium
{
    public class Tests
    {
        public IWebDriver driver;
        [Test]
        public void test1()
        {
            ChromeOptions options = new ChromeOptions();

            // Set the capability to accept SSL certificates
            Console.WriteLine(options.BrowserName);
          //  options.AddArgument("--incognito");
            
            driver= new ChromeDriver(options);


            driver.Url = "https://www.google.com";

            Actions actions = new Actions(driver);
            IWebElement el=driver.FindElement(By.Id("APjFqb"));
            IWebElement submit = driver.FindElement(By.XPath("//input[contains(@class, 'gNO89b') and contains(@name,'btnK')]"));

            actions.SendKeys(el,"Neela").Perform();
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", submit);
            // actions.Click(submit);

            jsExecutor.ExecuteScript().




/**

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().AsynchronousJavaScript=TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver, IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) =>
            {
                Console.WriteLine("Waiting for color to change");
                IWebElement element = Web.FindElement(By.Id("target"));
                if (element.GetAttribute("style").Contains("red"))
                {
                    return element;
                }
                return null;
            });

         wait.PollingInterval = TimeSpan.FromSeconds(10);
            wait.Until(waitForElement);
            wait.IgnoreExceptionTypes();**/





            // driver.Close();
        }
       
    }
}