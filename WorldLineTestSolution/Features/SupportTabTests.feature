Feature: SupportTabTests

A short summary of the feature

Scenario Outline: Check FAQ's searching
	Given I am on loggin page
	When I am singing into application by kpfront0b and Testing123#
	And I click on 'Support' tab
	And I click on 'Frequently Asked Questions (FAQs)' Support tab
	And I input text '<Text>' for search
	Then I check if search result is '<State>'
Examples:
| Text      | State     |
| Alias     | not empty |
| Not Exist | empty     |