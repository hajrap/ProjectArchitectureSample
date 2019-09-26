Feature: ForgotPassword
	
Background:
    #Given Navigate to Login page

Scenario: ForgotPassword
	When I click on Forgot Password link
	And In the pop-up I have entered member number 30956589
	And I click on Request Password
	Then I see success message for Forgot Password


