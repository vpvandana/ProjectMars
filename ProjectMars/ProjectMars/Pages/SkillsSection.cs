using MarsProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class SkillsSection : CommonDriver
    {
        public void AddSkills(IWebDriver driver, string skill)
        {
            //----------------ADD NEW SKILL --------------------------
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addSkillTextbox = driver.FindElement(By.Name("name"));
            addSkillTextbox.SendKeys(skill);

            IWebElement SkillLevelDropdown = driver.FindElement(By.Name("level"));
            Thread.Sleep(1000);

            IWebElement beginnerLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]"));
            beginnerLevel.Click();

            IWebElement addButton = driver.FindElement(By.XPath("//input[starts-with(@type,'button')]"));
            addButton.Click();
        }

        public void UpdateSkill(IWebDriver driver, string skill)
        {
            //--------------------------------UPDATE SKILL---------------------------------

            //Click on Edit Icon
            IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i"));
            editIcon.Click();

            //Edit Language
            IWebElement addLanguageTextbox = driver.FindElement(By.Name("name"));
            addLanguageTextbox.Clear();
            Thread.Sleep(1000);
            addLanguageTextbox.SendKeys(skill);

            //Edit Language level
            IWebElement skillLevelDropdown = driver.FindElement(By.Name("level"));
            Thread.Sleep(1000);

            IWebElement intermediateLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select/option[3]"));
            intermediateLevel.Click();
            Thread.Sleep(2000);

            //Click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[contains(@type,'button')]"));
            updateButton.Click();

        }
        public void DeleteSkill(IWebDriver driver)
        {
            IWebElement removeIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            removeIcon.Click();
        }
    }
}
