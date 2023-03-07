using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingCustomerReferenceNo.Pages
{


    public class HomePage : BasePage
    {
        private IWebElement AcceptAllCookiesElement => Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement GetAQuoteElement => Driver.FindElement(By.LinkText("Get a quote"));
        private IWebElement HelpElement => Driver.FindElement(By.LinkText("Help"));


        public HomePage(IWebDriver driver, IWait<IWebDriver> wait):base(driver,wait)
        {
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
