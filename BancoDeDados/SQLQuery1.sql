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
    Descricao VARCHAR(100) NOT NULL,
    UnidadeMedida VARCHAR(100) NOT NULL,
    EstoqueAtual int,
    Epermanente BIT DEFAULT 0, -- Define 0 como valor padrão
    CodigoCategoria INT foreign key (CodigoCategoria) references Categoria(Codigo)
);






Create table Fornecedor(
Codigo int identity(1,1) primary key,
Nome varchar(100) not null,
Telefone varchar(100)not null,
Estado varchar(2) not null,
Cidade varchar(100) not null,
CNPJ varchar(100) not null
);

create table Secretaria(
Codigo int identity(1,1) primary key,
Nome varchar(100) not null,
Telefone varchar(100)not null,
Estado varchar(2) not null,
Cidade varchar(100) not null,
CNPJ varchar(100) not null
);

Create table Entrada(
Codigo int identity(1,1) primary key,
DataEntrada datetime,
CodigoFronecedor int foreign key (CodigoFronecedor) references Fornecedor(Codigo),
Observacao varchar(100)
);


create table Saida (
Codigo int identity(1,1) primary key,
DataSaida datetime not null,
CodigoSecretaria int foreign key (CodigoSecretaria) references Secretaria(Codigo),
Observacao varchar(100)
);

Select * from Categoria
Select * from Produto
Select * from Fornecedor
Select * from Secretaria
Select * from Saida
Select * from Entrada