using FindingCustomerReferenceNo.Model;
using FindingCustomerReferenceNo.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Utilita.UITests.Context;

namespace FindingCustomerReferenceNo.StepDefinitions
{
    [Binding]
    public class ThenStpes
    {
        public WebDriverContext Context { get; }
        public PageContext PageContext { get; }

        public ThenStpes(WebDriverContext context, PageContext pageContext)
        {
            Context = context;
            PageContext = pageContext;
        }

        [Then(@"utilita help page is displayed")]
        public void ThenUtilitaHelpPageIsDisplayed()
        {
            PageContext.HelpPage = new HelpPage(Context.Driver, Context.WebDriverWait);

        }

        [Then(@"YourCustomerReferenceNumber page is dispalyed")]
        public void ThenYourCustomerReferenceNumberPageIsDispalyed()
        {
            PageContext.SearchCRNPage = new SearchCRNPage(Context.Driver, Context.WebDriverWait);
            PageContext.SearchCRNPage.WaitForPageLoad();
        }

        [Then(@"error message '([^']*)' is displayed")]
        public void ThenErrorMessageIsDisplayed(string expectedErrorMessage)
        {
            var actulErrorMessage = PageContext.SearchCRNPage.GetErrorMessage();
            actulErrorMessage.Should().Be(expectedErrorMessage);
        }

        [Then(@"user enter the email as follows")]
        public void ThenUserEnterTheEmailAsFollows(Table table)
        {
            var crnTable = table.CreateInstance<CustomerReferenceDataTable>();
            PageContext.SearchCRNPage.EnterEmailAddress(crnTable.Email);
        }

        [Then(@"user enter the email and postcode as follows")]
        public void ThenUserEnterTheEmailAndPostcodeAsFollows(Table table)
        {
            var crnTable = table.CreateInstance<CustomerReferenceDataTable>();
            PageContext.SearchCRNPage.EnterEmailAddress(crnTable.Email);
            PageContext.SearchCRNPage.EnterPostcode(crnTable.Postcode);
        }
    }
}
