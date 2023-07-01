using MarsProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class LanguageSection : CommonDriver
    {
        public void AddLanguage(IWebDriver driver)
        {
            //----------------ADD NEW LANGUAGE --------------------------
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(3000);

            IWebElement addLanguageTextbox = driver.FindElement(By.Name("name"));
            addLanguageTextbox.SendKeys("English");
            Thread.Sleep(2000);

            IWebElement languageLevelDropdown = driver.FindElement(By.Name("level"));
            Thread.Sleep(1000);

            IWebElement basicLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
            basicLevel.Click();

            IWebElement addButton = driver.FindElement(By.XPath("//input[starts-with(@type,'button')]"));
            addButton.Click();
        }
        public string GetLanguage(IWebDriver driver)
        {
            IWebElement addedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return addedLanguage.Text;
        }

      /*  public string GetLevel(IWebDriver driver)
        {
            IWebElement addedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
            //return addedLevel.Text;
            SelectElement select = new SelectElement(addedLevel);
            select.SelectByText(addedLevel.Text);

        } */

        public void UpdateLanguage(IWebDriver driver , string language , string level) 
        {
            //--------------------------------UPDATE LANGUAGE---------------------------------

            //Click on Edit Icon
            //IWebElement lastLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
      
           IWebElement editIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
           editIcon.Click();
           Thread.Sleep(3000);
 
            //Edit Language
            IWebElement addLanguageTextbox = driver.FindElement(By.Name("name"));
            addLanguageTextbox.Clear();
            Thread.Sleep(1000);
            addLanguageTextbox.SendKeys(language);

            //Edit Language level
            IWebElement editLanguageLevel = driver.FindElement(By.Name("level"));
            editLanguageLevel.SendKeys(level);
            Thread.Sleep(1000);

            /*IWebElement conversationalLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[3]"));
            conversationalLevel.Click();*/

            //Click on Update button
            IWebElement updateButton = driver.FindElement(By.XPath("//input[contains(@type,'button')]"));
            updateButton.Click();
            Thread.Sleep(3000);

        }

        public string GetEditedLanguage(IWebDriver driver)
        {
            IWebElement editedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
            return editedLanguage.Text;
        }
        public string GetEditedLevel(IWebDriver driver)
        {
            IWebElement editedLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
            return editedLevel.Text;
        }

        public void AddEmptyFieldLanguage(IWebDriver driver)
        {
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewButton.Click();
            Thread.Sleep(3000);

            //Language field empty
            IWebElement addLanguageTextbox = driver.FindElement(By.Name("name"));
            addLanguageTextbox.Clear();
            Thread.Sleep(1000);

            //Level field empty
            IWebElement languageLevelDropdown = driver.FindElement(By.Name("level"));
            Thread.Sleep(1000);
            IWebElement chooseLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[1]"));
            chooseLevel.Click();

            //Click on add button
            IWebElement addButton = driver.FindElement(By.XPath("//input[starts-with(@type,'button')]"));
            addButton.Click();  

        }

        public string GetErrorMessage(IWebDriver driver)
        {
            IWebElement actualerrorMessage = driver.FindElement(By.XPath("//div[contains(text(),'Please enter language and level')]"));
            string errormessage = actualerrorMessage.Text;
            return errormessage;
        }
        public void DeleteLanguage(IWebDriver driver)
        {
            IWebElement removeIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            removeIcon.Click();
        }
    }
}
