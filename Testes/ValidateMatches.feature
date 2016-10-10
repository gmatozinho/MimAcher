Feature: Validate matches

Scenario: Find users with same gosto
		Given 'Cayo' is an Aluno
		And 'Cayo' has a gosto 'futebol'
		And 'Gustavo' is an Aluno
		And 'Gustavo' has a gosto 'futebol'
		When I go to gostos page
		Then I should match with 'Gustavo'

Scenario: Find compatible teacher
		Given 'Cayo' is an Aluno
		And 'Cayo' has a learning interest 'csharp'
		And 'Gustavo' is an Aluno
		And 'Gustavo' has a teaching interest 'csharp'
		When I go to learn page
		Then I should match with 'Gustavo'

Scenario: Find compatible learner
		Given 'Cayo' is an Aluno
		And 'Cayo' has a teaching interest 'potato mashing'
		And 'Paulo' is an Aluno
		And 'Paulo' has a learning interest 'potato mashing'
		When I go to teach page
		Then I should match with 'Paulo'