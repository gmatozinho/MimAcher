Feature: FazerLogin
	
Scenario Outline: Login com informacoes validas
	Given eu sou um usuario na tela de login
	And eu informar meu <email>
	And eu informar minha <senha>
	When eu tentar fazer o login
	Then eu devo ir para a tela home

	Examples:
		| email                    | senha |
		| 'cayopdonatti@gmail.com' | '123' |

Scenario Outline: Login com informacoes invalidas
	Given eu sou um usuario na tela de login
	And eu informar meu <email>
	And eu informar minha <senha>
	When eu tentar fazer o login
	Then eu devo receber uma mensagem de erro

	Examples:
		| email                        | senha |
		| 'cayopdonatti@gmail.com'     | '321' |
		| 'emailinexistente@gmail.com' | '321' |