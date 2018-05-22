GO 
USE [master]
CREATE DATABASE DapperBase;

GO
USE [DapperBase]
CREATE TABLE [dbo].[Address] (
ID int IDENTITY(1,1) PRIMARY KEY,
Street varchar(max) NOT NULL,
ZipCode varchar(max) NOT NULL,
City varchar(max) NOT NULL,
)

GO
USE [DapperBase]
INSERT INTO [Address]
VALUES ('street', '6700', 'City');

GO
USE [DapperBase]
INSERT INTO [Address]
VALUES ('street', '6700', 'City');

GO
USE [DapperBase]
INSERT INTO [Address]
VALUES ('street', '6700', 'City');


GO
USE [DapperBase]
CREATE TABLE [dbo].[Customer] (
ID int IDENTITY(1,1) PRIMARY KEY,
AddressID int FOREIGN KEY REFERENCES [Address](ID) ON DELETE CASCADE,
FirstName varchar(max) NOT NULL,
LastName varchar(max) NOT NULL,
Email varchar(max) NOT NULL,
PhoneNumber varchar(max) NOT NULL
)

GO 
USE [DapperBase]
INSERT INTO Customer 
VALUES (1, 'Carl', 'lastname','mail@mail.com', '12345678');

GO 
USE [DapperBase]
INSERT INTO Customer 
VALUES (2, 'Frank', 'lastname','mail@mail.com', '12345678');

GO 
USE [DapperBase]
INSERT INTO Customer 
VALUES (3, 'Cyle', 'lastname','mail@mail.com', '12345678');



