using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace ClalbitMstet_5
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
 
        [TestInitialize]
        public void TestInitialize()
        {
            
         driver = new EdgeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
         
        }

     

        [TestMethod]
        public void TestMethod1()
        {

        
            loginPage loginPage = new loginPage(driver);
            loginPage.email_create_user();
            loginPage.ClickCreateButton();
            AccountPage AccountPage = new AccountPage(driver);
            AccountPage.personal_information_updating();
            AccountPage.addres_updating();
            AccountPage.assert_customer_name();

        }


        [TestCleanup]
        public void TestCleanup()
        {
            try
            {


                driver.Quit();
            }
            catch (Exception)
            {


            }
        }


    }
}