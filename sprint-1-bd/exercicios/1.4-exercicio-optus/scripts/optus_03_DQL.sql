USE Optus;

SELECT * FROM Artistas;

SELECT * FROM Estilos;

SELECT * FROM Albuns;

SELECT * FROM TipoDeUsuarios;

SELECT * FROM Usuarios;

--DQL
-- listar todos os usuários administradores, sem exibir suas senhas
SELECT TipoDeUsuarios.Descricao,Usuarios.Nome,Usuarios.Email
FROM Usuarios,TipoDeUsuarios
WHERE TipoDeUsuarios.IdTipoDeUsuario = Usuarios.IdTipoDeUsuario AND TipoDeUsuarios.IdTipoDeUsuario = 1;

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT Artistas.Nome AS Artista,Albuns.Titulo,Estilos.Nome AS Estilo,Albuns.DataLancamento,Albuns.Localizacao,Albuns.Minutos,Albuns.Vizualizacao FROM Albuns
INNER JOIN Estilos
ON Albuns.IdEstilo = Estilos.IdEstilo
INNER JOIN Artistas
ON Albuns.IdArtista = Artistas.IdArtista
WHERE Albuns.DataLancamento > '1993-06-20';

-- listar os dados de um usuário através do e-mail e senha
SELECT TipoDeUsuarios.Descricao,Usuarios.Nome,Usuarios.Email,Usuarios.Senha
FROM Usuarios,TipoDeUsuarios
WHERE Usuarios.Email = 'bruno@admin.com.br' AND Usuarios.Senha = '1234' AND TipoDeUsuarios.IdTipoDeUsuario = Usuarios.IdTipoDeUsuario;

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum
SELECT Artistas.Nome AS Artista,Albuns.Titulo,Estilos.Nome AS Estilo FROM Albuns
INNER JOIN Estilos
ON Albuns.IdEstilo = Estilos.IdEstilo
INNER JOIN Artistas
ON Albuns.IdArtista = Artistas.IdArtista;
