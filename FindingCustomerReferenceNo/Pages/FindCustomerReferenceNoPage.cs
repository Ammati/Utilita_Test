using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingCustomerReferenceNo.Pages
{
    public class FindCustomerReferenceNoPage
    {
        public IWebDriver Driver { get; }
        public IWait<IWebDriver> Wait { get; }

        private IWebElement FindButtonElement => Driver.FindElement(By.XPath("//div[@class='cell large-3 small-12 align-self-top crn-fin-btn-cell']/a"));

        private IWebElement EmailRadioButton => Driver.FindElement(By.XPath("//input[@id='id-email']"));

        private IWebElement EmailTextPlaceholderElement => Driver.FindElement(By.XPath("//input[@id='email-input']"));

        private IWebElement PostcodeTextPlaceholderElement => Driver.FindElement(By.XPath("//input[@class='form-control postcode-input']"));



        public FindCustomerReferenceNoPage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            Driver = driver;
            Wait = wait;
        }

        public void WaitForPageLoad()
        {
            Wait.Until(driver => FindButtonElement.Displayed);
        }

        public void ClickOnFindElement()
        {
            FindButtonElement.Click();
        }
        public string GetErrorMessage()
        {
            var errorMessageBy = By.XPath("//div[@class='callout crn-response-message warning']");
            Wait.Until(d => d.FindElement(errorMessageBy).Displayed);
            return Driver.FindElement(errorMessageBy).Text;
        }

        public void EnterEmailAddress(string email)
        {
            EmailTextPlaceholderElement.SendKeys(email);
        }
        public void EnterPostcode(string postcode)
        {
            PostcodeTextPlaceholderElement.SendKeys(postcode);
        }

    }

}

