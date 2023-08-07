CREATE DATABASE Ecommerce;

USE Ecommerce;

--criado as tabelas do bd

CREATE TABLE Lojas
(
	IdLoja	INT PRIMARY KEY IDENTITY
	,Nome	VARCHAR(50)NOT NULL
);

CREATE TABLE Categorias
(
	IdCategoria	INT PRIMARY KEY IDENTITY
	,Nome	VARCHAR(50)NOT NULL
	,IdLoja	INT FOREIGN KEY REFERENCES Lojas(IdLoja)NOT NULL
);

CREATE TABLE SubCategorias
(
	IdSubCategoria	INT PRIMARY KEY IDENTITY
	,Nome	VARCHAR(50)NOT NULL
	,IdCategoria	INT FOREIGN KEY REFERENCES Categorias(IdCategoria)NOT NULL
);

CREATE TABLE Produtos
(
	IdProduto	INT PRIMARY KEY IDENTITY
	,Titulo	VARCHAR(50)NOT NULL
	,Valor SMALLMONEY NOT NULL
	,IdSubCategoria	INT FOREIGN KEY REFERENCES SubCategorias(IdSubCategoria)NOT NULL
);

CREATE TABLE Clientes
(
	IdCliente	INT PRIMARY KEY IDENTITY
	,Nome	VARCHAR(50)NOT NULL
);

CREATE TABLE Pedidos
(
	IdPedido	INT PRIMARY KEY IDENTITY
	,NumPedido	INT 
	,IdCliente	INT FOREIGN KEY REFERENCES Clientes(IdCliente)
	,DataPedido	DATE
	,[Status] VARCHAR(50)
);



CREATE TABLE PedidosProdutos
(
	IdPedido	INT FOREIGN KEY REFERENCES Pedidos(IdPedido)
	,IdProduto	INT FOREIGN KEY REFERENCES Produtos(IdProduto)
);


/* listar todos os pedidos de um cliente (nome), mostrando quais produtos foram solicitados (titulo)
neste pedido e de qual subcategoria (nome) e categoria (nome) pertencem*/
CREATE FUNCTION PesquisaPedido (@Nome VARCHAR (50))
RETURNS @valores TABLE (IdPedido INT,Nome VARCHAR(50),Produto VARCHAR(50),Subcategoria VARCHAR(50),Categoria VARCHAR (50))
AS
	BEGIN
		INSERT @valores(IdPedido,Nome,Produto,Subcategoria,Categoria)
		SELECT Pedidos.IdPedido AS NºPedido,Clientes.Nome AS Cliente,Produtos.Titulo AS Produto,SubCategorias.Nome AS Subcategoria,Categorias.Nome AS Categoria FROM Pedidos
		INNER JOIN PedidosProdutos
		ON Pedidos.IdPedido = PedidosProdutos.IdPedido
		INNER JOIN Clientes
		ON Pedidos.IdCliente = Clientes.IdCliente
		INNER JOIN Produtos
		ON PedidosProdutos.IdProduto = Produtos.IdProduto
		INNER JOIN SubCategorias
		ON Produtos.IdSubCategoria = SubCategorias.IdSubCategoria
		INNER JOIN Categorias
		ON Categorias.IdCategoria = SubCategorias.IdCategoria
		WHERE Clientes.Nome = @Nome;
	RETURN
END