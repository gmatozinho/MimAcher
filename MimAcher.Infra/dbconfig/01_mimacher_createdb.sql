use MIMACHER
go

begin tran


CREATE TABLE USUARIO (
	login 				varchar(50) not null,
	senha 				varchar(50) not null,
	identificador 		integer not null
	CONSTRAINT 			PK_USUARIO_login PRIMARY KEY(login)
)

CREATE TABLE IMAGEM_USUARIO (
	cod_i 				integer not null identity(1,1),
	imagem 				varbinary not null,
	login 				varchar(50) not null,
	CONSTRAINT 			PK_IMAGEM_USUARIO_cod_i PRIMARY KEY(cod_i)
)

CREATE TABLE NAC_CAMPUS (
	login 				varchar(50) not null,
	nome_representante  varchar(50) not null,
	geolocalizacao 		geography null,
	CONSTRAINT 			PK_NAC_CAMPUS_login PRIMARY KEY(login)
)

CREATE TABLE ALUNO (
	login 				varchar(50) not null,
	nome 				varchar(50) not null,
	dt_nascimento 		datetime not null,
	telefone 			integer not null,
	e_mail 				varchar(50) not null,
	geolocalizacao 		geography null,
	CONSTRAINT 			PK_ALUNO_login PRIMARY KEY(login)
)

CREATE TABLE GOSTO (
	cod_g 				integer not null identity(1,1),
	nome 				varchar(30) not null,
	CONSTRAINT 			PK_GOSTO_cod_g PRIMARY KEY(cod_g)
)

CREATE TABLE ENSINAR (
	cod_e 				INTEGER PRIMARY KEY,
	nome 				VARCHAR(30)
)

CREATE TABLE APRENDER (
	cod_a 				integer not null identity(1,1),
	nome 				varchar(30) not null,
	CONSTRAINT 			PK_APRENDER_cod_a PRIMARY KEY(cod_a)
)

CREATE TABLE ALUNO_APRENDER (
	cod_aa			 	integer not null identity(1,1),
	login 				varchar(50) not null,
	cod_a 				integer not null,
	CONSTRAINT 			PK_ALUNO_APRENDER_cod_aa PRIMARY KEY(cod_aa)	
)

CREATE TABLE ALUNO_GOSTO (
	cod_ag 				integer not null identity(1,1),
	login 				varchar(50) not null,
	cod_g 				integer not null,
	CONSTRAINT 			PK_ALUNO_GOSTO_cod_aa PRIMARY KEY(cod_ag)		
)

CREATE TABLE ALUNO_ENSINAR (
	cod_ae			 	integer not null identity(1,1),
	login 				varchar(50) not null,
	cod_e 				integer not null,
	CONSTRAINT 			PK_ALUNO_ENSINAR_cod_ae PRIMARY KEY(cod_ae)			
)

ALTER TABLE IMAGEM_USUARIO ADD CONSTRAINT FK_IMAGEM_USUARIO__USUARIO_login FOREIGN KEY (login) REFERENCES USUARIO(login);

ALTER TABLE NAC_CAMPUS ADD CONSTRAINT FK_NAC_CAMPUS__USUARIO_login FOREIGN KEY (login) REFERENCES USUARIO(login);

ALTER TABLE ALUNO ADD CONSTRAINT FK_ALUNO__USUARIO_login FOREIGN KEY (login) REFERENCES USUARIO(login);

ALTER TABLE ALUNO_APRENDER ADD CONSTRAINT FK_ALUNO_APRENDER__ALUNO_login FOREIGN KEY (login) REFERENCES ALUNO(login);
ALTER TABLE ALUNO_APRENDER ADD CONSTRAINT FK_ALUNO_APRENDER__APRENDER_cod_a FOREIGN KEY (cod_a) REFERENCES APRENDER(cod_a);

ALTER TABLE ALUNO_GOSTO ADD CONSTRAINT FK_ALUNO_GOSTO__ALUNO_login FOREIGN KEY (login) REFERENCES ALUNO(login);
ALTER TABLE ALUNO_GOSTO ADD CONSTRAINT FK_ALUNO_GOSTO__GOSTO_cod_g FOREIGN KEY (cod_g) REFERENCES GOSTO(cod_g);

ALTER TABLE ALUNO_ENSINAR ADD CONSTRAINT FK_ALUNO_ENSINAR__ALUNO_login FOREIGN KEY (login) REFERENCES ALUNO(login);
ALTER TABLE ALUNO_ENSINAR ADD CONSTRAINT FK_ALUNO_ENSINAR__ENSINAR_cod_e FOREIGN KEY (cod_e) REFERENCES ENSINAR(cod_e);


commit;







