USE Ecommerce;

--consulta de todos campos das tabelas do bd

SELECT * FROM Clientes;

SELECT * FROM Lojas;

SELECT * FROM Categorias;

SELECT * FROM SubCategorias;

SELECT * FROM Produtos;

SELECT * FROM Pedidos;

SELECT * FROM PedidosProdutos;

/* listar todos os pedidos de um cliente (nome), mostrando quais produtos foram solicitados
(titulo) neste pedido e de qual subcategoria (nome) e categoria (nome) pertencem*/
--chamando a função criada
SELECT * FROM PesquisaPedido('Gabriel');

