USE Locadora;

--inserindo dados nas tabela do bd 

INSERT INTO Clientes (Nome,Cpf)
VALUES ('Gabriel','55645678932'),('Patrick', '58765432112');

INSERT INTO Empresas (RazaoSocial,Site)
VALUES ('Carlos Alugueis', 'carlosalugueis@gmail.com'),('Localiza Veiculos', 'localiza@email.com');

INSERT INTO	Marcas (NomeMarca)
VALUES ('Chevrolet'),('Toyota');

INSERT INTO Modelos (NomeModelo)
VALUES ('Blazer'),('Corolla');

INSERT INTO Veiculos (IdEmpresa,IdModelo,IdMarca,Placa)
VALUES (1,2,1,'FNE5378'),(2,1,2,'DTP5349');

INSERT INTO alugueis (IdCliente,IdVeiculo,DataRetirada,DataEntrega)
VALUES (1,2,'1993-01-24','1993-07-24'),(1,2,'1993-08-24','1993-03-24');

--alterando um cliente
UPDATE Clientes
SET Nome = 'Joao'
WHERE IdCliente = 9;

--deletando um cliente
DELETE FROM alugueis
WHERE IdAluguel = 1;

--deletando a tabela inteira
DELETE FROM alugueis;

DELETE FROM Clientes;

