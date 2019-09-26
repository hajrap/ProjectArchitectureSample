Feature: LoginRemeberMeAndCancel
	
Background: 
	#Given Navigate to ASG Website

Scenario: Remeber Me
	When enter UserID and Password
	|MemberId|Password|
	|31066416|Asg3166!|

	And I checked Remeber me checkbox
	And click Submit button
	And Click on Logout button
	And Go to Login page
	Then check UserID and Password are same

Scenario: Cancel Button
	When I click on cancel button
	Then I see home page
