using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FindingCustomerReferenceNo
{
    public class Context
    {
        public WebDriver Driver { get; set; }
        public IWait<IWebDriver> WebDriverWait { get; set; }
    }
}
