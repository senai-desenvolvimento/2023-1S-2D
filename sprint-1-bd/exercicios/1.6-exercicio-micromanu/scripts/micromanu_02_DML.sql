USE Micromanu;

INSERT INTO Clientes(Nome)
VALUES ('Katia'),('Eber');

INSERT INTO Colaboradores(Nome,Salario)
VALUES ('Leandro',5000),('Jose',7500);

INSERT INTO Itens(Nome)
VALUES ('Notebook Dell'),('Pc Gamer');

INSERT INTO TiposConsertos(Descricao)
VALUES ('Formatação'),('Troca de fonte');

INSERT INTO Pedidos(IdCliente,IdItem,IdTipoConserto,NumEquipamento,Entrada,Saida)
VALUES (1,1,1,005,'2020-04-16','2020-05-16'),(2,2,2,006,'2021-02-11','2021-02-27');

INSERT INTO PedidosColaboradores(IdPedido,IdColaborador)
VALUES (2,1),(3,2);