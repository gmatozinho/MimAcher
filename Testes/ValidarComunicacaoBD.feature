Feature: Validar comunicacao com banco de dados

Scenario: Enviar um Participante para o BD
	Given eu tenho os dados de um participante
	When eu enviar os dados para o BD
	Then o banco deve armazenar os mesmos dados

Scenario Outline: Ler matchs do BD
	Given eu tenho um participante com <relacao> em um item
	When eu buscar os matchs dessa relacao no BD
	Then todo match deve ter <relacaoCompativel> no mesmo item

	Examples:
		|    relacao     |    relacaoCompativel    |
		|     gosto      |          gosto          |
		|    aprender    |         ensinar         |
		|    ensinar     |         aprender        |