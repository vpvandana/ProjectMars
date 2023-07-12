using ProjectMars.Pages;
using ProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    public class LanguageFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginpageobject;
        
        LanguageSection languagesectionobject;

        public LanguageFeatureStepDefinitions() 
        {
            loginpageobject = new LoginPage();
            
            languagesectionobject = new LanguageSection();
        }
        [Given(@"Launch Mars and login with valid credentials")]
        public void GivenLaunchMarsAndLoginWithValidCredentials()
        {
            // driver = new ChromeDriver();
            loginpageobject.LoginSteps();
            
            
        }

        [When(@"Add Languages and level '([^']*)' and '([^']*)' I know")]
        public void WhenAddLanguagesAndLevelAndIKnow(string language, string level)
        {
            languagesectionobject.AddLanguage(language,level);
        }

        [Then(@"Languages has been added successfully'([^']*)'and '([^']*)'")]
        public void ThenLanguagesHasBeenAddedSuccessfullyand(string language, string level)
        {
            string newLanguage = languagesectionobject.GetLanguage();
            string newLevel = languagesectionobject.GetLevel();

            Assert.AreEqual(language, newLanguage, "Actual Language and expected language do not match");
            Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");

        }


                [When(@"I Update the existing language '([^']*)' and '([^']*)'")]
        public void WhenIUpdateTheExistingLanguageAnd(string Language, string Level)
        {
            
            languagesectionobject.UpdateLanguage(Language , Level);

        }

        [Then(@"The record is updated'([^']*)' and '([^']*)'")]
        public void ThenTheRecordIsUpdatedAnd(string language, string level)
        {
            
            string editedLanguage = languagesectionobject.GetEditedLanguage();
            string editedLanguageLevel = languagesectionobject.GetEditedLevel();

            Assert.AreEqual(language, editedLanguage, "The actual language and edited language does not match");
            Assert.AreEqual(level, editedLanguageLevel, "The actual language and edited language does not match");
        }


        [When(@"I click on cancel icon of added")]
        public void WhenIClickOnCancelIconOfAdded()
        {
            languagesectionobject.DeleteLanguage();
        }

        [Then(@"Language record is deleted")]
        public void ThenLanguageRecordIsDeleted()
        {
            string errorMessage = languagesectionobject.GetDeleteLanguage();
            string expectedMessage = "Dutch has been deleted from your languages";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"I left language and level field empty")]
        public void WhenILeftLanguageAndLevelFieldEmpty()
        {
            languagesectionobject.AddEmptyFieldLanguage();
        }

        [Then(@"Error message language and level empty is displayed")]
        public void ThenErrorMessageLanguageAndLevelEmptyIsDisplayed()
        {
            string errorMessage = languagesectionobject.GetEmptyFieldErrorMessage();
            string expectedMessage = "Please enter language and level";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual message and error message do not match");
        }

        [When(@"I add language and level already added '([^']*)' and '([^']*)'")]
        public void WhenIAddLanguageAndLevelAlreadyAddedAnd(string language, string level)
        {
            languagesectionobject.AddLanguage(language, level);
        }

        [Then(@"Error message Language and level already exists is displayed")]
        public void ThenErrorMessageLanguageAndLevelAlreadyExistsIsDisplayed()
        {
            string errorMessage = languagesectionobject.GetDuplicateLanguageLevel();
            string expectedMessage = "This language is already exist in your language list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual message and error message do not match");
        }


        [When(@"I add language already added with different level '([^']*)','([^']*)'")]
        public void WhenIAddLanguageAlreadyAddedWithDifferentLevel(string language, string level)
        {
            languagesectionobject.AddLanguage(language, level);
        }

        [Then(@"Duplicated data message is displayed")]
        public void ThenDuplicatedDataMessageIsDisplayed()
        {
            string errorMessage = languagesectionobject.GetDuplicateLanguage();
            string expectedMessage = "Duplicated data";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual message and error message do not match");
        }

        [When(@"Add Languages I know using keyboard keys")]
        public void WhenAddLanguagesIKnowUsingKeyboardKeys()
        {
            languagesectionobject.AddLanguageKeyboard();
        }

        [Then(@"language is added successfully")]
        public void ThenLanguageIsAddedSuccessfully()
        {
            string newLanguage = languagesectionobject.GetLanguageKeyboard();
            string newLevel = languagesectionobject.GetLevelKeyboard();

            Assert.AreEqual("Korean", newLanguage, "Actual Language and expected language do not match");
            Assert.AreEqual("Basic", newLevel, "Actual Language and expected language do not match");
        }

        [When(@"Click on edit icon and update button without making changes")]
        public void WhenClickOnEditIconAndUpdateButtonWithoutMakingChanges()
        {
            languagesectionobject.UpdateLanguageNoChanges();
        }

        [Then(@"Error message Language and level already added is displayed")]
        public void ThenErrorMessageLanguageAndLevelAlreadyAddedIsDisplayed()
        {
            string errorMessage = languagesectionobject.GetUpdateNoChangesLanguage();
            string expectedMessage = "This language is already added to your language list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"Update language '([^']*)' and level '([^']*)' and click on cancel")]
        public void WhenUpdateLanguageAndLevelAndClickOnCancel(string language, string level)
        {
            languagesectionobject.UpdateLanguageCancel(language,level);
        }

        [Then(@"Updated changes are not saved for '([^']*)' and '([^']*)'")]
        public void ThenUpdatedChangesAreNotSavedForAnd(string language, string level)
        {
            string editedLanguage = languagesectionobject.GetNoUpdateLanguage();
            string editedLevel = languagesectionobject.GetNoUpdateLanguageLevel();

            Assert.AreNotEqual(language, editedLanguage, "Updates are not made for language");
            Assert.AreNotEqual(level, editedLevel, "Updates are not made for level");
        }







    }


}
