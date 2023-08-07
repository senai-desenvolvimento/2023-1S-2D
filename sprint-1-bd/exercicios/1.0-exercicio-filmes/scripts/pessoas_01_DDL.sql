CREATE DATABASE Pessoas;

USE Pessoas;

--criado tabelas

CREATE TABLE Pessoas
(
	idPessoas	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR(200) NOT NULL 
	,Cnh		CHAR(11) NOT NULL	--Char = número fixo caracteres	
);

CREATE TABLE Emails
(
	IdEmails	INT PRIMARY KEY IDENTITY
	,IdPessoas	INT FOREIGN KEY REFERENCES Pessoas (IdPessoas)
	,EnderecoEmail VARCHAR(100) NOT NULL
);

CREATE TABLE Telefones
(
	IdTelefone INT PRIMARY KEY IDENTITY
	,Numero	VARCHAR(11) NOT NULL
	,IdPessoas	INT FOREIGN KEY REFERENCES Pessoas (IdPessoas)
);