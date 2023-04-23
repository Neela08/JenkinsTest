using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProjectAqualityFramework.PageObjects
{
    internal class MainForm : Form
    {
        private IButton NextPageButton => ElementFactory.GetButton(By.XPath("//span[@class='u-margin-start-1' and text()='Newsletters']"), "Next Page Button");


      
        public MainForm() : base(By.XPath("//span[@class='u-margin-start-1' and text()='Newsletters']"), "Main Form")
        {
        }
       
        public void HitNextPageButton() => NextPageButton.JsActions.ClickAndWait();

    }
}
