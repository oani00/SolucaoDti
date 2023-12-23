# SolucaoDti

Solucao teste tecnico DTI

A documentação exigida pode ser encontrada em
[DOCS](Documentacao.pdf)

Demonstração:
![DEMO](gifDemonstracao.gif)

# Stack

-Asp Net Core com .net6 para o front e back
-SQL Server para o banco.

Criação do banco:

-- Criação da tabela Produto
CREATE TABLE Produto (
Id INT PRIMARY KEY,
Nome NVARCHAR(255),
Descrição NVARCHAR(255),
ValorUnitario DECIMAL(10, 2)
);

-- Criação da tabela Estoque
CREATE TABLE Estoque (
Id INT IDENTITY(1, 1) PRIMARY KEY,
ProdutoId INT,
Quantidade INT,
FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
);

Populando a base com dados exemplo:

-- Criação de 10 produtos
INSERT INTO Produto (Id, Nome, Descrição, ValorUnitario) VALUES
(1, 'Livro', 'Um livro sobre programação em SQL', 29.90),
(2, 'Caneta', 'Uma caneta azul com tampa', 1.50),
(3, 'Caderno', 'Um caderno de 100 folhas pautadas', 15.00),
(4, 'Mochila', 'Uma mochila preta com zíper', 49.99),
(5, 'Fone de ouvido', 'Um fone de ouvido sem fio com Bluetooth', 79.90),
(6, 'Mouse', 'Um mouse óptico com USB', 39.90),
(7, 'Teclado', 'Um teclado sem fio com pilhas', 59.90),
(8, 'Monitor', 'Um monitor LED de 24 polegadas', 299.00),
(9, 'Impressora', 'Uma impressora multifuncional com Wi-Fi', 199.00),
(10, 'Câmera', 'Uma câmera digital com zoom óptico', 399.00);

-- Inserção de quantidades dos produtos
INSERT INTO Estoque (ProdutoId, Quantidade) VALUES
(1, 10),
(2, 20),
(3, 15),
(4, 5),
(5, 8),
(6, 12),
(7, 10),
(8, 3),
(9, 4),
(10, 2);
