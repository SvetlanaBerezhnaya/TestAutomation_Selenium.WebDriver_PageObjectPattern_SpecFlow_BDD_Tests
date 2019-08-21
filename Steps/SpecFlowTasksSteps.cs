using NUnit.Framework;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowSelenium.Steps
{
    [Binding]
    public class SpecFlowTasksSteps
    {
        private AutomationTestSite automationTestSite;        
        private string Lipsum;
        public SpecFlowTasksSteps(AutomationTestSite automationTestSite)
        {
            this.automationTestSite = automationTestSite;            
        }

        [Given(@"I have navigated to BBC site")]
        public void GivenIHaveNavigatedToBBCSite()
        {
            automationTestSite.GoTo();
        }

        [When(@"I click the News link")]
        public void WhenIClickTheNewsLink()
        {
            automationTestSite.ClickElementOnPage(PageName.BBCTestSite, Element.NewsLink);
        }

        [Then(@"the title of the first article should have the following value:")]
        public void ThenTheTitleOfTheFirstArticleShouldHaveTheFollowingValue(Table table)
        {
            var firstArticle1 = table.CreateInstance<FirstArticle>();
            string firstArticle = automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.FirstArticleLink);
            Assert.AreEqual(firstArticle1.firstArticle, firstArticle);
        }

        [Then(@"the titles of the secondary articles should have the following values:")]
        public void ThenTheTitlesOfTheSecondaryArticlesShouldHaveTheFollowingValues(Table table)
        {
            var secondaryArticles1 = table.CreateSet<SecondaryArticles>();
            List<string> secondaryArticlesList = new List<string>();
            secondaryArticlesList.Add(automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.SecondArticleLink));
            secondaryArticlesList.Add(automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.ThirdArticleLink));
            secondaryArticlesList.Add(automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.FourthArticleLink));
            secondaryArticlesList.Add(automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.FifthArticleLink));
            secondaryArticlesList.Add(automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.SixthArticleLink));
            foreach (var secondaryArticle in secondaryArticles1)
            Assert.Contains(secondaryArticle.secondaryArticles, secondaryArticlesList);
        }

        [When(@"I enter the Category of the first article in the Search bar")]
        public void WhenIEnterTheCategoryOfTheFirstArticleInTheSearchBar()
        {
            string toSearch = automationTestSite.GetTheTitleOfTheArticle(PageName.NewsPage, Element.FirstArticleCategoryLink);
            automationTestSite.Search(PageName.NewsPage, Element.Search_input, toSearch);
        }

        [When(@"I press the Search button")]
        public void WhenIPressTheSearchButton()
        {
            automationTestSite.PressTheSearchButton(PageName.NewsPage, Element.Search_button);
        }

        [Then(@"the title of the first searched article should have the following value:")]
        public void ThenTheTitleOfTheFirstSearchedArticleShouldHaveTheFollowingValue(Table table)
        {
            var firstSearchedArticle1 = table.CreateInstance<FirstSearchedArticle>();
            string firstSearchedArticle = automationTestSite.GetTheTitleOfTheArticle(PageName.SearchResultsPage, Element.FirstSearchedArticleLink);
            Assert.AreEqual(firstSearchedArticle1.firstSearchedArticle, firstSearchedArticle);
        }

        [Given(@"I have generated the Lorem ipsum string")]
        public void GivenIHaveGeneratedTheLoremIpsumString()
        {
            automationTestSite.GoTo(PageName.LoremIpsumPage);
            automationTestSite.EnterTextIntoInputField(PageName.LoremIpsumPage, Element.AmountInputField, "140");
            automationTestSite.ClickElementOnPage(PageName.LoremIpsumPage, Element.BytesRadioButton);
            automationTestSite.ClickElementOnPage(PageName.LoremIpsumPage, Element.GenerateLoremIpsumButton);
            this.Lipsum = automationTestSite.GetTextFromElementOnPage(PageName.LoremIpsumPage, Element.LipsumText);
        }

        [When(@"I have navigated to BBC site")]
        public void WhenIHaveNavigatedToBBCSite()
        {
            automationTestSite.GoTo();
        }

        [When(@"I click the More link \(the second one\)")]
        public void WhenIClickTheMoreLinkTheSecondOne()
        {
            automationTestSite.ClickElementOnPage(PageName.NewsPage, Element.More_theSecondLink);
        }

        [When(@"I click the Have your say link")]
        public void WhenIClickTheHaveYourSayLink()
        {
            automationTestSite.ClickElementOnPage(PageName.NewsPage, Element.HaveYourSay_link);
        }

        [When(@"I click the Do you have a question for BBC news\? link")]
        public void WhenIClickTheDoYouHaveAQuestionForBBCNewsLink()
        {
            automationTestSite.ClickElementOnPage(PageName.HaveYourSayPage, Element.DoYouHaveAquestionForBBCnews_link);
        }

        [Then(@"I successfully fill the question form with valid information")]
        public void ThenISuccessfullyFillTheQuestionFormWithValidInformation()
        {
            string[] words = this.Lipsum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.WhatQuestionsWouldYouLikeUsToInvestigate_textarea, this.Lipsum);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Name_input, words[0] + " " + words[1]);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.EmailAddress_input, words[0] + "." + words[1] + "@gmail.com");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Age_input, "99");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Postcode_input, "999999");
            automationTestSite.ClickElementOnPage(PageName.HaveYourSayPage, Element.SignMeUpForBBCNewsDaily_checkbox);            
        }

        [Then(@"I fill the question form with invalid information \(question field consists of (.*) characters\)")]
        public void ThenIFillTheQuestionFormWithInvalidInformationQuestionFieldConsistsOfCharacters(int p0)
        {
            string[] words = this.Lipsum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.WhatQuestionsWouldYouLikeUsToInvestigate_textarea, this.Lipsum);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Name_input, words[0] + " " + words[1]);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.EmailAddress_input, words[0] + "." + words[1] + "@gmail.com");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Age_input, "99");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Postcode_input, "999999");
            automationTestSite.ClickElementOnPage(PageName.HaveYourSayPage, Element.SignMeUpForBBCNewsDaily_checkbox);
        }

        [Then(@"I take a screenshot and save it on my PC")]
        public void ThenITakeAScreenshotAndSaveItOnMyPC()
        {
            automationTestSite.TakeScreenshotAndSaveItOnPC();
        }

        [When(@"I fill the question form with invalid information: the Name input field is empty")]
        public void WhenIFillTheQuestionFormWithInvalidInformationTheNameInputFieldIsEmpty()
        {
            string[] words = this.Lipsum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.WhatQuestionsWouldYouLikeUsToInvestigate_textarea, this.Lipsum);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.EmailAddress_input, words[0] + "." + words[1] + "@gmail.com");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Age_input, "99");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Postcode_input, "999999");
            automationTestSite.ClickElementOnPage(PageName.HaveYourSayPage, Element.SignMeUpForBBCNewsDaily_checkbox);
        }

        [When(@"I click the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            automationTestSite.ClickElementOnPage(PageName.HaveYourSayPage, Element.Submit_button);
        }

        [Then(@"Color of Name input label is red")]
        public void ThenColorOfNameInputLabelIsRed()
        {
            string color = automationTestSite.GetColorOfElementOnPage(PageName.HaveYourSayPage, Element.Name_label);
            Assert.That(color == "rgb(221, 0, 0)" || color == "rgba(221, 0, 0, 1)", "The text color of the 'Name' label is not red.");
        }

        [Then(@"Border Color of Name input field is red")]
        public void ThenBorderColorOfNameInputFieldIsRed()
        {
            string borderColor = automationTestSite.GetBorderColorOfElementOnPage(PageName.HaveYourSayPage, Element.Name_input);
            Assert.That(borderColor == "rgb(221, 0, 0)" || borderColor == "rgba(221, 0, 0, 1)", "The border color of the 'Name' input field is not red.");
        }

        [When(@"I fill the question form with invalid information: the Email address input field is empty")]
        public void WhenIFillTheQuestionFormWithInvalidInformationTheEmailAddressInputFieldIsEmpty()
        {
            string[] words = this.Lipsum.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.WhatQuestionsWouldYouLikeUsToInvestigate_textarea, this.Lipsum);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Name_input, words[0] + " " + words[1]);
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Age_input, "99");
            automationTestSite.EnterTextIntoInputField(PageName.HaveYourSayPage, Element.Postcode_input, "999999");
            automationTestSite.ClickElementOnPage(PageName.HaveYourSayPage, Element.SignMeUpForBBCNewsDaily_checkbox);
        }

        [Then(@"Color of Email address label is red")]
        public void ThenColorOfEmailAddressLabelIsRed()
        {
            string color = automationTestSite.GetColorOfElementOnPage(PageName.HaveYourSayPage, Element.EmailAddress_label);
            Assert.That(color == "rgb(221, 0, 0)" || color == "rgba(221, 0, 0, 1)", "The text color of the 'Email address' label is not red.");
        }

        [Then(@"Border Color of Email address input field is red")]
        public void ThenBorderColorOfEmailAddressInputFieldIsRed()
        {
            string borderColor = automationTestSite.GetBorderColorOfElementOnPage(PageName.HaveYourSayPage, Element.EmailAddress_input);
            Assert.That(borderColor == "rgb(221, 0, 0)" || borderColor == "rgba(221, 0, 0, 1)", "The border color of the 'Email address' input field is not red.");
        }
    }
    public class FirstArticle
    {
        public string firstArticle { get; set; }
    }
    public class SecondaryArticles
    {
        public string secondaryArticles { get; set; }
    }

    public class FirstSearchedArticle
    {
        public string firstSearchedArticle { get; set; }
    }
}