USE [RentACar];

-- Create tables
CREATE TABLE [Cars] 
(
	[Id] INT IDENTITY PRIMARY KEY NOT NULL, 
	[RgNum] VARCHAR(50) NOT NULL, 
	[Km] INT
);

CREATE TABLE [Customers] 
(
	[Id] INT IDENTITY PRIMARY KEY NOT NULL, 
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL, 
	[Phone] INT,
	[Email] VARCHAR(50),
	[Car] INT,
	CONSTRAINT [fk_customers_id_car] FOREIGN KEY([Car]) REFERENCES [Cars]([Id]),
	[From] DATETIME,
	[To] DATETIME,
);

