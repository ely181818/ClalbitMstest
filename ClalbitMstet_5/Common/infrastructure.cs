
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
using System;
using System.IO;
namespace ClalbitMstet_5
{
    internal class infrastructure
    {
        IWebDriver driver;
        private static readonly Random _random = new Random();
        public List<Contact> data;
        By username = By.Id("signInName");
        By password = By.Id("password");
        By loginButton = By.Id("next");


        public infrastructure(IWebDriver driver)
        {
            this.driver = driver;
            infrastructure.AppendToCSV();

        }

        public static IWebElement WaitUntilElementClickable(IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            // return random.NextDouble() * (maximum - minimum) + minimum;
            double value = random.NextDouble() * (maximum - minimum) + minimum;
            value = (double)System.Math.Round(value, 1);
            return value;
        }

   


        public static void SelectElement(IWebDriver driver,string SelectBy, By elemnt,string  type) {

            if (type== "SelectByText") {
                List<IWebElement> textfields = new List<IWebElement>();
                SelectElement oSelect = new SelectElement(driver.FindElement(elemnt));
                oSelect.SelectByText(SelectBy);
            }
            if (type == "SelectByValue")
            {
                List<IWebElement> textfields = new List<IWebElement>();
                SelectElement oSelect = new SelectElement(driver.FindElement(elemnt));
                oSelect.SelectByValue(SelectBy);
            }


        }
     

public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public class Contact
        {
       

            public string Url { get; set; }
            public string mail { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string passwd { get; set; }
            public string address { get; set; }
            public string date { get; set; }
            
            public string company { get; set; }
            public string city { get; set; }
           
            public string state { get; set; }
            public string postcode { get; set; }

            public string phone_mobile { get; set; }
            public string alias_address { get; set; }

        }


        public class Contacts
        {

            public static List<Contact> GetContacts()
            {
                string mail = RandomString(5);
                mail = mail + "@gmail.com";
                return new List<Contact>()
            {
                new Contact(){Url="http://automationpractice.com", mail=mail,firstname="Mikel", lastname="Merino",passwd="191919",address="Campfire Ave Fairfield",date="1/1/1998",company="IBBL", city="CA",state="California",postcode="94534",phone_mobile="050732976",alias_address="Campfire Ave Fairfield"}

            };
            }
        }

        public static void AppendToCSV()
        {
            File.Delete("contacts.csv");
            var myFile = File.Create("contacts.csv");
            myFile.Close();

            var list = Contacts.GetContacts();
            foreach (var c in list)
            {
                File.AppendAllText("contacts.csv", $"{c.Url},{c.mail},{c.firstname},{c.lastname},{c.passwd},{c.address},{c.date},{c.company},{c.city},{c.state},{c.postcode},{c.phone_mobile},{c.alias_address}\n");

            }
        }
        public static List<Contact> ReadCSVFile()
        {
            var lines = File.ReadAllLines("contacts.csv");
            List<Contact> list = new List<Contact>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 13)
                {

                    var contact = new Contact() { Url = values[0], mail = values[1], firstname = values[2], lastname = values[3], passwd = values[4], address = values[5], date= values[6], company =values[7]    , city = values[8], state = values[9], postcode = values[10], phone_mobile = values[11], alias_address = values[12] };
                    list.Add(contact);
                }
            }
            //   list.ForEach(x => Console.WriteLine($"{x.Name}\t{x.Phone}"));
            return list;
        }
    }
}
