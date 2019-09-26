Feature: ForgotUsername
	
Background: 
	Given Open Login page
	When I click on Forgot your username link
	And In the pop-up I have entered email success
		| EmailID                  |
		| ankit.modi@tatvasoft.com |
		| 1ankit.modi@tatvasoft.com |

	And I click on Request Username

#Success (Email exist)
Scenario: ForgotUsername
	Then I see success message

#Fail (Email not exist)
Scenario: FailToFindEmailId
	Then I see wrong email-Id message

#Note: Pass Success as string to test success scenarion and Fail to test failure scenario