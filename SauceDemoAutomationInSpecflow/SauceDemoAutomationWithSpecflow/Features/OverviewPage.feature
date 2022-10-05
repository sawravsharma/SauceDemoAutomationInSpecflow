Feature: OverviewPage

A short summary of the feature

Background: 
	Given User has done checkout 

@tag1
Scenario: [scenario name]
	Given User is on the checkout overview page
	When User clicks on the finish button
	Then User gets redirects to "https://www.saucedemo.com/checkout-complete.html"
