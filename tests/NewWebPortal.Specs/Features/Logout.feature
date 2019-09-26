Feature: Logout
		User can login and also other scenario is to check log out.

Background:
	Given Navigate to ASG Website
	When I enter UserID and Password and click Submit
	Then I see welcome to MyAsg page

Scenario: Login to website

Scenario: Logout
	When I click on Logout
	Then I see Home page

