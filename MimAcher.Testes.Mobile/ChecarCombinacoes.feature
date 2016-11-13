Feature: ChecarCombinacoes

Scenario Outline: Checar combinacoes
	Given eu sou um usuario na tela home
	And eu tenho uma <relacao1> com um <item>
	When eu checar os meus matchs neste item
	Then todos os matchs deve ter uma <relacao2> com o <item> compativel com a minha

	Examples:
		| item      | relacao1   | relacao2   |
		| 'futebol' | 'hobbie'   | 'hobbie'   |
		| 'violao'  | 'aprender' | 'ensinar'  |
		| 'violao'  | 'ensinar'  | 'aprender' |
