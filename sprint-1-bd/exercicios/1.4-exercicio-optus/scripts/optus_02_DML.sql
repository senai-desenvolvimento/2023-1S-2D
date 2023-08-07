USE Optus;

INSERT INTO Estilos (Nome)
VALUES ('Rap'),('Hip Hop');

INSERT INTO Artistas(Nome)
VALUES ('Racionais'),('Charlie Brown Jr.');

INSERT INTO Albuns(IdEstilo,IdArtista,Titulo,DataLancamento,Localizacao,Minutos,Vizualizacao)
VALUES (1,1,'Sobrevivendo no inferno','1993-05-20','São Paulo','500',1),(2,2,'Escritorio na praia','1995-03-04','Santos','800',0);

INSERT INTO TipoDeUsuarios(Descricao)
VALUES ('Administrador'),('Comum');

INSERT INTO Usuarios(IdTipoDeUsuario,Nome,Email,Senha)
VALUES (1,'Carlos Roque','admin@admin.com.br','admin'),(1,'Bruno Roque','bruno@admin.com.br','1234'),(2,'Joel','joel@comum.com.br','12345');