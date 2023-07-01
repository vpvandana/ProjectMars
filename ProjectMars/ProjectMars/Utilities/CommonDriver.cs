using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using MarsProject.Pages;

namespace MarsProject.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void LoginSteps()

        {
            //Launch Chrome browser
            driver = new ChromeDriver();

            //Login page object initialization and defenition
            LoginPage lp = new LoginPage();
            lp.LoginSteps(driver);
        }

        [OneTimeTearDown]


    public void LoginStepsTearDown() 
        {
            driver.Quit();
        
        }
    }
}
