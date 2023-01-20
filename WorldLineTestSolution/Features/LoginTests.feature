Feature: LoginTests

Tests relatet to Login page
Check if loggin in is correctly
Check if logout is correctly


Scenario Outline: Successful login and fail login
	Given I am on loggin page
	When I am logging in application by '<PSPID>' and '<Password>'
	Then I check if login result is <Result> with message <LoginMessage>
Examples: 
| PSPID      | Password      | Result  | LoginMessage                                         |
| kpfront0b  | Testing123#   | success | Congratulations! Your test account is now active!    |
| WrongPspid | WrongPassword | fail    | Some of the data entered is incorrect. Please retry. |

Scenario: Check logout function
	Given I am on loggin page
	When I am logging in application by 'kpfront0b' and 'Testing123#'
	And I click on logout button
	Then I check if login screen is visible