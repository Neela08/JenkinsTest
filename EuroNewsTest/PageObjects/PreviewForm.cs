using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Aquality.Selenium.Browsers;
using System.Text.RegularExpressions;

namespace EuroNewsTest.PageObjects
{
    public class PreviewForm :Form
    {
        private IButton closeButton = ElementFactory.GetButton(By.XPath("//a[@href='#close-modal' and @rel='modal:close' and contains(@class,'close-modal')]"), "Close Button");
        private IButton iframe = ElementFactory.GetButton(By.ClassName("iframe-preview"), "Iframe");
        private IButton specialCoverageBtn = ElementFactory.GetButton(By.XPath("//a[@href='#special-coverage_previews']"), "special Button");
        private ILabel specialCoverageMsg = ElementFactory.GetLabel(By.Id("special-coverage_previews"), "special Button");
       
        private IButton closeSpecialPreviewButton = ElementFactory.GetButton(By.XPath("//div[@id='special-coverage_previews']//a[contains(text(), 'Close')][1]"), "special preview Close Button");

        private IButton unsubscribeBtn = ElementFactory.GetButton(By.XPath("//a[contains(@href, 'unsubscribe')]"),"");
        private IButton allNewsBtn = ElementFactory.GetButton(By.XPath("//a[contains(@href, 'https://www.euronews.com/newsletters')]"), "allNewsBtn");
        public PreviewForm() : base(By.ClassName("iframe-preview"), "PreviewForm") { }
        public void ClickCloseButton() => closeButton.Click();
        public void ClickUnsubscribeBtn ()
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(iframe.GetElement());
            unsubscribeBtn.JsActions.Click();
        }
        public void ClickAllNewsBtn()
        {
            AqualityServices.Browser.Driver.SwitchTo().Frame(iframe.GetElement());
            allNewsBtn.JsActions.Click();
        }

        public void ClickSpecialCoverageBtn()=> specialCoverageBtn.Click();
        public void ClickSpecialCoveragePreviewCloseBtn() => closeSpecialPreviewButton.JsActions.Click();
        public String getPreviewMsg()
        {
            string text = specialCoverageMsg.Text;
            Regex regex = new Regex("No preview available.");
            Match match = regex.Match(text);
            return match.Value;
        }


    }
}
