Feature: SupportTabTests

Tests related to Support tab
Check if searching in faq's works correctly
Check all tabs in Support tab

Scenario Outline: Check FAQ's searching
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
	And I click on 'Support' tab
	And I click on 'Frequently Asked Questions (FAQs)' Support tab
	And I input text '<Text>' for search
	Then I check if search result is '<State>'
Examples:
| Text      | State     |
| Alias     | not empty |
| Not Exist | empty     |

Scenario: Check all tabs in Support
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
	And I click on 'Support' tab
	Then I check every subTab for Support if there is no error
