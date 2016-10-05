Feature: Validate bundle passing

Scenario: Verify Aluno
	Given I have an Aluno object
	And I pass it via bundle
	When I jump to next activity
	Then I should get an equivalent Aluno from the bundle