Feature: Validar conversoes entre Participante e Bundle

Scenario: Validar conversao Participante - Bundle
	Given eu tenho os dados de um participante
	When eu converter esse participante para um bundle
	Then eu devo ter os mesmos dados no bundle
	
Scenario: Validar conversao Bundle - Participante
	Given eu tenho um bundle com os dados de um participante
	When eu converter esse bundle em um participante
	Then eu devo ter os mesmos dados no partcipante