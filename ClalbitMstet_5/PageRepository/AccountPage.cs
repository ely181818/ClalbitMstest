
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClalbitMstet_5
{
    internal class AccountPage
    {

        IWebDriver driver;
        public List<infrastructure.Contact> data;

        By uniform_id_gender = By.Id("uniform-id_gender1");
        By customer_firstname = By.Id("customer_firstname");
        By customer_lastname = By.Id("customer_lastname");
        By passwd = By.Id("passwd");
        By address = By.Id("address1");
        By SubmitLogin = By.Id("SubmitLogin");
        By city = By.Id("city");
        By postcode = By.Id("postcode");
        By phone_mobile = By.Id("phone_mobile");
        By alias = By.Id("alias");
        By submitAccount = By.Id("submitAccount");
        By logout = By.ClassName("logout");
        By email = By.Id("email");
        By account = By.ClassName("account");
        By span = By.TagName("span");
        By days = By.Id("days");
        By months = By.Id("months");
        By years = By.Id("years");
        By company = By.Id("company");
        



        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            this.data = infrastructure.ReadCSVFile();
        }



        
        public void personal_information_updating()
        {
            infrastructure.WaitUntilElementClickable(driver, uniform_id_gender);
            driver.FindElement(uniform_id_gender).Click();
            driver.FindElement(customer_firstname).SendKeys(data[0].firstname);
            driver.FindElement(customer_lastname).SendKeys(data[0].lastname);
            driver.FindElement(passwd).SendKeys(data[0].passwd);
            driver.FindElement(address).SendKeys(data[0].address);
            string my_data = data[0].date.Replace("/", "");
            infrastructure.SelectElement(driver, my_data.Substring(0, 1), days, "SelectByValue");
           
            infrastructure.SelectElement(driver, my_data.Substring(1, 1), months, "SelectByValue");

            infrastructure.SelectElement(driver, my_data.Substring(2, 4), years, "SelectByValue");



            
        }

        public void addres_updating() {

            //your address

            
            driver.FindElement(company).SendKeys(data[0].company);
            driver.FindElement(city).SendKeys(data[0].city);
            infrastructure.SelectElement(driver, data[0].state, By.Id("id_state"), "SelectByText");
            driver.FindElement(postcode).SendKeys(data[0].postcode);
            driver.FindElement(phone_mobile).SendKeys(data[0].phone_mobile);
            driver.FindElement(alias).SendKeys(data[0].alias_address);
            driver.FindElement(submitAccount).Click();
            infrastructure.WaitUntilElementClickable(driver, By.ClassName("page-heading"));
            infrastructure.WaitUntilElementClickable(driver, By.XPath("//p[contains(text(),'Welcome to your account. Here you can manage all of your personal information and orders.')]"));
            driver.FindElement(logout).Click();
            driver.FindElement(email).SendKeys(data[0].mail);
            driver.FindElement(passwd).SendKeys(data[0].passwd);
            driver.FindElement(SubmitLogin).Click();
            
        }


        public void assert_customer_name() {

            string customer_NAME = driver.FindElement(account).FindElement(span).Text;
            Assert.AreEqual("Mikel Merino", customer_NAME);
        }
       




    }
}
