using NUnit.Framework;
using TestProjectAqualityFramework.PageObjects;
using Aquality.Selenium.Template.NUnit.Extensions;
using TestProjectAqualityFramework.Utilities;
using EuroNewsTest.PageObjects;

namespace TestProjectAqualityFramework.Tests
{
    internal class TestWeb : BaseTest
    {
        String email = "abc@gmail.com";
        private readonly MainForm mainForm = new MainForm();
        private readonly NewsletterForm newsletterForm = new NewsletterForm();
        private readonly EmailForm emailForm = new EmailForm();
        private readonly CookiesForm cookiesForm = new CookiesForm();
        private readonly EmailConfirmationForm emailConfirmationForm = new EmailConfirmationForm();
        private readonly PreviewForm previewForm = new PreviewForm();
        private readonly UnsubscriptionForm unsubscriptionForm = new UnsubscriptionForm();

       

        [Test]
        public void TestCase1()
        {
            
            mainForm.AssertIsPresent();
            mainForm.HitNextPageButton();

            newsletterForm.AssertIsPresent();
           

            Assert.AreEqual("CHOSEN", newsletterForm.SelectRandomNewsletter(),"Button was not changed");

            emailForm.AssertIsPresent();
            emailForm.SendKeysEmail(email);
            emailForm.ClicksubmitButton();



            emailConfirmationForm.AssertIsPresent();
            emailConfirmationForm.ClickCloseButton();

            newsletterForm.clickPreviewForm();
            previewForm.AssertIsPresent();


            previewForm.ClickUnsubscribeBtn();

            unsubscriptionForm.AssertIsPresent();
            unsubscriptionForm.SendKeysEmail(email);

            Assert.AreEqual(unsubscriptionForm.getSuccessMsg(), "You are unsubscribed.");
            




        }
        [Test]
        public void testcase2()

        {
            mainForm.AssertIsPresent();
            mainForm.HitNextPageButton();

            newsletterForm.AssertIsPresent();

            Assert.IsTrue( newsletterForm.CompareWithExpectedData(),"Not all test data in present on web page");
            previewForm.ClickSpecialCoverageBtn();

            Assert.AreEqual(previewForm.getPreviewMsg(), "No preview available.","Preview button was not clicked");

            previewForm.ClickSpecialCoveragePreviewCloseBtn();

            newsletterForm.SelectRandomPreview();
            previewForm.AssertIsPresent();
            previewForm.ClickAllNewsBtn();
            newsletterForm.AssertIsPresent();

        }
       
      

    }
}
