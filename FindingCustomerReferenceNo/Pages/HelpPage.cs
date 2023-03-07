using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FindingCustomerReferenceNo.Pages
{
    public class HelpPage : BasePage
    {
        private IWebElement CustomerReferenceElement => Driver.FindElement(By.LinkText("Your Customer Reference Number"));

        public HelpPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
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
