Feature: Validate fields

Scenario: Validate field
	Given an user is making its registry
	When I try to advance to next step
	Then all registry fields should be valid