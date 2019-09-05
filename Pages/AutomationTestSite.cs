using System;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.Support;

namespace Selenium.Pages
{
    public class AutomationTestSite
    {
        public PageName PageName;
        public string BaseUrl;
        private ChromeDriver WebDriver;
        private Collection<TestPage> Pages;
        public AutomationTestSite()
        {
            WebDriver = new ChromeDriver();                       
            BaseUrl = "https://www.bbc.com/";
            Pages = InitializePages();
        }
        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new BBCTestSite(WebDriver),
                new NewsPage(WebDriver),
                new SearchResultsPage(WebDriver),
                new LoremIpsumPage(WebDriver),
                new HaveYourSayPage(WebDriver)
            };
        }
        public void GoTo()
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
        }
        public void GoTo(PageName pageName)
        {
            var page = GetPage(pageName);
            WebDriver.Navigate().GoToUrl(page.Url);
        }
        public void EnterTextIntoInputField(PageName pageName, Element element, string text)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Clear();
            WebDriver.FindElement(locator.FindBy).SendKeys(text);
        }
        public string GetTextFromElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            string text = WebDriver.FindElement(locator.FindBy).Text;
            return text;
        }
        public void TakeScreenshotAndSaveItOnPC()
        {
            try
            {
                Screenshot image = ((ITakesScreenshot)this.WebDriver).GetScreenshot();
                image.SaveAsFile("E:/Screenshot.png");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Assert.Fail("Getting screenshot is failed with exception: " + exception);
            }
        }
        public string GetColorOfElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            string text = WebDriver.FindElement(locator.FindBy).GetCssValue("color").Trim();
            return text;
        }
        public string GetBorderColorOfElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            string text = WebDriver.FindElement(locator.FindBy).GetCssValue("border-color").Trim();
            return text;
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
        public TestPage GetPage(PageName pageName)
        {
            return Pages.FirstOrDefault(page => page.Name.Equals(pageName));
        }

        public bool DoesElementExistOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            try
            {
                WebDriver.FindElement(locator.FindBy);
            }
            catch (NoSuchElementException noSuchElementException)
            {
                return false;
            }
            return true;
        }
        public void ClickElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Click();
            System.Threading.Thread.Sleep(5000);
        }
        public void SelectDropDownOption(PageName pageName, Element element, string optionToSelect)
        {
            var locator = GetPage(pageName).GetLocator(element);
            var selectOptionList = WebDriver.FindElement(locator.FindBy).FindElements(By.TagName("option"));
            foreach (IWebElement option in selectOptionList)
            {
                if (option.Text.Equals(optionToSelect))
                {
                    option.Click();
                    return;
                }
            }
            throw new InvalidSelectorException($"{element} option of {optionToSelect} not found");
        }
        public string GetTheTitleOfTheArticle(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            return WebDriver.FindElement(locator.FindBy).Text;
        }
        public void Search(PageName pageName, Element element, string toSearch)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Clear();
            WebDriver.FindElement(locator.FindBy).SendKeys(toSearch);
        }
        public void PressTheSearchButton(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Click();
        }
       public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}