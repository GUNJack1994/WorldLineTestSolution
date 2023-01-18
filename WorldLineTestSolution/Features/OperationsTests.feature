Feature: OperationsTests

A short summary of the feature

Scenario Outline: Check all tabs in Operations
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on 'Operations' tab
	And I click on '<SubTabName>' subtab
	Then I check every subTab if there is no error
Examples: 
| SubTabName           |
| Financial history    |
| New transaction      |
| View transactions    |
| Electronic reporting |
| Batch Manager        |