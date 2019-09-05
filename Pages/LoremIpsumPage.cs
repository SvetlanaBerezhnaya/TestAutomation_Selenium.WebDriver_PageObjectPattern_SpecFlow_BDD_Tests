using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class LoremIpsumPage : TestPage
    {
        public PageName PageName;
        private Collection<TestPage> Pages;
        public LoremIpsumPage()
        {
            WebDriver = new ChromeDriver();            
            Pages = InitializePages();
        }
        public LoremIpsumPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.LoremIpsumPage;
            Url = "https://www.lipsum.com";
        }
        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new LoremIpsumPage(WebDriver),
            };
        }
        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.AmountInputField, By.XPath("//*[@id='amount']")),
                new Locator(Element.BytesRadioButton, By.Id("bytes")),
                new Locator(Element.GenerateLoremIpsumButton, By.Id("generate")),
                new Locator(Element.LipsumText, By.Id("lipsum"))
            };
        }
    }
}