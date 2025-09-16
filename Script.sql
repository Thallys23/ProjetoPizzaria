-- Criando Banco de Dados
create database dbpizza;

-- Usando Banco de Dados
use dbpizza;

-- Criando as Tabelas do Banco de Dados
create table tbpedido(
codPedido int primary key auto_increment,
tipoPizza varchar(50),
valorPizza varchar(50),
valorOpcao varchar(50),
ValorTotal varchar(50)
);

-- Consultando as Tabelas do Banco de Dados
select * from tbPedido;