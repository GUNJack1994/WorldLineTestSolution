Feature: OperationsTests

Tests related to Operations tab
Check all tabs in Operations tab

Scenario Outline: Check all tabs in Operations tab
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
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