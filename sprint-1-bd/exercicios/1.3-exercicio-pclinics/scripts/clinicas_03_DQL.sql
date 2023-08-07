USE Clinicas;

--consulta de todos os campos das tabelas do bd
SELECT * FROM Pets;

SELECT * FROM Donos;

SELECT * FROM Racas;

SELECT * FROM Tipos;

SELECT * FROM Clinicas;

SELECT * FROM Veterinarios;

SELECT * FROM Atendimentos;

--DQL

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT Veterinarios.Nome,Veterinarios.CRMV,Clinicas.Nome AS [Razão Social] FROM Veterinarios
INNER JOIN Clinicas
ON Veterinarios.IdClinica = Clinicas.IdClinica
WHERE Clinicas.IdClinica = 1;

-- listar todas as raças que começam com a letra S
SELECT Racas.NomeRaca FROM Racas
WHERE NomeRaca LIKE 'S%'

-- listar todos os tipos de pet que terminam com a letra O
SELECT Tipos.TipoPEt FROM Tipos
WHERE TipoPEt LIKE'%O'

-- listar todos os pets mostrando os nomes dos seus donos
SELECT Donos.Nome AS NomeDono,Pets.Nome AS NomePet,Racas.NomeRaca,Pets.Telefone FROM Donos
INNER JOIN Pets
ON Donos.IdDono = Pets.IdDono
INNER JOIN Racas
ON Racas.IdRaca = Pets.IdRaca;

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido
SELECT Atendimentos.Servico AS [Serviço],Veterinarios.Nome AS [Veterinário],Pets.Nome AS NomePet,Racas.NomeRaca,Tipos.TipoPEt AS Tipo,Donos.Nome AS NomeDono,Clinicas.Nome AS [Clínica] FROM Atendimentos
INNER JOIN Pets
ON Pets.IdPet = Atendimentos.IdPet
INNER JOIN Racas
ON Racas.IdRaca = Pets.IdRaca
INNER JOIN Veterinarios
ON Veterinarios.IdVeterinario = Atendimentos.IdVeterinario
INNER JOIN Tipos
ON Tipos.IdTipo = Racas.IdTipo
INNER JOIN Donos
ON Donos.IdDono = Pets.IdDono
INNER JOIN Clinicas
ON Clinicas.IdClinica = Veterinarios.IdClinica;