using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Utilita.UITests.Context;

namespace FindingCustomerReferenceNo.StepDefinitions
{
    [Binding]
    public class Hook
    {
        public WebDriverContext Context { get; }

        public Hook(WebDriverContext context)
        {
            Context = context;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var browserType = TestContext.Parameters["BrowserType"];

            // If no config found set default values
            if (browserType == null)
                browserType = "chrome";

            var headLessSetting = TestContext.Parameters["Headless"];
            var headLess = false;
            if (headLessSetting != null)
                headLess = Convert.ToBoolean(headLessSetting);

            if (browserType.ToLower() == "chrome")
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("start-maximized");
                if (headLess)
                    options.AddArgument("--headless");

                Context.Driver = new ChromeDriver(options);
            }
            else if (browserType.ToLower() == "firefox")
            {
                Context.Driver = new FirefoxDriver();
            }
            else
            {
                throw new NotImplementedException($"{browserType} is not supported");
            }

            Context.WebDriverWait = new WebDriverWait(Context.Driver, TimeSpan.FromSeconds(30));
            Context.WebDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Context.WebDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            Context.WebDriverWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Context.Driver.Close();
        }
    }
}
