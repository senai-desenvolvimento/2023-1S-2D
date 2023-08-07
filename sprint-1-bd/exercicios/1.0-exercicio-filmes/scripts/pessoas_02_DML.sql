USE Pessoas;

--inserido dados nas tabelas

INSERT INTO Pessoas(Nome,Cnh)
VALUES ('Tiago Brandao','36985214785'),('Paulo Tsukamoto','74185296336');

INSERT INTO Emails(EnderecoEmail,IdPessoas)
VALUES ('tiago@gmail.com',3),('paulo@gmail.com',4);

INSERT INTO Telefones(Numero,IdPessoas)
VALUES ('947589632',3),('966351236',4);