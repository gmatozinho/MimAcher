Feature: FazerCadastro

Scenario Outline: Cadastro com dados validos
	Given eu estou na tela de cadastro
	And eu informei meu <nome>
	And eu informei meu <email>
	And eu informei minha <senha>
	And eu informei minha data de <nascimento>
	And eu informei meu <telefone>
	When eu finalizar o cadastro
	Then o cadastro deve ser feito com sucesso

	Examples:
		| nome      | email                 | senha         | nascimento   | telefone    |
		| 'Cayo'    | 'cayo@email.com'      | '12345678'    | '24/01/1994' | '999522594' |
		| 'Gustavo' | 'gustavo@ifes.edu.br' | '74563218952' | '12/01/1759' | '985632147' |

Scenario Outline: Cadastro com dados invalidos
	Given eu estou na tela de cadastro
	And eu informei meu <nome>
	And eu informei meu <email>
	And eu informei minha <senha>
	And eu informei minha data de <nascimento>
	And eu informei meu <telefone>
	When eu finalizar o cadastro
	Then o cadastro deve ser bloquado

	Examples:
		| nome   | email            | senha      | nascimento   | telefone    |
		| ''     | 'cayo@email.com' | '12345678' | '24/01/1994' | '999522594' |
		| 'Cayo' | 'cayo.email.com' | '12345678' | '24/01/1994' | '999522594' |
		| 'Cayo' | 'cayo@email.com' | '12345'    | '24/01/1994' | '999522594' |
		| 'Cayo' | 'cayo@email.com' | '12345678' | '01/13/2015' | '999522594' |
		| 'Cayo' | 'cayo@email.com' | '12345678' | '24/01/1994' | '99952a15'  |