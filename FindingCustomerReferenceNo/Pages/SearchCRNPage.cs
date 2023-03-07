using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FindingCustomerReferenceNo.Pages
{
    public class SearchCRNPage : BasePage
    {
        public SearchCRNPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
        }

        private IWebElement FindButtonElement => Driver.FindElement(By.XPath("//a[text()='Find']"));

        private IWebElement EmailElement => Driver.FindElement(By.XPath("//input[@id='email-input']"));

        private IWebElement PostCodeElement => Driver.FindElement(By.XPath("//input[@name='p_postcode']"));

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
            EmailElement.SendKeys(email);
        }
        public void EnterPostcode(string postcode)
        {
            PostCodeElement.SendKeys(postcode);
        }
    }
}

