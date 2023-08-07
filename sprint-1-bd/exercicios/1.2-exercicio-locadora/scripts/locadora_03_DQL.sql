USE Locadora;

--selecionando as tabelas com todos os campos

SELECT * FROM Clientes;

SELECT * FROM Empresas;

SELECT * FROM Marcas;

SELECT * FROM Modelos;

SELECT * FROM Veiculos;

SELECT * FROM alugueis;

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT Clientes.Nome AS Cliente,Modelos.NomeModelo AS Modelo,alugueis.DataRetirada AS [Início],alugueis.DataEntrega AS Fim FROM Clientes
INNER JOIN alugueis
ON Clientes.IdCliente = alugueis.IdCliente
INNER JOIN Veiculos
ON Veiculos.IdVeiculo = alugueis.IdVeiculo
INNER JOIN Modelos 
ON Veiculos.IdModelo = Modelos.IdModelo;

-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro
SELECT Clientes.Nome AS Cliente,Modelos.NomeModelo AS Modelo,alugueis.DataRetirada AS [Início],alugueis.DataEntrega AS Fim FROM Clientes
INNER JOIN alugueis
ON Clientes.IdCliente = alugueis.IdCliente
INNER JOIN Veiculos
ON Veiculos.IdVeiculo = alugueis.IdVeiculo
INNER JOIN Modelos 
ON Veiculos.IdModelo = Modelos.IdModelo
WHERE Clientes.IdCliente = 1;






