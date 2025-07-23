--drop database DBAlmoxarifadoXYZ

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
    UnMedida VARCHAR(100) NOT NULL,
    EstoqueAtual int foreign key (CodigoCategoria) references Categoria(Codigo),
    EPermanente BIT DEFAULT 0, -- Define 0 como valor padrão
    CodigoCategoria INT NULL
);






Create table Fornecedor(
Codigo int identity(1,1) primary key,
NomeFornecedor varchar(100) not null,
Endereco varchar(100) not null,
Bairro varchar(100) not null,
Cidade varchar(100),
Estado varchar(2),
Telefone varchar(100),
CNPJ varchar(100)
);

create table Secretaria(
Codigo int identity(1,1) primary key,
NomeSecretaria varchar(100),
Endereco varchar(100),
Bairro varchar(100),
Cidade varchar(100),
Estado varchar(2),
Telefone Varchar(100),
CNPJ varchar(100)
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
