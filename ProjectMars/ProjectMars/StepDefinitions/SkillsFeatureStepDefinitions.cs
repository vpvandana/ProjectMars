using ProjectMars.Pages;
using ProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection.Emit;
using TechTalk.SpecFlow;
using ProjectMars.Features;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginpageobject;
       
        SkillsSection skillssectionobject;

        public SkillsFeatureStepDefinitions()
        {
            loginpageobject = new LoginPage();
           
            skillssectionobject = new SkillsSection();
        }
      
        [Given(@"Launch Mars with valid credentials")]
        public void GivenLaunchMarsWithValidCredentials()
        {
            //driver = new ChromeDriver();
            //LoginPage loginpageobject = new LoginPage();
            loginpageobject.LoginSteps();
        }

       



        [When(@"I add skills '([^']*)'  and '([^']*)' I have")]
        public void WhenIAddSkillsAndIHave(string  skill, string level)
        {
            skillssectionobject.AddSkills(skill,level);
        }

        [Then(@"New skills '([^']*)' and '([^']*)' are added to the list")]
        public void ThenNewSkillsAndAreAddedToTheList(string skill, string level)
        {
            string newSkill = skillssectionobject.GetSkills();
            string newLevel = skillssectionobject.GetLevel();

            Assert.AreEqual(skill, newSkill, "Actual skill and expected skill do not match");
            Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");
        }



        [When(@"I Update the existing skill and skill level '([^']*)' and '([^']*)'")]
        public void WhenIUpdateTheExistingSkillAnd(string skill, string level)
        {
            skillssectionobject.UpdateSkill(skill,level);
        }

        [Then(@"The skill record is updated'([^']*)' and '([^']*)'")]
        public void ThenTheSkillRecordIsUpdatedAnd(string skill, string level)
        {
            
            string editedSkill = skillssectionobject.GetEditedSkill();
            string editedSkillLevel = skillssectionobject.GetEditedSkillLevel();

            Assert.AreEqual(editedSkill, skill, "Actual skill and expected skill do not match");
            Assert.AreEqual(editedSkillLevel, level, "Actual level and expected level do not match");
        }



        [When(@"I click on cancel icon of added skill")]
        public void WhenIClickOnCancelIconOfAddedSkill()
        {
          
            skillssectionobject.DeleteSkill();
        }

        [Then(@"Skill deleted successfully from list")]
        public void ThenSkillDeletedSuccessfullyFromList()
        {
          
            string errorMessage = skillssectionobject.GetDeleteSkill();
            string expectedMessage = "Coding has been deleted";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"I left skill and level field empty")]
        public void WhenILeftSkillAndLevelFieldEmpty()
        {
            skillssectionobject.SkillLevelEmpty();
        }

        [Then(@"Error message to enter is displayed")]
        public void ThenErrorMessageToEnterIsDisplayed()
        {
            string errorMessage =  skillssectionobject.GetSkillLevelEmpty();
            string expectedMessage = "Please enter skill and experience level";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");

        }

        [When(@"I add skill and level '([^']*)' and '([^']*)' already in the list")]
        public void WhenIAddSkillAndLevelAndAlreadyInTheList(string skill, string level)
        {
            skillssectionobject.AddSkills(skill, level);    
        }

        [Then(@"Error message Skill already exists is displayed")]
        public void ThenErrorMessageSkillAlreadyExistsIsDisplayedAnd()
        {
            string errorMessage = skillssectionobject.GetDuplicateSkillLevel();
            string expectedMessage = "This skill is already exist in your skill list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"I add same skill with different level '([^']*)' and '([^']*)'")]
        public void WhenIAddSameSkillWithDifferentLevelAnd(string skill, string level)
        {
            skillssectionobject.AddSkills(skill, level);
        }

        [Then(@"Error message Duplicated data is displayed")]
        public void ThenErrorMessageDuplicatedDataIsDisplayed()
        {
            string errorMessage = skillssectionobject.GetDuplicateSkill();
            string expectedMessage = "Duplicated data";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"Add Skills I have using keyboard keys")]
        public void WhenAddSkillsIHaveUsingKeyboardKeys()
        {
            skillssectionobject.AddSkillKeyboard();
        }

        [Then(@"Skill is added to the list successfully")]
        public void ThenSkillIsAddedToTheListSuccessfully()
        {
            string newSkill = skillssectionobject.GetSkillKeyboard();
            string newLevel = skillssectionobject.GetSkillLevelKeyboard();

            Assert.AreEqual("Flexibility", newSkill, "Actual skill and expected skill do not match");
            Assert.AreEqual("Beginner", newLevel, "Actual skill and expected skill do not match");
        }

        [When(@"Click on edit icon of skills and update button without making changes")]
        public void WhenClickOnEditIconOfSkillsAndUpdateButtonWithoutMakingChanges()
        {
            skillssectionobject.UpdateSkillNoChanges();
        }

        [Then(@"Error message skill already exists is displayed")]
        public void ThenErrorMessageSkillAlreadyExistsIsDisplayed()
        {
            string errorMessage = skillssectionobject.GetUpdateNoChangesSkill();
            string expectedMessage = "This skill is already added to your skill list.";

            Assert.AreEqual(expectedMessage, errorMessage, "Actual and expected message do not match");
        }

        [When(@"I update skill and level '([^']*)' and '([^']*)' and click on cancel")]
        public void WhenIUpdateSkillAndLevelAndAndClickOnCancel(string skill, string level)
        {
            skillssectionobject.UpdateSkillCancel(skill, level);
        }

        [Then(@"Updated changes are not saved for '([^']*)','([^']*)'")]
        public void ThenUpdatedChangesAreNotSavedFor(string skill, string level)
        {
            string editedSkill = skillssectionobject.GetEditedSkill();
            string editedSkillLevel = skillssectionobject.GetEditedSkillLevel();

            Assert.AreNotEqual(editedSkill, skill, "Actual skill and expected skill match");
            Assert.AreNotEqual(editedSkillLevel, level, "Actual level and expected level match");
        }


    }
}
