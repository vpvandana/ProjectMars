using MarsProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class ProfilePage : CommonDriver
    {
        public void GotoLanguageFunction(IWebDriver driver) 
        {
            //Navigate to Profile
            IWebElement profileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            profileTab.Click();
            Thread.Sleep(3000);

            //Navigate to Language Section
            IWebElement languageTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
            languageTab.Click();
            Thread.Sleep(3000);
        }

        public void GotoSkillsFunction(IWebDriver driver) 
        {
            //Navigate to Profile
            IWebElement profileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            profileTab.Click();
            Thread.Sleep(3000);

            //Navigate to Skills Section
            IWebElement skillsTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTab.Click();
            Thread.Sleep(3000);
        }
    }
}
