using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.Support;

namespace Selenium.Pages
{
    public class BBCTestSite : TestPage
    {
        public BBCTestSite(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.BBCTestSite;
            Url = "https://www.bbc.com/";
        }
        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.NewsLink, By.XPath("//*[@id='orb-nav-links']/ul/li[2]/a"))
            };
        }
        public void GoTo()
        {
            WebDriver.Navigate().GoToUrl(Url);
        }
        public bool PageLoaded()
        {
            try
            {
                var waitForDocumentReady = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
                waitForDocumentReady.Until((wdriver) =>
                    (WebDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch (TimeoutException timeoutException)
            {
                return false;
            }
        }
        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}