using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProjectAqualityFramework.PageObjects
{
     
    public class EmailConfirmationForm : Form
    {
        private IButton closeButton = ElementFactory.GetButton(By.XPath("//a[@href='#close-modal' and @rel='modal:close' and contains(@class,'close-modal')]"),"Close Button");
        public EmailConfirmationForm() : base(By.Id("additional-data-modal"), "EmailConfirmationForm") { }
        
        public void ClickCloseButton()=> closeButton.JsActions.Click();
    }
}
