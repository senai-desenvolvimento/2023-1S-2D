--DML - DATA MANIPULATION LANGUAGE

INSERT INTO Funcionarios(Nome)
VALUES('CATARINA')

UPDATE Funcionarios
SET Nome = 'MIGUEL' WHERE IdFuncionario = 20

DELETE FROM Funcionarios WHERE IdFuncionario = 20

INSERT INTO Empresas(IdFuncionario,Nome)
VALUES (23,'GOOGLE')
