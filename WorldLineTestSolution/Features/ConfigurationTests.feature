Feature: ConfigurationTests

A short summary of the feature

Scenario: Create new user
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on 'Configuration' tab
	And I click on 'Users' subtab
	And I add new user
	And I fill require fields for create new user
	| UserID | UserName | EmailAddress  | ConfirmPassword |
	| TestId | TestUser | Test@test.com | Testing123#     |