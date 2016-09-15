delete from ma_aluno_gosto
DBCC CHECKIDENT('ma_aluno_gosto', RESEED, 0)
delete from ma_aluno_ensinar
DBCC CHECKIDENT('ma_aluno_ensinar', RESEED, 0)
delete from ma_aluno_aprender
DBCC CHECKIDENT('ma_aluno_aprender', RESEED, 0)
delete from ma_gosto
DBCC CHECKIDENT('ma_gosto', RESEED, 0)
delete from ma_ensinar
DBCC CHECKIDENT('ma_ensinar', RESEED, 0)
delete from ma_aprender
DBCC CHECKIDENT('ma_aprender', RESEED, 0)
delete from ma_imagem_usuario
DBCC CHECKIDENT('ma_imagem_usuario', RESEED, 0)
delete from ma_aluno
DBCC CHECKIDENT('ma_aluno', RESEED, 0)
delete from ma_nac_campus
DBCC CHECKIDENT('ma_nac_campus', RESEED, 0)
delete from ma_usuario
DBCC CHECKIDENT('ma_usuario', RESEED, 0)

