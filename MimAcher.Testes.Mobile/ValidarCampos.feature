Feature: Testar funcoes de validacao de campos

Scenario Outline: Campo valido
	Given eu recebi um <campo> com valor valido
	When eu chamar o validador do <campo>
	Then eu devo receber um retorno True para o <campo>
	
	Examples:
		|    campo     |
		|    'nome'    |
		| 'nascimento' |
		|   'email'    |
		|  'telefone'  |
	
Scenario Outline: Campo invalido
	Given eu recebi um <campo> com valor invalido
	When eu chamar o validador do <campo>
	Then eu devo receber um retorno False para o <campo>
	
	Examples:
		|    campo     |
		|    'nome'    |
		| 'nascimento' |
		|   'email'    |
		|  'telefone'  |
