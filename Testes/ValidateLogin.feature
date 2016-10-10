Feature: Validate login

Scenario: Valid anonymous login
	Given an anonymous user
	When it enters valid login information
	Then it should go to the main menu

Scenario: Invalid anonymous login
	Given an anonymous user
	When it enters invalid login information
	Then an error should pop-up