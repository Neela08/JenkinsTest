using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Browsers;

namespace TestProjectAqualityFramework.PageObjects
{
    internal class UnsubscriptionForm:Form
    {
        private IButton submitBtn = ElementFactory.GetButton(By.XPath("//button[contains(@class,'btn')]"), "submitBtn");
        private ITextBox emailField = ElementFactory.GetTextBox(By.Id("email"), "Email field");
        private ILabel succesMsg = ElementFactory.GetLabel(By.XPath("//div[contains(@class,'col-md-6')]//p"), "succesMsg");
        public UnsubscriptionForm() : base(By.ClassName("col-md-6"), "UnsubscriptionForm") { }
        public void ClickCloseButton() => submitBtn.Click();
        public void SendKeysEmail(String email) => emailField.ClearAndType(email);
        public String getSuccessMsg()=> succesMsg.Text;

    }
}
