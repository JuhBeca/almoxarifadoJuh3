CREATE DATABASE DBAlmoxarifadoXYZ;
GO
USE DBAlmoxarifadoXYZ;
GO

-- Tabela Categoria
CREATE TABLE Categoria(
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(100)
);

-- Tabela Produto
CREATE TABLE Produto (
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    Descricao VARCHAR(100),
    Preco float,
    UnidadeMedida VARCHAR(100),
    EstoqueAtual INT,
    Epermanente BIT DEFAULT 0,
    CodigoCategoria INT FOREIGN KEY REFERENCES Categoria(Codigo)
);

-- Tabela Fornecedor
CREATE TABLE Fornecedor(
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100),
    Telefone VARCHAR(100),
    Estado VARCHAR(2),
    Cidade VARCHAR(100),
    CNPJ VARCHAR(100)
);

-- Tabela Secretaria
CREATE TABLE Secretaria(
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100),
    Telefone VARCHAR(100),
    Estado VARCHAR(2),
    Cidade VARCHAR(100),
    CNPJ VARCHAR(100)
);

-- Tabela Entrada
CREATE TABLE Entrada(
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    DataEntrada DATETIME,
    CodigoFronecedor INT FOREIGN KEY REFERENCES Fornecedor(Codigo),
    CodigoProduto INT FOREIGN KEY REFERENCES Produto(Codigo),
    Quantidade INT,
    Observacao VARCHAR(100)
);

-- Tabela Saida com colunas para preço
CREATE TABLE Saida (
    Codigo INT IDENTITY(1,1) PRIMARY KEY,
    DataSaida DATETIME,
    CodigoSecretaria INT FOREIGN KEY REFERENCES Secretaria(Codigo),
    CodigoProduto INT FOREIGN KEY REFERENCES Produto(Codigo),
    PrecoProduto FLOAT,
    PrecoTotal FLOAT,
    Quantidade INT,
    Observacao VARCHAR(100)
);




