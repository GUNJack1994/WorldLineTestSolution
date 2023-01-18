Feature: AdvancedTests

A short summary of the feature

Scenario Outline: Check all tabs in Advanced
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on 'Advanced' tab
	And I click on '<SubTabName>' subtab
	Then I check every subTab if there is no error
Examples: 
| SubTabName      |
| Fraud detection |
| Subscription    |
