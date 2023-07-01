using MarsProject.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProject.Pages
{
    public class LoginPage : CommonDriver
    {
        
        public void LoginSteps(IWebDriver driver)
        {
            //Launch the Application
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            //Click on Sign In button
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();
            Thread.Sleep(1000);

           //Enter valid Username and Password
            IWebElement emailTextbox = driver.FindElement(By.Name("email"));
            emailTextbox.SendKeys("vandanapurushothaman2@gmail.com");

            IWebElement passwordTextbox = driver.FindElement(By.Name("password"));
            passwordTextbox.SendKeys("vedika2016");

            //Sign In using Login Button
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]"));
            loginButton.Click();
            Thread.Sleep(3000);
        }
       /* public void JoinSteps(IWebDriver driver)
        {
            //Launch the Application
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);

            //Click on Join button
            IWebElement joinButton = driver.FindElement(By.XPath("//*[contains(@class,'ui')]"));
            joinButton.Click();
            Thread.Sleep(1000);

        }*/
    }
}
