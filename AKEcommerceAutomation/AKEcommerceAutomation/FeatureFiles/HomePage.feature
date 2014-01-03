Feature: HomePage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


#Scenario: Add two numbers
#	Given I have entered 50 into the calculator
#	And I have entered 70 into the calculator
#	When I press add
#	Then the result should be 120 on the screen
Scenario: HomePage
 Given I navigate to the homepage
 Then PageSource Contains 'logo-big'

 Scenario: the main navigation in Homepage
 Given I navigate to the Homepage
 Then there is a main navigation

 Scenario: Right-hand bar 
 Given I navigate to the Homepage
 Then Right hand side bar is displayed

 Scenario: Destinations Pop-up 
 Given I navigate to the Homepage
 When I click on the Destinations Link
 Then Destinations Pop-up should display