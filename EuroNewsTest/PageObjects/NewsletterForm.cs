using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Newtonsoft.Json;
using OpenQA.Selenium;
using TestProjectAqualityFramework.Utilities;

namespace TestProjectAqualityFramework.PageObjects
{
    public  class NewsletterForm : Form

    {   private int randomIndex;
        
        
        public NewsletterForm() : base(By.Id("newsletters-form"), "NewsletterForm") { }
        public String SelectRandomNewsletter()
        {
 
            var divElements = ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'bg-white') and contains(@class, 'shadow-lg')]"));


            var random = new Random();
            var index = random.Next(0, divElements.Count-1);
            randomIndex = index;
           
            var randomDivElement = divElements[index];

            
            var buttonElement = randomDivElement.FindChildElement<IButton>(By.XPath("//label[contains(@class, 'btn-tertiary') and contains(@class, 'unchecked-label') and contains(text(), 'Choose this newsletter')]"));

            buttonElement.JsActions.ClickAndWait();

             var changedbuttonElement = randomDivElement.FindChildElement<IButton>(By.XPath("//label[contains(@class, 'btn-tertiary-plain') and contains(@class, 'checked-label') and contains(text(), 'Chosen')]"));

            return changedbuttonElement.GetText();
            
        }
        public void clickPreviewForm()

        {
            var divElements = ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'bg-white') and contains(@class, 'shadow-lg')]"));


            var randomDivElement = divElements[randomIndex];


            var buttonElement = randomDivElement.FindChildElement<IButton>(By.CssSelector("div.p-8 > a:last-of-type"));

            buttonElement.JsActions.ClickAndWait();

        }
        public void SelectRandomPreview()
        {
            var divElements = ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'bg-white') and contains(@class, 'shadow-lg')]"));

            var random = new Random();
            var index = random.Next(0, divElements.Count - 1);
            var randomDivElement = divElements[index];


            var buttonElement = randomDivElement.FindChildElement<IButton>(By.CssSelector("div.p-8 > a:last-of-type"));

            buttonElement.JsActions.ClickAndWait();
        }
        public List<NewsletterCard> extractInfo()
        {
            List<NewsletterCard> newsletterCards = new List<NewsletterCard>();
            var divElements = ElementFactory.FindElements<ILabel>(By.XPath("//div[contains(@class, 'bg-white') and contains(@class, 'shadow-lg')]"));


            for (int i = 0; i < divElements.Count; i++)
            {
                var randomDivElement = divElements[i];

                var headline = randomDivElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class, 'p-8')]//h2"));


                var frequency = randomDivElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class, 'p-8')]//p"));


                var description = randomDivElement.FindChildElement<ILabel>(By.XPath("//div[contains(@class, 'p-8')]//div[contains(@class,'mt-4')]//p"));


                NewsletterCard card1 = new NewsletterCard { Name = headline.Text, Frequency = frequency.Text, Description = description.Text };

                newsletterCards.Add(card1);

            }

           
            return newsletterCards;

        }
        public bool CompareWithExpectedData()
        {
            
            var json = File.ReadAllText(ProjectPath.GetProjectPath()+@"\Resources\TestData.json");
            var expectedDataList = JsonConvert.DeserializeObject<List<NewsletterCard>>(json);

            var extractedDataList = extractInfo();

            foreach (var expectedData in expectedDataList)
            {
                var matchingData = extractedDataList.FirstOrDefault(data =>
                    data.Name == expectedData.Name &&
                    data.Frequency == expectedData.Frequency &&
                    data.Description == expectedData.Description);

                if (matchingData == null)
                {
                    
                    return false;
                }
            }
            
            return true;
         
        }


    }
}
