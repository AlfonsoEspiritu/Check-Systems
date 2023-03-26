CREATE DATABASE SistemaDeCheques;

USE SistemaDeCheques;

CREATE TABLE [Users] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [username] varchar(20) NOT NULL,
    [password] varchar(255) NOT NULL,
    constraint pk_user primary key (id)
);

CREATE TABLE [Beneficiaries] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [name] VARCHAR(50) NOT NULL,
    [address] VARCHAR(80) NOT NULL,
    [phone] VARCHAR(15) NOT NULL,
    [description] VARCHAR(60) NOT NULL,
    [active] BIT NOT NULL DEFAULT 0,
    constraint pkBeneficiary primary key (id),
);

CREATE TABLE [Accounts] (
    [id] INT IDENTITY(1,1) NOT NULL,
	[name] varchar(50) NOT NULL,
    [initialBalance] DECIMAL(18,2) NOT NULL,
    [balance] DECIMAL(10,2) NOT NULL,
	[bankName] varchar(50) NOT NULL,
	[bankNumber] varchar(50) NOT NULL,
	[owner] int not null,
	[firstInvoice] int,
	[lastInvoice] int,
    constraint pkAccount primary key (id),
);


CREATE TABLE [Concepts](
	[id] INT IDENTITY(1,1) NOT NULL,
	[name] VARCHAR(60) NOT NULL,
	constraint pkConcept primary key (id)
);

CREATE TABLE [Deposits](
	[id] INT IDENTITY(1,1) NOT NULL,
	[mount] DECIMAL(18,2) NOT NULL,
	[date] DATE NOT NULL,
	[account] INT NOT NULL,
	constraint pkDeposit primary key (id),
	constraint fkDepositAccount foreign key ([account]) references [Accounts](id)
);

CREATE TABLE [Checks] (
    [id] INT IDENTITY(1,1) NOT NULL,
    [invoice] VARCHAR(8) NOT NULL,
    [beneficiary] INT NOT NULL,
    [mount] DECIMAL(18,2) NOT NULL,
    [date] DATE NOT NULL,
	[state] BIT NOT NULL,
    [account] INT NOT NULL,
	[concept] INT NOT NULL,
	unique(invoice),
    constraint pkCheck primary key (id),
    constraint fkCheckBeneficiary foreign key ([beneficiary]) references [Beneficiaries](id),
    constraint fkCheckAccount foreign key ([account]) references [Accounts](id),
	constraint fkCheckConcept foreign key ([concept]) references [Concepts](id)
);
Alter table [Checks] alter column [mount] decimal(18,2)




--CREATE TABLE [Users] (
--	[id] INT IDENTITY(1,1) NOT NULL,
--	[username] varchar(20) NOT NULL,
--	[name] varchar(50) NOT NULL,
--	[password] varchar(255) NOT NULL,
--	constraint pk_user primary key (id)
--);

--CREATE TABLE [Accounts] (
--	[id] INT IDENTITY(1,1) NOT NULL,
--	[initialState] DECIMAL NOT NULL,
--	[balance] DECIMAL NOT NULL,
--	[username] VARCHAR(20) UNIQUE NOT NULL,
--	[name] VARCHAR(50) NOT NULL,
--	[password] VARCHAR(255) NOT NULL,
--	-- [totalChecks] INT NOT NULL,
--	constraint pkAccount primary key (id)
--);

--CREATE TABLE [Concepts] (
--	[id] INT IDENTITY(1,1) NOT NULL,
--	[name] VARCHAR(60) NOT NULL,
--	constraint pkConcepts primary key (id)
--);

--CREATE TABLE [Beneficiaries] (
--	[id] INT IDENTITY(1,1) NOT NULL,
--	[name] VARCHAR(50) NOT NULL,
--	[address] VARCHAR(80) NOT NULL,
--	[phone] VARCHAR(16) NOT NULL,
--	[description] VARCHAR(60) NOT NULL,
--	[active] BIT NOT NULL DEFAULT 1,
--	constraint pkBeneficiary primary key (id),
--);

--CREATE TABLE [Checks] (
--	[id] INT IDENTITY(1,1) NOT NULL,
--	[invoice] VARCHAR(8) UNIQUE NOT NULL,
--	[mount] DECIMAL NOT NULL,
--	[date] DATE NOT NULL,
--	[account] INT NOT NULL,
--	[beneficiary] INT NOT NULL,
--	[concept] INT NOT NULL,
--	constraint pkCheck primary key (id),
--	constraint fkAccount foreign key ([account]) references [Accounts](id),
--	constraint fkBeneficiary foreign key ([beneficiary]) references [Beneficiaries](id),
--	constraint fkConcept foreign key ([concept]) references [Concepts](id),
--);

INSERT INTO [Users] values ('frcomparan', '1234');
INSERT INTO [Users] values ('testuser', '1234');

INSERT INTO [Accounts] values (999999, 999999, 'testuser', 'Test Name', '1234');
INSERT INTO [Accounts] values (1000, 1000, 'frcomparan', 'Francisco Comparan', '1234');

INSERT INTO [Concepts] values 
	('Primer concepto de prueba'),
	('Segundo concepto de prueba'),
	('Tercer concepto de prueba');

select * from Users;

SELECT * FROM [Accounts];

SELECT * FROM [Checks];

update [Accounts] SET firstInvoice = 1, lastInvoice = 50 where id = 2

INSERT INTO [Accounts] values (
	(SELECT id FROM [Users] where username='Username'),
	3000,
	3000
);

UPDATE [Accounts] SET [balance] = 5000 WHERE [username]='frcomparan';
INSERT INTO [Beneficiaries] values ('Arturo Manrriques', 'Av.Tecnologico', '3121205951', 'some description', 1);
INSERT INTO [Beneficiaries] values ('Jose heredia', 'Tecoman', '52334', 'some description', 1);
INSERT INTO [Beneficiaries] values ('Gustavo Garcia', 'Villa de Álvarez', '24243', 'some description', 1);
INSERT INTO [Beneficiaries] values ('Horacio Garcia', 'Centro', '51324234', 'some description', 1);
INSERT INTO [Beneficiaries] values ('Benito', 'Tercer anillo', '543534', 'some description', 1);
INSERT INTO [Checks] VALUES (
	'001', 1000, '02/07/2020',2,1,1
	);



SELECT COUNT(id), (SELECT TOP 1 invoice FROM [Checks] order by id desc) FROM [Checks];

SELECT * FROM [Checks];
SELECT	COUNT(id), 
		(SELECT TOP 1 invoice FROM [Checks] WHERE account = 1 order by id desc), 
		(SELECT firstInvoice FROM [Accounts] WHERE id = 1), 
		(SELECT lastInvoice FROM [Accounts] WHERE id = 1) 
		FROM [Checks] WHERE account = 1;

SELECT TOP 1 * FROM [Beneficiaries] order by id DESC;

UPDATE [Beneficiaries] SET 
	[name] = 'update name', 
	[Address] = 'update address', 
	[Phone] = 'update phone', 
	[description] = 'update descriptio', 
	[active] = 'false' WHERE [id] = 2;


SELECT *  FROM [Beneficiaries] WHERE ([Id]='' OR [Name] LIKE '%%' OR [Phone] LIKE 'zz') OR [Active] = '1';

SELECT * FROM [Checks];

SELECT *  FROM [Checks] WHERE (date >= '2023-02-01' AND date <= '2023-04-01') ;

SELECT *  FROM [Checks] WHERE (mount >= 1000 AND mount <= 2000) ;

SELECT *  FROM [Checks] WHERE (invoice >= 2 AND invoice <= 3) ;

SELECT *  FROM [Checks] WHERE (beneficiary = 1) ;

SELECT *  FROM [Checks] 
	WHERE 
	(date >= '2023-02-01' AND date <= '2023-04-01') AND 
	(mount >= 1000 AND mount <= 2000) AND 
	(invoice >= 2 AND invoice <= 3) AND
	(beneficiary = 1);

SELECT * FROM [Checks];

Select * from Accounts

truncate table [Checks];

INSERT INTO [CHECKS] VALUES ('2', 1, 80, '2023-01-15', 1, 1, 1)
INSERT INTO [CHECKS] VALUES ('1', 1, 80, '2023-01-15', 1, 2, 1)

SELECT *  FROM [Checks] WHERE [Id]=1;
select * from Beneficiaries
