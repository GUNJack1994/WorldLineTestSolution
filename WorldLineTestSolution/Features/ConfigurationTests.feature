Feature: ConfigurationTests

Tests related to Configuration tab
Happy flow related to add new user and disable new user
Check all tabs in Configuration tab

Scenario: Create new user
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
	And I click on 'Configuration' tab
	And I click on 'Users' subtab
	And I add new user
	And I fill require fields for create new user
	| UserID | UserName | EmailAddress  | ConfirmPassword |
	| TestId | TestUser | Test@test.com | Testing123#     |
	Then I check if 'TestId' user was created

Scenario: Deactivate user
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
	And I click on 'Configuration' tab
	And I click on 'Users' subtab
	And I deactivate 'TestId' user
	Then I check if deactivate message for 'TestId' was shown

Scenario Outline: Check all tabs in Configuration tab
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
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