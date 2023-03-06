using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingCustomerReferenceNo.Pages
{
    public class HelpPage
    {
        public IWebDriver Driver { get; }
        public IWait<IWebDriver> Wait { get; }

        private IWebElement CustomerReferenceElement => Driver.FindElement(By.LinkText("Your Customer Reference Number"));

        public HelpPage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            Driver = driver;
            Wait = wait;
        }

        public void WaitForPageLoad()
        {
            Wait.Until(driver => CustomerReferenceElement.Displayed);
        }

        public void ClickOnCustomerReferenceElement()
        {
            CustomerReferenceElement.Click();
        }
    }
}
