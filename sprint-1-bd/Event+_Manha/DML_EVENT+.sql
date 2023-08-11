--DML Data Manipulation Language

USE [Event+_Manha]

--inserir dados nas tabelas

INSERT INTO TiposDeUsuario (TituloTipoUsuario)
VALUES ('Administrador'),('Comum')

--EXEMPLO DE FORMA SIMPLIFICADA, OBRIGADO PREENCHER TODOS OS CAMPOS NA ORDEM
--INSERT INTO TiposDeUsuario VALUES ('Administrador'),('Comum')

INSERT INTO TiposDeEvento (TituloTipoEvento)
VALUES ('SQL Server')

INSERT INTO Instituicao(CNPJ,Endereco,NomeFantasia)
VALUES ('12345678901234','Rua Niterói 180','DevSchool')

INSERT INTO Usuario(IdTipoDeUsuario,Nome,Email,Senha)
VALUES (1,'Carlos','admin@admin.com','admin1234')

INSERT INTO Evento(IdTipoDeEvento,IdInstituicao,Nome,Descricao,DataEvento,HorarioEvento)
VALUES (1,1,'Introdução ao Banco de Dados SQL Server','Aprenda conceitos básicos do SQL Server','2023-08-10','10:00:00')

INSERT INTO PresencasEvento(IdUsuario,IdEvento)
VALUES (1,1)

INSERT INTO ComentarioEvento(IdUsuario,IdEvento,Descricao,Exibe)
VALUES (1,1,'Excelente evento, professores top!',1)




