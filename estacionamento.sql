create database estacionamento;
use estacionamento;

CREATE TABLE Carros (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Modelo VARCHAR(255) NOT NULL,
    Placa VARCHAR(50) NOT NULL
);

CREATE TABLE Movimentacoes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Placa VARCHAR(10) NOT NULL,
    Data DATETIME NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL
);

