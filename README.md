# SolucaoDti

Solucao teste tecnico DTI

Criação do banco:

-- Criação da tabela Produto
CREATE TABLE Produto (
Id INT PRIMARY KEY,
Nome NVARCHAR(255),
ValorUnitario DECIMAL(10, 2)
);

-- Criação da tabela Produtos
CREATE TABLE Produtos (
Id INT,
ProdutoId INT,
Quantidade INT,
PRIMARY KEY (Id, ProdutoId),
FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
);

Populando a base:

-- Criação de 10 produtos
INSERT INTO Produto (Id, Nome, ValorUnitario) VALUES
(1, 'Livro', 29.90),
(2, 'Caneta', 1.50),
(3, 'Caderno', 15.00),
(4, 'Mochila', 49.99),
(5, 'Fone de ouvido', 79.90),
(6, 'Mouse', 39.90),
(7, 'Teclado', 59.90),
(8, 'Monitor', 299.00),
(9, 'Impressora', 199.00),
(10, 'Câmera', 399.00);

-- Inserção de quantidades dos produtos
INSERT INTO Produtos (Id, ProdutoId, Quantidade) VALUES
(1, 1, 10),
(1, 2, 20),
(1, 3, 15),
(1, 4, 5),
(1, 5, 8),
(1, 6, 12),
(1, 7, 10),
(1, 8, 3),
(1, 9, 4),
(1, 10, 2);
