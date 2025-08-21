create database DBAlmoxarifadoXYZ
go
use DBAlmoxarifadoXYZ
go

create table  Categoria(
    Codigo int identity(1,1) Primary key,
    Descricao varchar(100)
);

CREATE TABLE Produto (
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(100),
    UnidadeMedida VARCHAR(100),
    EstoqueAtual int,
    Epermanente BIT DEFAULT 0, -- Define 0 como valor padrão
    CodigoCategoria INT foreign key (CodigoCategoria) references Categoria(Codigo)
);






Create table Fornecedor(
Codigo int identity(1,1) primary key,
Nome varchar(100),
Telefone varchar(100),
Estado varchar(2) ,
Cidade varchar(100),
CNPJ varchar(100)
);

create table Secretaria(
Codigo int identity(1,1) primary key,
Nome varchar(100),
Telefone varchar(100),
Estado varchar(2),
Cidade varchar(100),
CNPJ varchar(100)
);

Create table Entrada(
Codigo int identity(1,1) primary key,
DataEntrada datetime,
CodigoFronecedor int foreign key (CodigoFronecedor) references Fornecedor(Codigo),
CodigoProduto int foreign key (CodigoProduto) references Produto(Codigo),
Quantidade int,
Observacao varchar(100)
);


create table Saida (
Codigo int identity(1,1) primary key,
DataSaida datetime,
CodigoSecretaria int foreign key (CodigoSecretaria) references Secretaria(Codigo),
CodigoProduto int foreign key (CodigoProduto) references Produto(Codigo),
Quantidade int,
Observacao varchar(100)
);


SELECT TOP 10
    RANK() OVER (ORDER BY COUNT(s.CodigoProduto) DESC) AS Ranking,
    p.Codigo AS CodigoProduto,
    p.Descricao AS NomeProduto,
    COUNT(s.CodigoProduto) AS TotalSaidas,       -- frequência de saídas
    SUM(s.Quantidade) AS QuantidadeTotal         -- total de unidades saídas
FROM 
    Saida s
JOIN 
    Produto p ON s.CodigoProduto = p.Codigo
GROUP BY 
    p.Codigo, p.Descricao
ORDER BY 
    TotalSaidas DESC;
