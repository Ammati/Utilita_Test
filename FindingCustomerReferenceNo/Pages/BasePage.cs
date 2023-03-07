using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace FindingCustomerReferenceNo.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; }
        public IWait<IWebDriver> Wait { get; }

        public BasePage(IWebDriver driver, IWait<IWebDriver> wait)
        {
            Driver = driver;
            Wait = wait;
        }
    }
}
