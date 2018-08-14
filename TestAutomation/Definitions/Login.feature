Feature: Login
	In order to create new post
	As a WordPress user
	I want to be able to login to the dashboard

@mytag
Scenario: Successful Login by Admin User
	Given I Navigate to the Login page
	#When I Login with Username 'admin1' and Password 'parola123A!' on the Login Page
	When I Login with valid Username and Password
	| Username | Password    |
	| admin1   | parola123A! |
#	| admin    | parola123A! |
	Then the User Name 'admin1' Should be seen on the Dashboard Page


Scenario Outline: UnSuccessful Login 
	Given I Navigate to the Login page
	When I Unsucessfully Login with Username '<username>' and Password '<password>' on the Login Page
	Then I Should See Error Message '<errorMsg>' for '<reason>'
Examples: 
 | reason           | username | password | errorMsg                    |
 | Blank Username   |          | password | This field is required.     |
 | Blank Password   | admin    |          | This field is required.     |
 | invalid Password | admin    | $%GGH    | Wrong username or password! |
 | invalid username | 66987    | password | Wrong username or password! |


