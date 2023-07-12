using ProjectMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Reflection.Emit;

namespace ProjectMars.Pages
{
    public class SkillsSection : CommonDriver
    {
        // private static IWebElement skillsTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
          private static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
          private static IWebElement addSkillTextbox => driver.FindElement(By.Name("name"));
          private static IWebElement addButton => driver.FindElement(By.XPath("//input[starts-with(@type,'button')]"));
          private static IWebElement skillLevelDropdown => driver.FindElement(By.Name("level"));
          private static IWebElement skillTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));

          private static IWebElement chooseLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[1]"));
          private static IWebElement updateButton => driver.FindElement(By.XPath("//*[text()='Skill']//ancestor::thead//following-sibling::tbody//child::span//input[1]"));
          private static IWebElement skillsTab => driver.FindElement(By.XPath("//a[text()='Skills']"));
          private static IWebElement addedSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1][last()]"));
          private static IWebElement addedLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
          private static IWebElement editSkillIcon => driver.FindElement(By.XPath("//*[text()='Skill']//ancestor::thead//following-sibling::tbody[last()]//child::span[1]/i"));
          private static IWebElement editedSkill => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
          private static IWebElement editedSkillLevel => driver.FindElement(By.XPath("//div[text()='Do you have any skills?']/parent::div/following-sibling::div/descendant::tbody/tr/td[2]"));
          private static IWebElement removeIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
          private static IWebElement cancelIcon => driver.FindElement(By.XPath("//*[text()='Skill']//ancestor::thead//following-sibling::tbody//child::span//input[2]"));
        
        public void AddSkills(string skill, string level)
        {
            //----------------ADD NEW SKILL --------------------------
            skillsTab.Click();
            Thread.Sleep(1000);

            addNewButton.Click();

            addSkillTextbox.SendKeys(skill);

            skillLevelDropdown.SendKeys(level);

            addButton.Click();
            Thread.Sleep(3000);

        }
        public string GetSkills()
        {
           /* var selectElement = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            var select = new SelectElement(selectElement);
            IList<IWebElement> optionList = select.Options;
            select.SelectByValue("Coding");*/
            
            
            return addedSkill.Text;
        }

        public string GetLevel()
        {
            
            return addedLevel.Text;

        }

        public void UpdateSkill(string skill, string level)
        {
            //--------------------------------UPDATE SKILL---------------------------------

            skillsTab.Click();
            Thread.Sleep(3000);
           
            //Click on Edit Icon
             editSkillIcon.Click();
             Thread.Sleep(2000);

            //Edit Skill
           
            skillTextBox.Clear();
            Thread.Sleep(1000);
            skillTextBox.SendKeys(skill);
            Thread.Sleep(1000);


            //Edit Skill level
            skillLevelDropdown.SendKeys(level);
           // Thread.Sleep(3000);

            //Click on Update button
          
            updateButton.Click();
            Thread.Sleep(3000);

        }

        public string GetEditedSkill()
        {
            
            return editedSkill.Text;
        }
        public string GetEditedSkillLevel()
        {
           
            return editedSkillLevel.Text;
        }
        public void DeleteSkill()
        {
            skillsTab.Click();
            Thread.Sleep(2000);

            removeIcon.Click();
            Thread.Sleep(1000);
        }

        public string GetDeleteSkill()
        {
            IWebElement actualerrorMessage = driver.FindElement(By.XPath("//div[text()='Coding has been deleted']"));
            return actualerrorMessage.Text;
            
        }

        //TC_003_03
        public void SkillLevelEmpty()
        {
            skillsTab.Click();
           
            addNewButton.Click();
            Thread.Sleep(2000);

            addSkillTextbox.Click();
            addSkillTextbox.Clear();
            Thread.Sleep(1000);

            skillLevelDropdown.Click();
            chooseLevel.Click();

            addButton.Click();
            Thread.Sleep(1000);

        }

        public string GetSkillLevelEmpty()
        {
            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//*[text()='Please enter skill and experience level']"));
            return actualErrorMessage.Text;
          
        }

        //TC_002_04
        public string GetDuplicateSkillLevel()
        {
            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//*[text()='This skill is already exist in your skill list.']"));
            return actualErrorMessage.Text;

        }

        //TC_002_05
        public string GetDuplicateSkill()
        {

            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//div[text()='Duplicated data']"));
            return actualErrorMessage.Text;

        }

         public void AddSkillKeyboard()
        {
            //----------------ADD NEW SKILL USING KEYBOARD --------------------------
            skillsTab.Click();

            addNewButton.Click();
            Thread.Sleep(3000);

            addSkillTextbox.SendKeys("Flexibility");
            Thread.Sleep(2000);

            //Navigate to level using keyboard
            addSkillTextbox.SendKeys(Keys.Tab);
            skillLevelDropdown.SendKeys(Keys.ArrowDown);
            skillLevelDropdown.Click();
            skillLevelDropdown.SendKeys(Keys.Tab);

            Thread.Sleep(1000);
            addButton.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
           
        }
        public string GetSkillKeyboard()
        {
            return addedSkill.Text;
        }

        public string GetSkillLevelKeyboard()
        {
            return addedLevel.Text;
        }

        public void UpdateSkillNoChanges()
        {
            //--------------------------------UPDATE SKILL WITHOUT MAKING CHANGES---------------------------------

            skillsTab.Click();
            
            //Click on Edit Icon
            editSkillIcon.Click();
            Thread.Sleep(3000);

            //Click on update button

            updateButton.Click();
            Thread.Sleep(3000);

        }

        public string GetUpdateNoChangesSkill()
        {
            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//div[text()='This skill is already added to your skill list.']"));
            return actualErrorMessage.Text;

        }

        public void UpdateSkillCancel(string skill, string level)
        {
            skillsTab.Click();

            editSkillIcon.Click();
            Thread.Sleep(3000);

            //Edit Language
            addSkillTextbox.Clear();
            Thread.Sleep(1000);
            addSkillTextbox.SendKeys(skill);

            //Edit Language level
            skillLevelDropdown.SendKeys(level);
            Thread.Sleep(1000);


            cancelIcon.Click();
            Thread.Sleep(1000);
        }

       

    }
}
