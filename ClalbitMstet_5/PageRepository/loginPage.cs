
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

namespace ClalbitMstet_5
{
    internal class loginPage
    {

        IWebDriver driver;
        public List<infrastructure.Contact> data;

        By email_create = By.Id("email_create");
        By login = By.ClassName("login");
        By CreateButton = By.Id("SubmitCreate");


        public loginPage(IWebDriver driver)
        {
            this.driver = driver;
            infrastructure.AppendToCSV();
            this.data = infrastructure.ReadCSVFile();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(data[0].Url);

        }
       



        public void email_create_user()
        {

            infrastructure.WaitUntilElementClickable(driver, login);
            driver.FindElement(login).Click();
            infrastructure.WaitUntilElementClickable(driver, email_create);
            driver.FindElement(email_create).SendKeys(data[0].mail);
        }


        public void ClickCreateButton()
        {
            driver.FindElement(CreateButton).Click();
        }


        

    }
}
