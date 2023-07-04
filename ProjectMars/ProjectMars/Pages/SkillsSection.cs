using MarsProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Cast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class SkillsSection : CommonDriver
    {
        public void AddSkills(IWebDriver driver, string skill , string level)
        {
            //----------------ADD NEW SKILL --------------------------
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();

            IWebElement addSkillTextbox = driver.FindElement(By.Name("name"));
            addSkillTextbox.SendKeys(skill);
            Thread.Sleep(1000);

            IWebElement SkillLevelDropdown = driver.FindElement(By.Name("level"));
            Thread.Sleep(1000);
            SkillLevelDropdown.SendKeys(level);
            Thread.Sleep(2000);

            IWebElement addButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addButton.Click();
            Thread.Sleep(2000);
        }

        public string GetSkill(IWebDriver driver)
        {
            IWebElement addedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            return addedSkill.Text;
        }

        public string GetLevel(IWebDriver driver)
        {
            IWebElement addedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[2]"));
            return addedLevel.Text;

        }
        public void UpdateSkill(IWebDriver driver, string skill , string level)
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
            skillLevelDropdown.SendKeys(level);
            Thread.Sleep(3000);

            //Click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[contains(@type,'button')]"));
            updateButton.Click();
            Thread.Sleep(4000);

        }
        public void DeleteSkill(IWebDriver driver)
        {
            IWebElement removeIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            removeIcon.Click();
        }
    }
}
