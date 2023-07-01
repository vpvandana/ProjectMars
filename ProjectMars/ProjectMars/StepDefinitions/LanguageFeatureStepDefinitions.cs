using MarsProject.Pages;
using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace MarsProject.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        [Given(@"Launch Mars and login with valid credentials")]
        public void GivenLaunchMarsAndLoginWithValidCredentials()
        {
              driver = new ChromeDriver();
              LoginPage loginpageobject = new LoginPage();
              loginpageobject.LoginSteps(driver);
        }

        [When(@"I navigate language section in profile page")]
        public void WhenINavigateLanguageSectionInProfilePage()
        {
            ProfilePage profilepageobject = new ProfilePage();
            profilepageobject.GotoLanguageFunction(driver);
        }

        [When(@"Add Languages I know")]
        public void WhenAddLanguagesIKnow()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.AddLanguage(driver);
        }

        [Then(@"Languages has been added successfully")]
        public void ThenLanguagesHasBeenAddedSuccessfully()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string newLanguage = languagesectionobject.GetLanguage(driver);
            //string newLevel = languagesectionobject.GetLevel(driver);

            Assert.AreEqual("English", newLanguage, "Actual Language and expected language do not match");
            //Assert.AreEqual("");
           
        }

        [When(@"I Update the existing language '([^']*)' and '([^']*)'")]
        public void WhenIUpdateTheExistingLanguageAnd(string Language, string Level)
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.UpdateLanguage(driver, Language , Level);

        }

        [Then(@"The record is updated'([^']*)' and '([^']*)'")]
        public void ThenTheRecordIsUpdatedAnd(string language, string level)
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string editedLanguage = languagesectionobject.GetEditedLanguage(driver);
            string editedLevel = languagesectionobject.GetEditedLevel(driver);

            Assert.AreEqual(language, editedLanguage, "The actual language and edited language does not match");
            Assert.AreEqual(level, editedLevel, "The actual language and edited language does not match");
        }

        [When(@"I left language and level field empty")]
        public void WhenILeftLanguageAndLevelFieldEmpty()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.AddEmptyFieldLanguage(driver);

        }

        [Then(@"Error message is displayed")]
        public void ThenErrorMessageIsDisplayed()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string errorMessage = languagesectionobject.GetErrorMessage(driver);
            string expectedMessage = "Please enter language and level";

            Assert.AreEqual(expectedMessage , errorMessage , "Actual and expected message do not mathch" );

            
        }


    }
}
