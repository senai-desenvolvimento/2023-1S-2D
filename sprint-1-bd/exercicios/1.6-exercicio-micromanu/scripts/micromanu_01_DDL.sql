CREATE DATABASE Micromanu;

USE Micromanu;

CREATE TABLE Clientes
(
	IdCliente	INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(50)NOT NULL
);

CREATE TABLE Colaboradores
(
	IdColaborador	INT PRIMARY KEY IDENTITY
	,Nome	VARCHAR(50)NOT NULL
	,Salario	SMALLMONEY NOT NULL		
);

CREATE TABLE Itens
(
	IdItem	INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(50)NOT NULL
);

CREATE TABLE TiposConsertos
(
	IdTipoConserto INT PRIMARY KEY IDENTITY
	,Descricao VARCHAR(50)NOT NULL
);

CREATE TABLE Pedidos
(
	IdPedido INT PRIMARY KEY IDENTITY
	,IdCliente INT FOREIGN KEY REFERENCES Clientes(IdCliente)NOT NULL
	,IdItem	INT FOREIGN KEY REFERENCES Itens(IdItem)NOT NULL
	,IdTipoConserto	INT FOREIGN KEY REFERENCES TiposConsertos(IdTipoConserto)NOT NULL
	,NumEquipamento	INT NOT NULL
	,Entrada	DATE NOT NULL
	,Saida	DATE NOT NULL
);

CREATE TABLE PedidosColaboradores
(
	IdPedido	INT FOREIGN KEY REFERENCES Pedidos(IdPedido)NOT NULL
	,IdColaborador	INT FOREIGN KEY REFERENCES Colaboradores(IdColaborador)NOT NULL
);


/*listar todos os pedidos de um determinado cliente,
mostrando quais foram os colaboradores que executaram o serviço,
qual foi o tipo de conserto, qual item foi consertado e o nome deste cliente*/
CREATE FUNCTION PesquisaPedidos (@Nome VARCHAR (50))
RETURNS @valores TABLE (IdPedido INT,Colaborador VARCHAR(50),Descricao VARCHAR(50),Item VARCHAR(50),Cliente VARCHAR(50))
AS
	BEGIN
		INSERT @valores(IdPedido,Colaborador,Descricao,Item,Cliente)
		SELECT Pedidos.IdPedido AS NºPedido,Colaboradores.Nome,TiposConsertos.Descricao AS TipoConserto,Itens.Nome,Clientes.Nome FROM Pedidos
		INNER JOIN PedidosColaboradores
		ON Pedidos.IdPedido = PedidosColaboradores.IdPedido
		INNER JOIN Colaboradores
		ON Colaboradores.IdColaborador = PedidosColaboradores.IdColaborador
		INNER JOIN TiposConsertos
		ON Pedidos.IdTipoConserto = TiposConsertos.IdTipoConserto
		INNER JOIN Itens
		ON Pedidos.IdItem = Itens.IdItem
		INNER JOIN Clientes
		ON Pedidos.IdCliente = Clientes.IdCliente
		WHERE Clientes.Nome = @Nome;
	RETURN
END



	



