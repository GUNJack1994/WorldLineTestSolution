Feature: AdvancedTests

Tests related to Advanced tab
Check all tabs in Advanced tab

Scenario Outline: Check all tabs in Advanced tab
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
	And I click on 'Advanced' tab
	And I click on '<SubTabName>' subtab
	Then I check every subTab if there is no error
Examples: 
| SubTabName      |
| Fraud detection |
| Subscription    |