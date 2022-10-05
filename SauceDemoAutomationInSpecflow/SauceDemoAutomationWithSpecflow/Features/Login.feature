Feature: Logging In

@mytag
Scenario: Login Test
	Given User searches for "https://www.saucedemo.com/"
	When I have entered <UserName> and <Password>
	Then I click Login button
	#Then I  should be on "https://www.saucedemo.com/inventory.html"

    Examples:  
    | UserName      | Password     |
    | standard_user | secret_sauce |
