
using OpenQA.Selenium;
using ProjectMars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars.Pages
{
    public class LoginPage : CommonDriver
    {
       private static IWebElement signInButton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
       private static  IWebElement emailTextbox => driver.FindElement(By.Name("email"));
       private static IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
       private static IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]"));
        public void LoginSteps()
        {
            //Launch the Application
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);


            //Click on Sign In button
            
            signInButton.Click();
            Thread.Sleep(3000);

           //Enter valid Username and Password
           
            emailTextbox.SendKeys("vandanapradeep1991@gmail.com");
            passwordTextbox.SendKeys("12341234");

            //Sign In using Login Button
           
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
