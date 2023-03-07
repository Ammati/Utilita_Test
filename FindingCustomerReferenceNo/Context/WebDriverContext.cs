using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Utilita.UITests.Context
{
    public class WebDriverContext
    {
        public WebDriver Driver { get; set; }
        public IWait<IWebDriver> WebDriverWait { get; set; }
    }
}
