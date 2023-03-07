using FindingCustomerReferenceNo.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Utilita.UITests.Context;

namespace FindingCustomerReferenceNo.StepDefinitions
{
    [Binding]
    public class GivenSteps
    {
        public WebDriverContext DriverContext { get; }
        public PageContext PageContext { get; }

        public GivenSteps(WebDriverContext driverContext, PageContext pageContext)
        {
            DriverContext = driverContext;
            PageContext = pageContext;
        }

        [Given(@"user open the utilita home page")]
        public void GivenUserOpenTheUtilitaHomePage()
        {
            DriverContext.Driver.Url = TestContext.Parameters["Url"];
            PageContext.HomePage = new HomePage(DriverContext.Driver, DriverContext.WebDriverWait);
            PageContext.HomePage.AcceptCookies();
        }
    }
}
