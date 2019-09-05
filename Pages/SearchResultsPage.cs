using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class SearchResultsPage : TestPage
    {
        public PageName PageName;
        private Collection<TestPage> Pages;
        public SearchResultsPage()
        {
            WebDriver = new ChromeDriver();
            Pages = InitializePages();
        }
        public SearchResultsPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.SearchResultsPage;
        }
        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new SearchResultsPage(WebDriver),
            };
        }
        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.FirstSearchedArticleLink, By.XPath("//*[@data-result-number='1']/article/div/h1/a"))
            };
        }
    }
}