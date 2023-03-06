using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingCustomerReferenceNo.Pages
{
    public class HomePage
    {
        public IWebDriver Driver { get; }
        public IWait<IWebDriver> Wait { get; }
        private IWebElement AcceptAllCookiesElement => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));

        //private IWebElement HelpElement => Driver.FindElement(By.XPath("//*div/ul[@class='top-bar-menu active']/div/div/li[4]/a"));
        private IWebElement GetAQuoteElement => Driver.FindElement(By.LinkText("Get a quote"));
        private IWebElement HelpElement => Driver.FindElement(By.LinkText("Help"));


        public HomePage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            Driver = driver;
            Wait = wait;
        }

        /* public void WaitForPageLoad()
         {
             Wait.Until(driver => GetAQuoteElement.Displayed);
         }*/
        public void AcceptCookies()
        {
            Wait.Until(_ => AcceptAllCookiesElement.Displayed);
            AcceptAllCookiesElement.Click();

        }
        public void ClickOnHelpElement()
        {
            HelpElement.Click();
        }
    }
}
