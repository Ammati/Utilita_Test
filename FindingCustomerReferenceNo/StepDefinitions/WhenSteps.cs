using FindingCustomerReferenceNo.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using Utilita.UITests.Context;

namespace FindingCustomerReferenceNo.StepDefinitions
{
    [Binding]
    public class WhenSteps
    {
        public WebDriverContext Context { get; }
        public PageContext PageContext { get; }

        public WhenSteps(WebDriverContext context, PageContext pageContext)
        {
            Context = context;
            PageContext = pageContext;
        }

        [When(@"user click  on Help")]
        public void WhenUserClickOnHelp()
        {
            PageContext.HomePage.Should().NotBeNull();
            PageContext.HomePage?.ClickOnHelpElement();
        }

        [When(@"user click on YourCustomerReferenceNumber")]
        public void WhenUserClickOnYourCustomerReferenceNumber()
        {
            PageContext.HelpPage.ClickOnCustomerReferenceElement();
        }

        [When(@"user clicks on Find button")]
        public void WhenUserClicksOnFindButton()
        {
            PageContext.SearchCRNPage.ClickOnFindElement();
        }
    }
}
