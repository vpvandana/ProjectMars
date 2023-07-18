using ProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.LayerTree;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Configuration.JsonConfig;
using OpenQA.Selenium.DevTools.V112.Cast;
using SeleniumExtras.WaitHelpers;

namespace ProjectMars.Pages
{
    public class LanguageSection : CommonDriver
    {

        private static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private static IWebElement addLanguageTextbox => driver.FindElement(By.Name("name"));

        private static IWebElement languageLevelDropdown => driver.FindElement(By.Name("level"));

        private static IWebElement addLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));

        private static  IWebElement addButton => driver.FindElement(By.XPath("//input[starts-with(@type,'button')]"));
        private static IWebElement addedLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1][last()]"));
        private static IWebElement addedLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2][last()]"));
        private static IWebElement updateIcon => driver.FindElement(By.XPath("//*[text()='Language']//ancestor::table//child::tbody[last()]//child::span[1]/i"));
        //private static IWebElement editIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i"));
        private static  IWebElement updateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private static IWebElement editedLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        
        private static IWebElement editedLanguageLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement chooseLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[1]"));

        // private  IWebElement actualerrorMessage = driver.FindElement(By.XPath("//div[text()='This language is already exist in your language list.']"));
        private static IWebElement removeIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i"));

        private static IWebElement cancelButton => driver.FindElement(By.XPath("//*[@value='Cancel']"));
        private static IWebElement deletedLanguage => driver.FindElement(By.XPath("//td[1]"));
        private static IWebElement deletedLevel => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        public void AddLanguage(string language , string level)
        {

            //----------------ADD NEW LANGUAGE --------------------------
            
            addNewButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 5);

            
            addLanguageTextbox.SendKeys(language);
  
            languageLevelDropdown.SendKeys(level);
            languageLevelDropdown.Click();

            addButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//input[starts-with(@type,'button')]", 7);
        }
        public string GetLanguage()
        {
            
            return addedLanguage.Text;
        }

        public string GetLevel()
          {
              
              return addedLevel.Text;
         
          } 

       
        public void UpdateLanguage(string language, string level)
        {
            //--------------------------------UPDATE LANGUAGE---------------------------------

            //Click on Edit Icon
            updateIcon.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Language']//ancestor::table//child::tbody[last()]//child::span[1]/i", 5);

            //Edit Language
            addLanguageTextbox.Clear();
            //Thread.Sleep(1000);
            addLanguageTextbox.SendKeys(language);
            Wait.WaitToBeClickable(driver, "Name", "name", 7);
            //Edit Language level
            languageLevelDropdown.SendKeys(level);

            Wait.WaitToBeClickable(driver, "Name", "level", 7);
            //Thread.Sleep(1000);
           

          //  WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // w.Until(ExpectedConditions.ElementToBeClickable(By.TagName("input")));

            //Click on Update button
            updateButton.Click();
            Thread.Sleep(3000);
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1500);
           
             //Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 12);


        }

        public string GetEditedLanguage()
        {
            
            return editedLanguage.Text;
        }
        public string GetEditedLevel()
        {
           
            return editedLanguageLevel.Text;
        }

        public void AddEmptyFieldLanguage()
        {
            //------------------------TC_002_03------------------------

            
            addNewButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 5);

            //Language field empty
            addLanguageTextbox.Clear();
           // Thread.Sleep(1000);

            //Level field empty
            chooseLevel.Click();
            
            //Click on add button  
            addButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//input[starts-with(@type,'button')]", 7);

        }

        //TC_002_03
       public string GetEmptyFieldErrorMessage()
        {
            IWebElement actualerrorMessage = driver.FindElement(By.XPath("//div[contains(text(),'Please enter language and level')]"));
            return actualerrorMessage.Text;
        }

        //TC_002_04
          public string GetDuplicateLanguageLevel()
          {
            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//div[text()='This language is already exist in your language list.']"));
            return actualErrorMessage.Text;
          
          }

       //TC_002_05
        public string GetDuplicateLanguage()
        {
            
            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner' and text()='Duplicated data']"));
            return actualErrorMessage.Text;
           
        }

        //TC_002_10
        public void AddLanguageKeyboard()
        {
            //----------------ADD NEW LANGUAGE USING KEYBOARD --------------------------
            
            addNewButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 5);


            addLanguageTextbox.SendKeys("Korean");
            Thread.Sleep(2000);

            //Navigate to level using keyboard
            addLanguageTextbox.SendKeys(Keys.Tab);
            languageLevelDropdown.SendKeys(Keys.ArrowDown);
            languageLevelDropdown.Click();
            languageLevelDropdown.SendKeys(Keys.Tab);

            //Thread.Sleep(1000);
            addButton.SendKeys(Keys.Enter);
            Wait.WaitToBeClickable(driver, "XPath", "//input[starts-with(@type,'button')]", 7);

        }
        public string GetLanguageKeyboard()
        {
            return addedLanguage.Text;
        }
        public string GetLevelKeyboard()
        {
            return addedLevel.Text;
        }

        public void UpdateLanguageNoChanges()
        {
            //--------------------------------UPDATE LANGUAGE WITHOUT MAKING CHANGES---------------------------------

            //Click on Edit Icon
            
            updateIcon.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Language']//ancestor::table//child::tbody[last()]//child::span[1]/i", 5);

            //Click on update button

            updateButton.Click();
            Thread.Sleep(3000);
           // Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Update']", 10);

        }

        public string GetUpdateNoChangesLanguage()
        {
            IWebElement actualErrorMessage = driver.FindElement(By.XPath("//div[text()='This language is already added to your language list.']"));
            return actualErrorMessage.Text;
           
        }

       public void UpdateLanguageCancel(string language , string level)
       {

           updateIcon.Click();
           Wait.WaitToBeClickable(driver, "XPath", "//*[text()='Language']//ancestor::table//child::tbody[last()]//child::span[1]/i", 5);

            //Edit Language
           addLanguageTextbox.Clear();
           Thread.Sleep(1000);
           addLanguageTextbox.SendKeys(language);

           //Edit Language level
           languageLevelDropdown.SendKeys(level);
          // Thread.Sleep(1000);

           cancelButton.Click();
           
            Wait.WaitToBeClickable(driver, "XPath", "//*[@value='Cancel']", 9);
        }

        public string GetNoUpdateLanguage()
        {
            IWebElement noEditLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[1]"));
            return noEditLanguage.Text;
        }

        public string GetNoUpdateLanguageLevel()
        {
            IWebElement noEditLanguageLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[2]"));
            return noEditLanguageLevel.Text;
        }
        public void DeleteLanguage(string language,string level)
        {
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr"));
            foreach (IWebElement row in rows) 
            {
                IWebElement languageElement = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
                IWebElement languageLevel = row.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]"));
                string languageText = languageElement.Text;
                string languageLevelText = languageLevel.Text;
                Thread.Sleep(1000);

                if(languageText.Equals(language, StringComparison.OrdinalIgnoreCase)&&languageLevelText.Equals(level,StringComparison.OrdinalIgnoreCase))
                {
                    removeIcon.Click();
                    break;
                }
            }
            //removeIcon .Click();
            Thread.Sleep(1000);
          //  Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[4]/tr/td[3]/span[2]/i", 9);
            
        }

        public string GetDeleteLanguage()
        {
            // IWebElement deleteErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div"));
            // return deleteErrorMessage.Text;
           
            return deletedLanguage.Text;
        }

        public string GetDeletedLevel()
        {
            // IWebElement deleteErrorMessage = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']/div"));
            // return deleteErrorMessage.Text;
            return deletedLevel.Text;
        }
     

    }
}
