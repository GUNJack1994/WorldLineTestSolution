Feature: HomeTests

A short summary of the feature

Scenario: Check all tabs
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	Then I check all tabs are compatible with documentation

Scenario Outline: Check all subtabs for tabs
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on '<TabName>' tab
	Then I check all subtabs for '<TabName>' are compatible with documentation
Examples: 
| TabName       |
| Configuration |
| Advanced      |
| Operations    |