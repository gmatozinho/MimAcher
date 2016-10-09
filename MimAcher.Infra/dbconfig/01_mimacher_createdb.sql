use MIMACHER
go

begin tran


CREATE TABLE MA_USUARIO (
	cod_usuario				integer not null identity(1,1),
	email 					varchar(100) not null,
	senha 					varchar(50) not null	
)

CREATE TABLE MA_NAC_CAMPUS (
	cod_nac_campus			integer not null identity(1,1),	
	nome_representante		varchar(100) not null,
	telefone				integer not null,
	geolocalizacao 			geography null
)

CREATE TABLE MA_AREA_ATUACAO (
	cod_area_atuacao		integer not null identity(1,1),
	nome 					varchar(50) not null
)

CREATE TABLE MA_NAC_AREA_ATUACAO (
	cod_nac_area_atuacao	integer not null identity(1,1),
	cod_nac_campus			integer not null,
	cod_area_atuacao		integer not null
)

CREATE TABLE MA_PARTICIPANTE (
	cod_participante		integer not null identity(1,1),
	cod_usuario				integer not null,
	cod_nac_campus			integer not null,
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


-- Criação das Primay Keys
ALTER TABLE MA_USUARIO ADD CONSTRAINT PK_MA_USUARIO_cod_us PRIMARY KEY(cod_us);
ALTER TABLE MA_IMAGEM_USUARIO ADD CONSTRAINT PK_MA_IMAGEM_USUARIO_cod_i PRIMARY KEY(cod_i);
ALTER TABLE MA_NAC_CAMPUS ADD CONSTRAINT PK_MA_NAC_CAMPUS_cod_nc PRIMARY KEY(cod_nc);
ALTER TABLE MA_ALUNO ADD CONSTRAINT PK_MA_ALUNO_al PRIMARY KEY(cod_al);
ALTER TABLE MA_GOSTO ADD CONSTRAINT PK_MA_GOSTO_cod_g PRIMARY KEY(cod_g);
ALTER TABLE MA_ALUNO_APRENDER ADD CONSTRAINT PK_MA_ALUNO_APRENDER_cod_aa PRIMARY KEY(cod_aa);	
ALTER TABLE MA_ALUNO_GOSTO ADD CONSTRAINT PK_MA_ALUNO_GOSTO_cod_aa PRIMARY KEY(cod_ag);
ALTER TABLE MA_ALUNO_ENSINAR ADD CONSTRAINT PK_MA_ALUNO_ENSINAR_cod_ae PRIMARY KEY(cod_ae);


-- Criação das Foreign Keys
ALTER TABLE MA_IMAGEM_USUARIO ADD CONSTRAINT FK_MA_IMAGEM_USUARIO_MA_USUARIO_cod_us FOREIGN KEY (cod_us) REFERENCES MA_USUARIO(cod_us);

ALTER TABLE MA_NAC_CAMPUS ADD CONSTRAINT FK_MA_NAC_CAMPUS_MA_USUARIO_cod_us FOREIGN KEY (cod_us) REFERENCES MA_USUARIO(cod_us);

ALTER TABLE MA_ALUNO ADD CONSTRAINT FK_MA_ALUNO_MA_USUARIO_cod_us FOREIGN KEY (cod_us) REFERENCES MA_USUARIO(cod_us);

ALTER TABLE MA_ALUNO_APRENDER ADD CONSTRAINT FK_MA_ALUNO_APRENDER_MA_ALUNO_cod_al FOREIGN KEY (cod_al) REFERENCES MA_ALUNO(cod_al);
ALTER TABLE MA_ALUNO_APRENDER ADD CONSTRAINT FK_MA_ALUNO_APRENDER_MA_APRENDER_cod_a FOREIGN KEY (cod_a) REFERENCES MA_APRENDER(cod_a);

ALTER TABLE MA_ALUNO_GOSTO ADD CONSTRAINT FK_MA_ALUNO_GOSTO_MA_ALUNO_cod_al FOREIGN KEY (cod_al) REFERENCES MA_ALUNO(cod_al);
ALTER TABLE MA_ALUNO_GOSTO ADD CONSTRAINT FK_MA_ALUNO_GOSTO_MA_GOSTO_cod_g FOREIGN KEY (cod_g) REFERENCES MA_GOSTO(cod_g);

ALTER TABLE MA_ALUNO_ENSINAR ADD CONSTRAINT FK_MA_ALUNO_ENSINAR_MA_ALUNO_cod_al FOREIGN KEY (cod_al) REFERENCES MA_ALUNO(cod_al);
ALTER TABLE MA_ALUNO_ENSINAR ADD CONSTRAINT FK_MA_ALUNO_ENSINAR_MA_ENSINAR_cod_e FOREIGN KEY (cod_e) REFERENCES MA_ENSINAR(cod_e);


commit;







