using FindingCustomerReferenceNo.Model;
using FindingCustomerReferenceNo.Pages;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FindingCustomerReferenceNo.StepDefinitions
{
    [Binding]
    public class Steps
    {
        public HomePage HomePage;
        public HelpPage HelpPage;

        public SearchCRNPage FindCustomerReferenceNoPage;
        public Context Context { get; }
        public Steps(Context context)
        {
            Context = context;
        }

        [Given(@"user open the utilita home page")]
        public void GivenUserOpenTheUtilitaHomePage()
        {
            Context.Driver.Url = TestContext.Parameters["Url"] ;
            HomePage = new HomePage(Context.Driver, Context.WebDriverWait);
            HomePage.AcceptCookies();
        }

        [When(@"user click  on Help")]
        public void WhenUserClickOnHelp()
        {
            HomePage.ClickOnHelpElement();
        }

        [Then(@"utilita help page is displayed")]
        public void ThenUtilitaHelpPageIsDisplayed()
        {
            HelpPage = new HelpPage(Context.Driver, Context.WebDriverWait);

        }

        [When(@"user click on YourCustomerReferenceNumber")]
        public void WhenUserClickOnYourCustomerReferenceNumber()
        {
            HelpPage.ClickOnCustomerReferenceElement();

        }

        [Then(@"YourCustomerReferenceNumber page is dispalyed")]
        public void ThenYourCustomerReferenceNumberPageIsDispalyed()
        {
            FindCustomerReferenceNoPage = new SearchCRNPage(Context.Driver, Context.WebDriverWait);
            FindCustomerReferenceNoPage.WaitForPageLoad();
        }

        [When(@"user clicks on Find button")]
        public void WhenUserClicksOnFindButton()
        {
            FindCustomerReferenceNoPage.ClickOnFindElement();
        }

        [Then(@"error message '([^']*)' is displayed")]
        public void ThenErrorMessageIsDisplayed(string expectedErrorMessage)
        {
            var actulErrorMessage = FindCustomerReferenceNoPage.GetErrorMessage();
            actulErrorMessage.Should().Be(expectedErrorMessage);
        }

        [Then(@"user enter the email as follows")]
        public void ThenUserEnterTheEmailAsFollows(Table table)
        {
            var email = table.CreateInstance<CustomerReferenceDataTable>().Email;
            FindCustomerReferenceNoPage.EnterEmailAddress(email);
        }

        [Then(@"user enter the email and postcode as follows")]
        public void ThenUserEnterTheEmailAndPostcodeAsFollows(Table table)
        {
            var email = table.CreateInstance<CustomerReferenceDataTable>().Email;
            FindCustomerReferenceNoPage.EnterEmailAddress(email);
            var postcode = table.CreateInstance<CustomerReferenceDataTable>().Postcode;
            FindCustomerReferenceNoPage.EnterPostcode(postcode);
        }
    }
}
