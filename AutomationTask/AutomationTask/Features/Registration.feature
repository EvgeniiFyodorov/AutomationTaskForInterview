Feature: Registration

Scenario: CompleteRegistration
	Given Web page 'https://www.oddsking.com' is opened
	When Button Join is pressed
	  And Following Account info is entered:
	  | Email              | Username           | Password     |
	  | TestEmail@test.com | TestUsername121212 | TestPass1234 |
	  And Following Personal info is entered:
	  | FirstName | LastName   | DateOfBirth |
	  | TestUser  | TestBlaBla | 01.01.2000  |
	  And Following Contact info is entered:
	  | TelephoneNo | SecurityQuestionAnswer |
	  | 12345678901 | TestAnswer             |
	  And Post code '12345' is entered
	  And All No Marketing checkboxes are checked
	  And Button Register is pressed
	Then Personal info verification page is shown