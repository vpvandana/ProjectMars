using MarsProject.Pages;
using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    [Binding]
    public class SkillsFeatureStepDefinitions : CommonDriver
    {
        [Given(@"Launch Mars with valid credentials")]
        public void GivenLaunchMarsWithValidCredentials()
        {
            driver = new ChromeDriver();
            LoginPage loginpageobject = new LoginPage();
            loginpageobject.LoginSteps(driver);
        }

        [When(@"I navigate to skills section in profile page")]
        public void WhenINavigateToSkillsSectionInProfilePage()
        {
            ProfilePage profilepageobject = new ProfilePage();
            profilepageobject.GotoSkillsFunction(driver);
        }

        [When(@"I add skills '([^']*)' and '([^']*)' I have")]
        public void WhenIAddSkillsAndIHave(string Skills, string Level)
        {
            SkillsSection skillsectionobject = new SkillsSection();
            skillsectionobject.AddSkills(driver , Skills , Level);
        }

        [Then(@"New skills are added to the list '([^']*)' and '([^']*)'")]
        public void ThenNewSkillsAreAddedToTheListAnd(string skill , string level)
        {
            SkillsSection skillsectionobject = new SkillsSection();
            string newSkill = skillsectionobject.GetSkill(driver);
            string newLevel = skillsectionobject.GetLevel(driver);

            Assert.AreEqual(skill, newSkill, "Actual Language and expected language do not match");
            Assert.AreEqual(level, newLevel, "Actual level and expected level do not match");
        }
    }
}
