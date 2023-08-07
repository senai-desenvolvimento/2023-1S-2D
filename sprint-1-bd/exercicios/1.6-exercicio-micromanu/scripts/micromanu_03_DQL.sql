USE Micromanu;

SELECT * FROM Clientes;

SELECT * FROM Colaboradores;

SELECT * FROM Itens;

--- listar todos os pedidos dos clientes
SELECT * FROM Pedidos;

SELECT * FROM PedidosColaboradores;

SELECT * FROM TiposConsertos;

/*listar todos os pedidos de um determinado cliente,
mostrando quais foram os colaboradores que executaram o serviço,
qual foi o tipo de conserto, qual item foi consertado e o nome deste cliente*/
--chamando a função criada
SELECT * FROM PesquisaPedidos('Katia');


