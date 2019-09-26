Feature: ViewLog
	#In this you can check the error logs are showing properly or not

Background: 
	Given I have open View log page
	
Scenario: ViewLatest Log
	Then I see latest error log detail table

Scenario: View log between specific dates
	And I have set start date as "05/13/2019"
	And I have set end date as "05/29/2019"
	And I click on search button
	Then I see search result

Scenario: View log of specific level
	And I have set level as "Error"
	And I click on search button
	Then I see search result
	
Scenario: View log of specific userId
	And I have set user id as "123"
	And I click on search button
	Then I see search result

Scenario: View log of specific userId between two date and of specific level
	And I have set start date as "05/13/2019"
	And I have set end date as "05/29/2019"
	And I have set level as "Error"
	And I have set user id as "123"
	And I click on search button
	Then I see search result