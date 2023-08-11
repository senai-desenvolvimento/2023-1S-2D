--DQL Data Query Language

--consultas das tabelas

--SELECT = Seleção
-- * = todos os campos
-- FROM NomeDaTabela = da tabela 
/*
SELECT * FROM TiposDeUsuario
SELECT * FROM TiposDeEvento
SELECT * FROM Instituicao
SELECT * FROM Evento
SELECT * FROM PresencasEvento
SELECT * FROM ComentarioEvento
SELECT * from Usuario
*/
/*
-- Criar script para consulta exibindo os seguintes dados

Usar JOIN

Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Titulo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento*/


SELECT

	Usuario.Nome                                                                       AS [Nome do Usuario],
	TiposDeUsuario.TituloTipoUsuario                                                   AS [Tipo do Usuário],
	Evento.DataEvento                                                                  AS [Data do Evento],
	CONCAT(Instituicao.NomeFantasia,' ',Instituicao.Endereco)                          AS 'Local',
	TiposDeEvento.TituloTipoEvento                                                     AS [Tipo do Evento],
	Evento.Nome                                                                        AS [Nome do Evento],
	Evento.Descricao                                                                   AS [Descrição do Evento],
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmada' ELSE 'Não Confirmada' END AS[Situação],
	ComentarioEvento.Descricao                                                         AS [Comentário]

FROM Evento
	INNER JOIN TiposDeEvento	ON Evento.IdTipoDeEvento = TiposDeEvento.IdTipoDeEvento
	INNER JOIN Instituicao		ON Evento.IdInstituicao = Instituicao.IdInstituicao
	INNER JOIN PresencasEvento	ON Evento.IdEvento = PresencasEvento.IdEvento
	INNER JOIN Usuario		ON PresencasEvento.IdUsuario = Usuario.IdUsuario
	INNER JOIN TiposDeUsuario	ON TiposDeUsuario.IdTipoDeUsuario = Usuario.IdTipoDeUsuario
	LEFT JOIN ComentarioEvento	ON ComentarioEvento.IdUsuario = Usuario.IdUsuario
