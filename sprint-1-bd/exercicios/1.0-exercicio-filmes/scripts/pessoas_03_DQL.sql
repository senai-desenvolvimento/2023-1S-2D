USE Pessoas;

SELECT * FROM Pessoas;

SELECT * FROM Emails;

SELECT * FROM Telefones;


--Ordenar tabela "pessoas" em ordem decrescente a partir do campo "nome"
SELECT * FROM Pessoas ORDER BY Nome DESC

--DQL - listar as pessoas em ordem alfabética reversa, mostrando seus telefones, seus e-mails e suas CNHs

--script sem join
SELECT Pessoas.Nome,Telefones.Numero,Emails.EnderecoEmail,Pessoas.Cnh
FROM Pessoas,Emails,Telefones
WHERE Pessoas.idPessoas = Emails.IdPessoas AND Pessoas.idPessoas = Telefones.IdPessoas ORDER BY Nome DESC;

--script de outra maneira (join)
SELECT Pessoas.Nome,Telefones.Numero,Emails.EnderecoEmail,Pessoas.Cnh
FROM Pessoas
INNER JOIN Telefones
ON Pessoas.idPessoas = Telefones.IdPessoas
INNER JOIN Emails
ON Pessoas.idPessoas = Emails.IdPessoas
ORDER BY Nome DESC;
