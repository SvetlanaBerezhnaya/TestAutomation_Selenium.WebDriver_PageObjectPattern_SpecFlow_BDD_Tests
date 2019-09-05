using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Support;

namespace Selenium.Pages
{
    public class HaveYourSayPage : TestPage
    {
        public PageName PageName;
        private Collection<TestPage> Pages;
        public HaveYourSayPage()
        {
            WebDriver = new ChromeDriver();
            Pages = InitializePages();
        }
        public HaveYourSayPage(ChromeDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.HaveYourSayPage;
        }
        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new HaveYourSayPage(WebDriver),
            };
        }
        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.DoYouHaveAquestionForBBCnews_link, By.XPath("//div[@class='no-mpu']/div/div[1]/div/div[1]/div/div[2]/div[1]/a")),
                new Locator(Element.WhatQuestionsWouldYouLikeUsToInvestigate_textarea, By.ClassName("text-input--long")),
                new Locator(Element.Name_input, By.XPath(".//*[@placeholder='Name']")),
                new Locator(Element.EmailAddress_input, By.XPath(".//*[@placeholder='Email address']")),
                new Locator(Element.Age_input, By.XPath(".//*[@placeholder='Age']")),
                new Locator(Element.Postcode_input, By.XPath(".//*[@placeholder='Postcode']")),
                new Locator(Element.SignMeUpForBBCNewsDaily_checkbox, By.XPath("//*[starts-with(@id,'hearken-embed-module-3252-')]/div[1]/div[5]/label/input")),
                new Locator(Element.Submit_button, By.XPath("(//button[text()='Submit'])[1]")),
                new Locator(Element.Name_label, By.XPath("//div[@class='input-error-message' and contains(text(), 'Name')]")),
                new Locator(Element.EmailAddress_label, By.XPath("//div[@class='input-error-message' and contains(text(), 'Email address')]"))
            };
        }
    }
}