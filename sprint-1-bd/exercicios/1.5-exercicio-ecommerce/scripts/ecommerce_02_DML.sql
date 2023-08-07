USE Ecommerce;

--inserido os dados nos campos das tabelas
INSERT INTO Clientes (Nome)
VALUES ('Gabriel'),('Paulo');

INSERT INTO Lojas(Nome)
VALUES ('Senai Shop'),('Magazine');

INSERT INTO Categorias (Nome,IdLoja)
VALUES ('Eletrônicos',1),('Eletrodomésticos',2);

INSERT INTO SubCategorias (Nome,IdCategoria)
VALUES ('Celular',1),('Geladeira',2);

INSERT INTO Produtos(Titulo,Valor,IdSubCategoria)
VALUES ('Iphone 12 Pro Max',8000,1),('Philips 600L',3500,2),('Moto G9 Plus',1000,1),('Brastemp 200L',1500,2);

INSERT INTO Pedidos(NumPedido,IdCliente,DataPedido,[Status])
VALUES (1,2,'2019-05-30','Entregue'),(2,2,'2020-03-25','A retirar'),(3,2,'2018-05-10','Entregue'),(4,1,'2014-03-25','A retirar'),(5,1,'2012-03-21','Entregue');

INSERT INTO PedidosProdutos(IdPedido,IdProduto)
VALUES (1,1003),(2,1004),(3,1005),(4,1003),(5,1005);





