USE Clinicas;

INSERT INTO Donos (Nome)
VALUES ('Carlos'),('Paulo');

INSERT INTO Tipos (TipoPEt)
VALUES ('Suíno'),('Reptil'),('Ave');

INSERT INTO Racas (IdTipo,NomeRaca)
VALUES ('1','Shiba Inu'),('2','Siberiano');

INSERT INTO Pets (IdDono,IdRaca,Nome,DataNascimento,Telefone)
VALUES (1,2,'Doug','2019-02-20','997472686'),(2,3,'Fred','2018-05-05','947589659');

INSERT INTO Clinicas (Nome,Endereco)
VALUES ('PetShop','Av Paulista,1200,Jd Paulista,São Paulo'),('DogPet','Av Faria Lima,500,Jd Europa');

INSERT INTO Veterinarios (IdClinica,Nome,CRMV)
VALUES (1,'Dr Takae','RJ5000'),(2,'Dra Simone','SP3650');

INSERT INTO Atendimentos (IdPet,IdVeterinario,Servico,DataAtendimento,ValorConsulta)
VALUES (1,1,'Castração','2019-05-15','575'),(2,2,'Cirurgia Cardíaca','2019-05-15','1350');

--fazendo update da tabela clinicas
UPDATE Clinicas
SET Endereco = 'Av Faria Lima,500,Jd Europa,São Paulo'
WHERE IdClinica = 2;

