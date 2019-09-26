Feature: Login
Check if Member is able to login by memberid


	Scenario: Login
	Given Navigate to  Website
	When I enter userID as 31034468
	And I enter password as Asg3166!
	And I click Submit
	Then I see MyAsg page