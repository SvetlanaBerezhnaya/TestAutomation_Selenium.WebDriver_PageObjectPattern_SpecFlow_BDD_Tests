using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class NewsPage : TestPage
    {
        public PageName PageName;
        private Collection<TestPage> Pages;
        public NewsPage()
        {
            WebDriver = new ChromeDriver();
            Pages = InitializePages();
        }
        public NewsPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.NewsPage;
        }
        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new NewsPage(WebDriver),
            };
        }
        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.SignInLink, By.XPath("//*[@data-entityid='container-top-stories#1']/div/div/a")),
                new Locator(Element.FirstArticleLink, By.XPath("//*[@data-entityid='container-top-stories#1']/div/div/a")),
                new Locator(Element.SecondArticleLink, By.XPath("//*[@data-entityid='container-top-stories#2']/div/div/a")),
                new Locator(Element.ThirdArticleLink, By.XPath("//*[@data-entityid='container-top-stories#3']/div/div/a")),
                new Locator(Element.FourthArticleLink, By.XPath("//*[@data-entityid='container-top-stories#4']/div/div/a")),
                new Locator(Element.FifthArticleLink, By.XPath("//*[@data-entityid='container-top-stories#5']/div/div/a")),
                new Locator(Element.SixthArticleLink, By.XPath("//*[@data-entityid='container-top-stories#6']/div/div/a")),
                new Locator(Element.FirstArticleCategoryLink, By.XPath("//*[@data-entityid='container-top-stories#1']/div/ul/li[2]/a")),
                new Locator(Element.Search_input, By.XPath("//*[@id='orb-search-q']")),
                new Locator(Element.Search_button, By.XPath("//*[@id='orb-search-button']")),
                new Locator(Element.More_theSecondLink, By.XPath("//span[contains(text(), 'More')]")),
                new Locator(Element.HaveYourSay_link, By.XPath("//*[@id='orb-modules']/header/div[2]/div/div[2]/div/div/ul[4]/li/a/span")),
                new Locator(Element.TopStory_link, By.XPath("//*[@data-entityid='container-top-stories#1']/div/div/a"))
            };
        }
    }
}