Feature: LoginTests

Frist smoke test

Scenario Outline: Successful Login with Valid Credentials
	Given I am on loggin page
	When I am singing into application by <PSPID> and <Password>
	Then I check if login result is <Result> with message <LoginMessage>
Examples: 
| PSPID      | Password      | Result  | LoginMessage                                         |
| kpfront0b  | Testing123#   | success | Congratulations! Your test account is now active!    |
| WrongPspid | WrongPassword | fail    | Some of the data entered is incorrect. Please retry. |