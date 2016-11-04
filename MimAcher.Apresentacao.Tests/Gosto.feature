Feature: Cadastrar Gosto
	Preciso fazer o casdastro do Gosto do aluno
	no banco de dados e não gerar erros de validação
	de dados.
	
@cadastrarGosto
Scenario: Adicionar um novo registro de gosto
	Given A tela contém um campo com código e descrição em brancos
	And Eu escrevo no campo descrição
	When Ao pressionar botão Salvar
	Then A tela deverá fechar e o resultado aparecerá na grid
