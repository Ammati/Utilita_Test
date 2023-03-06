Feature: FindCustomerReferenceNumber

Scenario: 1.Verify the validation message is displayed when the user does not enter Email and postcode in Find your Customer Reference Number
	Given user open the utilita home page
	When user click  on Help
	Then utilita help page is displayed
	When user click on YourCustomerReferenceNumber
	Then YourCustomerReferenceNumber page is dispalyed
	When user clicks on Find button
	Then error message 'Please provide your email/phone number and postcode' is displayed

Scenario: 2. Verify the validation message is displayed when the user does not enter postcode in Find your Customer Reference Number
	Given user open the utilita home page
	When user click  on Help
	Then utilita help page is displayed
	When user click on YourCustomerReferenceNumber
	Then YourCustomerReferenceNumber page is dispalyed
	And user enter the email as follows
		| Email             |
		| email@example.com |
	When user clicks on Find button
	Then error message 'Please provide your postcode.' is displayed

Scenario: 3.Verify the validation message is displayed when the user enter incorrect Email and postcode in Find your Customer Reference Number
	Given user open the utilita home page
	When user click  on Help
	Then utilita help page is displayed
	When user click on YourCustomerReferenceNumber
	Then YourCustomerReferenceNumber page is dispalyed
	And user enter the email and postcode as follows
		| Email             | Postcode |
		| email@example.com | SO533QB  |
	When user clicks on Find button
	Then error message 'There has been a problem locating your customer reference number.' is displayed