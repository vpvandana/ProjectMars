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
            string newLevel = languagesectionobject.GetLevel(driver);

            Assert.AreEqual("English", newLanguage, "Actual Language and expected language do not match");
            Assert.AreEqual("Basic" , newLevel , "Actual level and expected level do not match");
           
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

        [When(@"I add language and level already added")]
        public void WhenIAddLanguageAndLevelAlreadyAdded()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.AddLanguage(driver);
        }

        [Then(@"Error message Language and level already exists is displayed")]
        public void ThenErrorMessageLanguageAndLevelAlreadyExistsIsDisplayed()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string errorMessage = languagesectionobject.GetDuplicateLanguageLevel(driver);
            string expectedMessage = "This language is already exist in your language list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"I add language already added with different level")]
        public void WhenIAddLanguageAlreadyAddedWithDifferentLevel()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.AddDuplicateLanguage(driver);
        }

        [Then(@"Duplicated data message is displayed")]
        public void ThenDuplicatedDataMessageIsDisplayed()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string errorMessage = languagesectionobject.GetDuplicateLanguage(driver);
            string expectedMessage = "Duplicated data";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

       /* [When(@"I add already added language with differnt case")]
        public void WhenIAddAlreadyAddedLanguageWithDifferntCase()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.AddDifferentCaseLanguage(driver);
        }

        [Then(@"Language already exists error message is displayed")]
        public void ThenLanguageAlreadyExixtsErrorMessageIsDisplayed()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string errorMessage = languagesectionobject.GetDifferentCaseLanguage(driver);
            string expectedMessage = "This language is already exist in your language list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }*/

        [When(@"I click on cancel icon of added language")]
        public void WhenIClickOnCancelIconOfAddedLanguage()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.DeleteLanguage(driver);
        }

        [Then(@"Language record is deleted")]
        public void ThenLanguageRecordIsDeleted()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string errorMessage = languagesectionobject.GetDifferentCaseLanguage(driver);
            string expectedMessage = "English has been deleted from your languages";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"Add Languages I know using keyboard keys")]
        public void WhenAddLanguagesIKnowUsingKeyboardKeys()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.AddLanguageKeyboard(driver);
        }
    

        [Then(@"language is added successfully")]
        public void ThenLanguageIsAddedSuccessfully()
        {
           LanguageSection languagesectionobject = new LanguageSection();
           string newLanguage = languagesectionobject.GetLanguageKeyboard(driver);
           //string newLevel = languagesectionobject.GetLevel(driver);

           Assert.AreEqual("German", newLanguage, "Actual Language and expected language do not match");
        }

        [When(@"I Click on edit icon and update button without making changes")]
        public void WhenIClikOnEditIconAndUpdateButtonWithoutMakingChanges()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.UpdateLanguageNoChanges(driver);
        }

        [Then(@"Error message Language and level already added is displayed")]
        public void ThenErrorMessageLanguageAndLevelAlreadyAddedIsDisplayed()
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string errorMessage = languagesectionobject.GetUpdateNoChangesLanguage(driver);
            string expectedMessage = "This language is already added to your language list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"I Update language '([^']*)' and level '([^']*)' and click on cancel")]
        public void WhenIUpdateLanguageAndLevelAndClickOnCancel(string Language, string Level)
        {
            LanguageSection languagesectionobject = new LanguageSection();
            languagesectionobject.UpdateLanguageCancel(driver, Language, Level);

        }

        [Then(@"Updated changes are not saved for '([^']*)' and '([^']*)'")]
        public void ThenUpdatedChangesAreNotSavedForAnd(string language, string level)
        {
            LanguageSection languagesectionobject = new LanguageSection();
            string editedLanguage = languagesectionobject.GetEditedLanguage(driver);
            string editedLevel = languagesectionobject.GetEditedLevel(driver);

            Assert.AreEqual(language, editedLanguage, "Updates are not made for language");
            Assert.AreEqual(level, editedLevel, "Updates are not made for level");
        }


    }


}
