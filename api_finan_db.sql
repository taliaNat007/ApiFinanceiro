CREATE DATABASE api_finan_db;
USE api_finan_db;

CREATE TABLE despesas (
id int not null auto_increment,
descricao varchar (300) not null,
categoria varchar(100) not null,
valor decimal(10, 2) not null,
data_vencimento date not null,
data_pagamento datetime  null,
situacao varchar(50),

primary key (id)
);

INSERT INTO despesas (descricao, categoria, valor, data_vencimento, data_pagamento, situacao) VALUES
('Conta de luz', 'Utilidades', 150.75, '2026-03-10', '2026-03-09 14:30:00', 'paga'),
('Aluguel', 'Moradia', 1200.00, '2026-03-05', '2026-03-05 09:00:00', 'paga'),
('Internet', 'Utilidades', 99.90, '2026-03-15', NULL, 'pendente'),
('Supermercado', 'Alimentação', 350.40, '2026-03-12', '2026-03-12 18:20:00', 'paga'),
('Combustível', 'Transporte', 220.00, '2026-03-08', '2026-03-08 12:10:00', 'paga'),
('Plano de saúde', 'Saúde', 450.00, '2026-03-20', NULL, 'pendente'),
('Academia', 'Saúde', 89.90, '2026-03-18', NULL, 'pendente'),
('Streaming', 'Lazer', 39.90, '2026-03-11', '2026-03-11 21:00:00', 'paga'),
('Cartão de crédito', 'Financeiro', 980.60, '2026-03-25', NULL, 'pendente'),
('Manutenção do carro', 'Transporte', 600.00, '2026-03-14', '2026-03-14 16:45:00', 'paga');
