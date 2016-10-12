use MIMACHER
go

begin tran


CREATE TABLE MA_USUARIO (
	cod_usuario				integer not null identity(1,1),
	email 					varchar(100) not null,
	senha 					varchar(50) not null	
)

CREATE TABLE MA_NAC (
	cod_nac					integer not null identity(1,1),	
	cod_usuario				integer not null,
	cod_campus				integer not null,
	nome_representante		varchar(100) not null,
	telefone				integer not null
)

CREATE TABLE MA_CAMPUS (
	cod_campus				integer not null identity(1,1),	
	local					varchar(100) not null
)

CREATE TABLE MA_AREA_ATUACAO (
	cod_area_atuacao		integer not null identity(1,1),
	nome 					varchar(50) not null
)

CREATE TABLE MA_NAC_AREA_ATUACAO (
	cod_nac_area_atuacao	integer not null identity(1,1),
	cod_nac					integer not null,
	cod_area_atuacao		integer not null
)

CREATE TABLE MA_PARTICIPANTE (
	cod_participante		integer not null identity(1,1),
	cod_usuario				integer not null,
	cod_campus				integer not null,
	nome 					varchar(50) not null,	
	telefone 				integer not null,
	dt_nascimento 			datetime not null,	
	geolocalizacao 			geography null
)

CREATE TABLE MA_IMAGEM_PARTICIPANTE (
	cod_imagem				integer not null identity(1,1),
	cod_participante		integer not null,
	imagem 					varbinary not null
)

CREATE TABLE MA_PARTICIPANTE_HOBBIE (
	cod_p_hobbie			integer not null identity(1,1),
	cod_item				integer not null,
	cod_participante		integer not null
)

CREATE TABLE MA_PARTICIPANTE_APRENDER (
	cod_p_aprender			integer not null identity(1,1),
	cod_item				integer not null,
	cod_participante		integer not null
)

CREATE TABLE MA_PARTICIPANTE_ENSINAR (
	cod_p_ensinar			integer not null identity(1,1),
	cod_item				integer not null,
	cod_participante		integer not null
)

CREATE TABLE MA_ITEM (
	cod_item 				integer not null identity(1,1),
	nome 					VARCHAR(50)
)

-- Criação das Primay Key
ALTER TABLE MA_USUARIO ADD CONSTRAINT PK_MA_USUARIO_cod_usuario PRIMARY KEY(cod_usuario);
ALTER TABLE MA_IMAGEM_PARTICIPANTE ADD CONSTRAINT PK_MA_IMAGEM_PARTICIPANTE_cod_imagem PRIMARY KEY(cod_imagem);
ALTER TABLE MA_NAC ADD CONSTRAINT PK_MA_NAC_cod_nac PRIMARY KEY(cod_nac);
ALTER TABLE MA_CAMPUS ADD CONSTRAINT PK_MA_CAMPUS_cod_campus PRIMARY KEY(cod_campus);
ALTER TABLE MA_NAC_AREA_ATUACAO ADD CONSTRAINT PK_MA_NAC_AREA_ATUACAO_cod_nac_area_atuacao PRIMARY KEY(cod_nac_area_atuacao);
ALTER TABLE MA_AREA_ATUACAO ADD CONSTRAINT PK_MA_AREA_ATUACAO_cod_area_atuacao PRIMARY KEY(cod_area_atuacao);
ALTER TABLE MA_PARTICIPANTE ADD CONSTRAINT PK_MA_PARTICIPANTE_cod_participante PRIMARY KEY(cod_participante);
ALTER TABLE MA_ITEM ADD CONSTRAINT PK_MA_ITEM_cod_item PRIMARY KEY(cod_item);
ALTER TABLE MA_PARTICIPANTE_APRENDER ADD CONSTRAINT PK_MA_PARTICIPANTE_APRENDER_cod_p_aprender PRIMARY KEY(cod_p_aprender);	
ALTER TABLE MA_PARTICIPANTE_ENSINAR ADD CONSTRAINT PK_MA_PARTICIPANTE_ENSINAR_cod_p_ensinar PRIMARY KEY(cod_p_ensinar);	
ALTER TABLE MA_PARTICIPANTE_HOBBIE ADD CONSTRAINT PK_MA_PARTICIPANTE_HOBBIE_cod_p_hobbie PRIMARY KEY(cod_p_hobbie);	


-- Criação das Foreign Keys
ALTER TABLE MA_IMAGEM_PARTICIPANTE ADD CONSTRAINT FK_MA_IMAGEM_PARTICIPANTE_MA_PARTICIPANTE_cod_participante FOREIGN KEY (cod_participante) REFERENCES MA_PARTICIPANTE(cod_participante);

ALTER TABLE MA_PARTICIPANTE ADD CONSTRAINT FK_MA_PARTICIPANTE_MA_USUARIO_cod_usuario FOREIGN KEY (cod_usuario) REFERENCES MA_USUARIO(cod_usuario);
ALTER TABLE MA_PARTICIPANTE ADD CONSTRAINT FK_MA_PARTICIPANTE_MA_CAMPUS_cod_campus FOREIGN KEY (cod_campus) REFERENCES MA_CAMPUS(cod_campus);

ALTER TABLE MA_NAC ADD CONSTRAINT FK_MA_NAC_MA_USUARIO_cod_usuario FOREIGN KEY (cod_usuario) REFERENCES MA_USUARIO(cod_usuario);
ALTER TABLE MA_NAC ADD CONSTRAINT FK_MA_NAC_MA_CAMPUS_cod_campus FOREIGN KEY (cod_campus) REFERENCES MA_CAMPUS(cod_campus);

ALTER TABLE MA_NAC_AREA_ATUACAO ADD CONSTRAINT FK_MA_NAC_AREA_ATUACAO_MA_NAC_cod_nac FOREIGN KEY (cod_nac) REFERENCES MA_NAC(cod_nac);
ALTER TABLE MA_NAC_AREA_ATUACAO ADD CONSTRAINT FK_MA_NAC_AREA_ATUACAO_MA_AREA_ATUACAO_cod_area_atuacao FOREIGN KEY (cod_area_atuacao) REFERENCES MA_AREA_ATUACAO(cod_area_atuacao);

ALTER TABLE MA_PARTICIPANTE_APRENDER ADD CONSTRAINT FK_MA_PARTICIPANTE_APRENDER_MA_PARTIPANTE_cod_participante FOREIGN KEY (cod_participante) REFERENCES MA_PARTICIPANTE(cod_participante);
ALTER TABLE MA_PARTICIPANTE_APRENDER ADD CONSTRAINT FK_MA_PARTICIPANTE_APRENDER_MA_ITEM_cod_item FOREIGN KEY (cod_item) REFERENCES MA_ITEM(cod_item);

ALTER TABLE MA_PARTICIPANTE_ENSINAR ADD CONSTRAINT FK_MA_PARTICIPANTE_ENSINAR_MA_PARTIPANTE_cod_participante FOREIGN KEY (cod_participante) REFERENCES MA_PARTICIPANTE(cod_participante);
ALTER TABLE MA_PARTICIPANTE_ENSINAR ADD CONSTRAINT FK_MA_PARTICIPANTE_ENSINAR_MA_ITEM_cod_item FOREIGN KEY (cod_item) REFERENCES MA_ITEM(cod_item);

ALTER TABLE MA_PARTICIPANTE_HOBBIE ADD CONSTRAINT FK_MA_PARTICIPANTE_HOBBIE_MA_PARTIPANTE_cod_participante FOREIGN KEY (cod_participante) REFERENCES MA_PARTICIPANTE(cod_participante);
ALTER TABLE MA_PARTICIPANTE_HOBBIE ADD CONSTRAINT FK_MA_PARTICIPANTE_HOBBIE_MA_ITEM_cod_item FOREIGN KEY (cod_item) REFERENCES MA_ITEM(cod_item);



commit;







