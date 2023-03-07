Feature: SearchCRN

This feature to assert the search functionality of CRN

@SearchCRN
Scenario: 1. Verify the validation message is displayed when the user does not enter Email and postcode in Find your Customer Reference Number
	Given user open the utilita home page
	When user click  on Help
	Then utilita help page is displayed
	When user click on YourCustomerReferenceNumber
	Then YourCustomerReferenceNumber page is dispalyed
	When user clicks on Find button
	Then error message 'Please provide your email/phone number and postcode' is displayed