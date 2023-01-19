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
	Then I check if 'TestId' user was created

Scenario: Deactivate user
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on 'Configuration' tab
	And I click on 'Users' subtab
	And I deactivate 'TestId' user
	Then I check if deactivate message for 'TestId' was shown

Scenario Outline: Check all tabs in Configuration
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on 'Configuration' tab
	And I click on '<SubTabName>' subtab
	Then I check every subTab if there is no error
Examples:
| SubTabName                |
| Password                  |
| Account                   |
| Payment methods           |
| Users                     |
| Alias                     |
| Technical information     |
| Template                  |
| Create production account |
| Error logs                |