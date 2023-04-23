using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProjectAqualityFramework.PageObjects
{
    internal class CookiesForm :Form
    {
        private IButton AcceptCookiesButton => ElementFactory.GetButton(By.XPath("//span[contains(@class,'didomi-continue-without-agreeing')]"), "Accept cookies button");

        public CookiesForm() : base(By.ClassName("cookies"),"Cookies Form"){ }
        public void ClickAcceptCookiesButton() => AcceptCookiesButton.Click();
    }
}
