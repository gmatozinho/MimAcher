use MIMACHER
go

begin tran

--Definição do Módulo Principal Ponto de Parada
CREATE TABLE MA_Ponto_Parada (
    cd_pontoparada          integer not null identity(1,1),    
	stop_code		    	varchar(20) not null,
	coordenadas	    		geography null,	
	logradouro	    		varchar(80),	
	numero_imovel   		varchar(10),
	largura_calcada   		decimal(10,2),
	dt_levantamento		    datetime not null,	
	cd_placasinalizacao     integer not null,
	cd_abrigo		    	integer not null,
	tp_fixacao	    		integer not null,
	cd_equipamento	    	integer not null,
	cd_usuario       		integer not null,	
	cd_localparada   	    integer not null,
	cd_localidade		    integer not null,	
	cd_subreferenciaponto	integer not null,	
	ds_referencia    		varchar(100),
	cd_substituicaoabrigo	integer not null,
	cd_statusponto			integer not null,		
	cd_instalacaonova       integer not null,	
	cd_instalarponto        integer not null,
	tp_ponto		        integer not null,	
	observacao	    		varchar(100),
	particularidade   		varchar(100),	
	ds_referenciainstalacao varchar(100),
	precisao				decimal(10,2)
    CONSTRAINT              PK_PP_Ponto_Parada_cd_pontoparada PRIMARY KEY(cd_pontoparada)
);

CREATE TABLE PP_Historico_Ponto (
    cd_historicoponto      integer not null identity(1,1),
    ds_historicoponto      varchar(200) not null,  	
	dt_historico   	       datetime not null,	
	stop_code_ponto        varchar(20) not null,
	cd_pontoparada		   integer not null,
	cd_usuario  		   integer not null,
    CONSTRAINT             PK_PP_Historico_Ponto_cd_historicoponto PRIMARY KEY(cd_historicoponto)
);

CREATE TABLE PP_Tipo_Ponto (
    tp_ponto		    integer not null identity(1,1),
    ds_tp_ponto         varchar(20) not null,  	
    CONSTRAINT          PK_PP_Tipo_Ponto_tp_ponto PRIMARY KEY(tp_ponto)
);

CREATE TABLE PP_Status_Ponto (
    cd_statusponto      integer not null identity(1,1),
    ds_statusponto      varchar(50) not null,  	
    CONSTRAINT          PK_PP_Status_Ponto_cd_statusponto PRIMARY KEY(cd_statusponto)
);

CREATE TABLE PP_Substituicao_Abrigo (
    cd_substituicaoabrigo     integer not null identity(1,1),
    ds_substituicaoabrigo     varchar(80) not null,  
    CONSTRAINT                PK_PP_Substituicao_Abrigo_cd_substituicaoabrigo PRIMARY KEY(cd_substituicaoabrigo)
);

CREATE TABLE PP_Abrigo (
    cd_abrigo     integer not null identity(1,1),
    ds_abrigo     varchar(50) not null,  
    CONSTRAINT    PK_PP_Abrigo_cd_abrigo PRIMARY KEY(cd_abrigo)
);

CREATE TABLE PP_Equipamento (
    cd_equipamento     integer not null identity(1,1),
    ds_equipamento     varchar(60) not null,  
    CONSTRAINT         PK_PP_Equipamento_cd_equipamento PRIMARY KEY(cd_equipamento)
);

CREATE TABLE PP_Subreferencia_Ponto (
    cd_subreferenciaponto   integer not null identity(1,1),
    ds_subreferenciaponto   varchar(80) not null,  
	cd_referenciaponto		integer not null,
    CONSTRAINT              PK_PP_Subreferencia_Ponto_cd_subreferenciaponto PRIMARY KEY(cd_subreferenciaponto)
);

CREATE TABLE PP_Referencia_Ponto (
    cd_referenciaponto   integer not null identity(1,1),
    ds_referenciaponto   varchar(80) not null,  
    CONSTRAINT           PK_PP_Referencia_Ponto_cd_referenciaponto PRIMARY KEY(cd_referenciaponto)
);

CREATE TABLE PP_Placa_Sinalizacao (
    cd_placasinalizacao   integer not null identity(1,1),
    ds_placasinalizacao   varchar(30) not null,  
    CONSTRAINT            PK_PP_Placa_Sinalizacao_cd_placasinalizacao PRIMARY KEY(cd_placasinalizacao)
);

CREATE TABLE PP_Tipo_Fixacao (
    tp_fixacao		    integer not null identity(1,1),
    ds_tp_fixacao       varchar(20) not null,  
    CONSTRAINT          PK_PP_Tipo_Fixacao_tp_fixacao PRIMARY KEY(tp_fixacao)
);

CREATE TABLE PP_Local_Parada (
    cd_localparada  integer not null identity(1,1),
    ds_localparada  varchar(50) not null,  
    CONSTRAINT      PK_PP_Local_Parada_cd_localparada PRIMARY KEY(cd_localparada)
);

CREATE TABLE PP_Instalacao_Nova (
    cd_instalacaonova integer not null identity(1,1),    
    ds_instalacaonova varchar(30) not null,
    CONSTRAINT        PK_PP_Instalacao_Nova_cd_instalacaonova PRIMARY KEY(cd_instalacaonova)
);

--Definição do Módulo de Sistemas Viários

CREATE TABLE PP_Sistema (
    cd_sistema          integer not null identity(1,1),
    ds_sistema			varchar(30) not null,
    CONSTRAINT          PK_PP_Sistema_cd_sistema PRIMARY KEY(cd_sistema)
);

CREATE TABLE PP_Sistema_PontoParada (
    cd_sistemapontoparada   integer not null identity(1,1),
    cd_sistema      		integer not null,
	cd_pontoparada    		integer not null,
    CONSTRAINT              PK_PP_Sistema_Ponto_Parada_cd_sistemapontoparada PRIMARY KEY(cd_sistemapontoparada)
);

--Definição do Módulo de Itinerário do Ponto de Parada

CREATE TABLE PP_Itinerario (
    cd_itinerario       integer not null identity(1,1),
    percurso	    	geometry null,	 	
    CONSTRAINT          PK_PP_Itinerario_cd_itinerario PRIMARY KEY(cd_itinerario)
);

CREATE TABLE PP_Itinerario_PontoParada (
    cd_itinerariopontoparada   integer not null identity(1,1),
	cd_itinerario    		   integer not null,
	cd_pontoparada   		   integer not null,	    	 	
    CONSTRAINT          	   PK_PP_Itinerario_PontoParada_cd_itinerariopontoparada PRIMARY KEY(cd_itinerariopontoparada)
);

--Definição do Módulo de Imagem

CREATE TABLE PP_Imagem_Arquivo (
    cd_imagemarquivo       integer not null identity(1,1),
    ds_imagemarquivo       varchar(40) not null,
    CONSTRAINT             PK_PP_Imagem_Arquivo_cd_imagemarquivo PRIMARY KEY(cd_imagemarquivo)
);

CREATE TABLE PP_Ponto_Parada_Imagem (
    cd_pontoparadaimagem   integer not null identity(1,1),
    cd_pontoparada  	   integer not null,	    	 	
	cd_imagemarquivo	   integer not null,	    	 	
    CONSTRAINT             PK_PP_Ponto_Parada_Imagem_cd_pontoparadaimagem PRIMARY KEY(cd_pontoparadaimagem)
);

--Definição do Módulo de Instalação de Ponto

CREATE TABLE PP_Instalar_Ponto (
    cd_instalarponto   integer not null identity(1,1),
    ds_instalarponto   varchar(5) not null,
    CONSTRAINT         PK_PP_Instalar_Ponto_cd_instalarponto PRIMARY KEY(cd_instalarponto)
);

CREATE TABLE PP_Instalacao_Ponto (
    cd_instalacaoponto   integer not null identity(1,1),
    stop_code_ponto      varchar(5) not null,  
	dt_instalacao	     datetime,	
	cd_usuario           integer not null,
	cd_pontoparada       integer not null,
	cd_statusponto       integer not null,
	cd_prioridade	     integer not null,
    CONSTRAINT           PK_PP_Instalacao_Ponto_cd_instalacaoponto PRIMARY KEY(cd_instalacaoponto)
);

CREATE TABLE PP_Prioridade (
    cd_prioridade       integer not null identity(1,1),
    ds_prioridade       varchar(80) not null,  
	cd_instalacaoponto  integer not null,
    CONSTRAINT      	PK_PP_Prioridade_cd_prioridade PRIMARY KEY(cd_prioridade)
);

-- Alteração Tabelas do Ponto de Parada

ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Placa_Sinalizacao_cd_placasinalizacao FOREIGN KEY (cd_placasinalizacao) REFERENCES PP_Placa_Sinalizacao(cd_placasinalizacao);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Abrigo_cd_abrigo FOREIGN KEY (cd_abrigo) REFERENCES PP_Abrigo(cd_abrigo);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Tipo_Fixacao_tp_fixacao FOREIGN KEY (tp_fixacao) REFERENCES PP_Tipo_Fixacao(tp_fixacao);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Equipamento_cd_equipamento FOREIGN KEY (cd_equipamento) REFERENCES PP_Equipamento(cd_equipamento);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Instalar_Ponto_cd_instalarponto FOREIGN KEY (cd_instalarponto) REFERENCES PP_Instalar_Ponto(cd_instalarponto);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Status_Ponto_cd_statusponto FOREIGN KEY (cd_statusponto) REFERENCES PP_Status_Ponto(cd_statusponto);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Local_Parada_cd_localparada FOREIGN KEY (cd_localparada) REFERENCES PP_Local_Parada(cd_localparada);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_GD_Localidade_cd_localidade FOREIGN KEY (cd_localidade) REFERENCES GD_Localidade(cd_localidade);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Subreferencia_Ponto_cd_subreferenciaponto FOREIGN KEY (cd_subreferenciaponto) REFERENCES PP_Subreferencia_Ponto(cd_subreferenciaponto);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Substituicao_Abrigo_cd_substituicaoabrigo FOREIGN KEY (cd_substituicaoabrigo) REFERENCES PP_Substituicao_Abrigo(cd_substituicaoabrigo);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Instalacao_Nova_cd_instalacaonova FOREIGN KEY (cd_instalacaonova) REFERENCES PP_Instalacao_Nova(cd_instalacaonova);
ALTER TABLE PP_Ponto_Parada ADD CONSTRAINT FK_PP_Ponto_Parada_PP_Tipo_Ponto_tp_ponto FOREIGN KEY (tp_ponto) REFERENCES PP_Tipo_Ponto(tp_ponto);

ALTER TABLE PP_Historico_Ponto ADD CONSTRAINT FK_PP_Historico_Ponto_PP_Ponto_Parada_cd_pontoparada FOREIGN KEY (cd_pontoparada) REFERENCES PP_Ponto_Parada(cd_pontoparada);

ALTER TABLE PP_Subreferencia_Ponto ADD CONSTRAINT FK_PP_Subreferencia_Ponto_PP_Referencia_Ponto_cd_referenciaponto FOREIGN KEY (cd_referenciaponto) REFERENCES PP_Referencia_Ponto(cd_referenciaponto);

ALTER TABLE PP_Sistema_PontoParada ADD CONSTRAINT FK_PP_Sistema_Ponto_Parada_PP_Sistema_cd_sistema FOREIGN KEY (cd_sistema) REFERENCES PP_Sistema(cd_sistema);
ALTER TABLE PP_Sistema_PontoParada ADD CONSTRAINT FK_PP_Sistema_Ponto_Parada_PP_Ponto_Parada_cd_pontoparada FOREIGN KEY (cd_pontoparada) REFERENCES PP_Ponto_Parada(cd_pontoparada);

ALTER TABLE PP_Itinerario_PontoParada ADD CONSTRAINT FK_PP_Itinerario_Ponto_Parada_PP_Itinerario_cd_itinerario FOREIGN KEY (cd_itinerario) REFERENCES PP_Itinerario(cd_itinerario);
ALTER TABLE PP_Itinerario_PontoParada ADD CONSTRAINT FK_PP_Itinerario_Ponto_Parada_PP_Ponto_Parada_cd_pontoparada FOREIGN KEY (cd_pontoparada) REFERENCES PP_Ponto_Parada(cd_pontoparada);

ALTER TABLE PP_Ponto_Parada_Imagem ADD CONSTRAINT FK_PP_Ponto_Parada_Imagem_PP_Ponto_Parada_cd_pontoparada FOREIGN KEY (cd_pontoparada) REFERENCES PP_Ponto_Parada(cd_pontoparada);
ALTER TABLE PP_Ponto_Parada_Imagem ADD CONSTRAINT FK_PP_Ponto_Parada_Imagem_Arquivo_PP_Imagem_Arquivo_cd_imagemarquivo FOREIGN KEY (cd_imagemarquivo) REFERENCES PP_Imagem_Arquivo(cd_imagemarquivo);

ALTER TABLE PP_Instalacao_Ponto ADD CONSTRAINT FK_PP_Instalacao_Ponto_PP_Status_Ponto_cd_statusponto FOREIGN KEY (cd_statusponto) REFERENCES PP_Status_Ponto(cd_statusponto);
ALTER TABLE PP_Instalacao_Ponto ADD CONSTRAINT FK_PP_Instalacao_Ponto_PP_Ponto_Parada_cd_pontoparada FOREIGN KEY (cd_pontoparada) REFERENCES PP_Ponto_Parada(cd_pontoparada);
ALTER TABLE PP_Instalacao_Ponto ADD CONSTRAINT FK_PP_Instalacao_Ponto_PP_Prioridade_cd_prioridade FOREIGN KEY (cd_prioridade) REFERENCES PP_Prioridade(cd_prioridade);


commit
