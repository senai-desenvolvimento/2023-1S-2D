USE [Event+_v2];
GO

INSERT INTO TiposUsuarios(TituloTipoUsuario)
VALUES ('Administrador')
	  ,('Comum');

INSERT INTO Usuarios(IdTipoUsuario,NomeUsuario,Email,Senha)
VALUES (1,'Carlos','admin@admin.com','1234')
	  ,(2,'Gabriel','gabriel@gmail.com','4321')
	  ,(2,'Tiago','tiago@yahoo.com','9857');

INSERT INTO Instituicoes(Cnpj,Endereco,NomeFantasia)
VALUES ('12345678912345','Av.Niterói 180','Escola Event+');

INSERT INTO TiposEventos(TituloTipoEvento)
VALUES ('C#')
	  ,('ReactJS')
	  ,('SQL Server');

INSERT INTO Eventos(IdTipoEvento,IdInstituicao,DataEvento,NomeEvento,Descricao)
VALUES (1,1,'2021-08-09','POO','Conceitos de POO')
	  ,(2,1,'2021-02-15','ReactJS','Ciclos de Vidas React JS')
	  ,(3,1,'2021-12-25','Introdução ao SQL','Conceitos básicos do SQL Server');

INSERT INTO PresencasEvento(IdUsuario,IdEvento,Situacao)
VALUES (1,1,0)
      ,(2,2,1)
	  ,(3,3,0);


INSERT INTO ComentariosEvento(IdUsuario,IdEvento,Descricao,Exibe)
VALUES (2,1,'ótimo evento',0)
      ,(2,2,'péssimo evento',1)
	  ,(3,3,'porcaria de evento',0);
