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
        public void WhenIUpdateTheExistingSkillAnd(string skill, string slevel)
        {
            skillssectionobject.UpdateSkill(skill,slevel);
        }

        [Then(@"The record is updated '([^']*)' '([^']*)'")]
        public void ThenTheRecordIsUpdated(string skill, string slevel)
        {
          
            string editedSkill = skillssectionobject.GetEditedSkill();
            string editedSkillLevel = skillssectionobject.GetEditedSkillLevel();

            Assert.AreEqual(skill, editedSkill, "Actual skill and edited skill do not match");
            Assert.AreEqual(slevel, editedSkillLevel, "Actual and edited level do not match");
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

      

    }
}
