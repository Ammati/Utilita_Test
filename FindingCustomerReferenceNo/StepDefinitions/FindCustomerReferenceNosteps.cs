using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssertions;
using System.Data;
using TechTalk.SpecFlow.Assist;
using FindingCustomerReferenceNo.Model;
using FindingCustomerReferenceNo.Pages;

namespace FindingCustomerReferenceNo.StepDefinitions
{
    [Binding]
    public class FindCustomerReferenceNosteps
    {
        public HomePage HomePage;
        public HelpPage HelpPage;
        public FindCustomerReferenceNoPage FindCustomerReferenceNoPage;
        public Context Context { get; }
         public FindCustomerReferenceNosteps(Context context)
        {
            Context = context;
        }
        [Given(@"user open the utilita home page")]
        public void GivenUserOpenTheUtilitaHomePage()
        {
            Context.Driver.Url = "https://utilita.co.uk//";
            HomePage = new HomePage(Context.Driver, Context.WebDriverWait);
            HomePage.AcceptCookies();
           // HomePage.WaitForPageLoad();
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
            FindCustomerReferenceNoPage = new FindCustomerReferenceNoPage(Context.Driver, Context.WebDriverWait);
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
            var postcode=table.CreateInstance<CustomerReferenceDataTable>().Postcode;
            FindCustomerReferenceNoPage.EnterPostcode(postcode);
        }

    }
}
