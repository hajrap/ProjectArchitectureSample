
Feature: LoginFail
	To check the login fail

Background:
	Given Navigate to Login page
	When I enter UserID and Password
	|MemberId|Password|
	|30934529|Asg3166|
	And click on Submit

Scenario: LoginFail
	Then I see error message

Scenario: ForgotPaasword3AttemptErrorMessage
	Then Check the error message
	|MemberId|Password|
	|30934529|Asg3166|