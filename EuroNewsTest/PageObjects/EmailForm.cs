using OpenQA.Selenium;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Elements.Interfaces;

namespace TestProjectAqualityFramework.PageObjects
{
    public class EmailForm :Form
    {

        private IButton sendButton = ElementFactory.GetButton(By.XPath("//input[contains(@class, 'btn-primary') and contains(@class, 'cursor-pointer') and contains(@class, 'w-full') and contains(@class, 'md:inline-block')]"), "sendButton");
        private ITextBox emailField = ElementFactory.GetTextBox(By.XPath("//input[@class='w-full' and @type='email'  and @title='Enter your email' and @placeholder='Enter your email']"), "emailField");
        public EmailForm() : base(By.Id("register-newsletters-form"), "EmailForm") { }
        public void SendKeysEmail(String email) =>emailField.SendKeys(email);
        public void ClicksubmitButton() => sendButton.Click();

    }
}
