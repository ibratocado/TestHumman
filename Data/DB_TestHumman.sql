IF EXISTS (SELECT * FROM sysdatabase WHERE (name = 'DB_TestHumman')) 
BEGIN
	drop database DB_TestHumman;
END
ELSE
	create database DB_TestHumman;

go
use DB_TestHumman;

--CREACION DE TABLAS
CREATE TABLE rols(
	id INT PRIMARY KEY IDENTITY,
	name VARCHAR(20)
	);

CREATE TABLE accounts(
	id INT PRIMARY KEY IDENTITY,
	count VARCHAR(45),
	pount VARCHAR(45),
	rolId INT,
	FOREIGN KEY(rolId) REFERENCES rols(id) ON UPDATE CASCADE ON DELETE CASCADE
	);

CREATE TABLE clients(
	id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(45),
	lastNames VARCHAR(45),
	accountId INT,
	address TEXT,
	FOREIGN KEY(accountId) REFERENCES accounts(id) ON UPDATE CASCADE ON DELETE CASCADE
	);

CREATE TABLE stores(
	id INT PRIMARY KEY IDENTITY(1,1),
	branchOffice VARCHAR(45),
	address TEXT
	);

CREATE TABLE articles(
	id	INT PRIMARY KEY IDENTITY(1,1),
	description TEXT,
	price REAL,
	image VARCHAR(80),
	stock INT,
	state BIT
	);

CREATE TABLE inventary(
	id INT PRIMARY KEY IDENTITY(1,1),
	articleId INT,
	storeId INT,
	date DATETIME,
	FOREIGN KEY(articleId) REFERENCES articles(id) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY(storeId) REFERENCES stores(id) ON UPDATE CASCADE ON DELETE CASCADE
	);

CREATE TABLE sales(
	id INT PRIMARY KEY IDENTITY(1,1),
	clientId INT,
	inventaryId INT,
	pieces INT,
	totalPrice REAL,
	date DATETIME,
	state BIT,
	FOREIGN KEY(clientId) REFERENCES clients(id) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY(inventaryId) REFERENCES inventary(id) ON UPDATE CASCADE ON DELETE CASCADE,
	);

--CREACION DE TRIGGERS

CREATE TRIGGER triUpdateInventaryPieces
	ON sales
	FOR INSERT
	AS	BEGIN
		DECLARE @idArticle INT;
		SET @idArticle = (SELECT inventary.articleId FROM inserted INNER JOIN inventary
			ON inserted.inventaryId = inventary.id);

		
		DECLARE @stock INT;
		SET @stock = (SELECT inserted.pieces FROM inserted);
		SET @stock = @stock - (SELECT articles.stock FROM inserted INNER JOIN inventary
			ON inserted.inventaryId = inventary.id
			INNER JOIN articles 
			ON inventary.articleId = articles.id);
		UPDATE articles SET stock = @stock WHERE @idArticle = id;
	END	