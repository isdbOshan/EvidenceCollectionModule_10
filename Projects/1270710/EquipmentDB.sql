 CREATE Database EquipmentDB
 GO
 Use EquipmentDB
 Go
 CREATE TABLE Equipment
(
    	EquipmentId INT IDENTITY PRIMARY KEY,
    	EquipmentName NVARCHAR(40) NOT NULL,
    	DeliveryDate Date NOT NULL,
	Price MONEY NOT NULL,
	Available BIT,
	Picture NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE Part
(
    	PartId INT IDENTITY PRIMARY KEY,
    	PartName NVARCHAR(40) NOT NULL,
    	Quantity int NOT NULL,
	EquipmentId INT NOT NULL REFERENCES Equipment(EquipmentId)
)
GO 
CREATE TABLE PartDetail
(
    	PartDetailId INT IDENTITY PRIMARY KEY,
    	Description NVARCHAR(120) NOT NULL,
    	Expiredate DATE NULL,
	Material NVARCHAR(50) NOT NULL,
	Company NVARCHAR(40),
    	PartId INT NOT NULL REFERENCES Part(PartId)
)
GO
CREATE TABLE Customers
(
    	CustomerId INT IDENTITY PRIMARY KEY,
    	CustomerName NVARCHAR(40) NOT NULL,
	Age INT NOT NULL,
    	City NVARCHAR(40) NOT NULL,
	Country NVARCHAR(40) NOT NULL,
	Phone NVARCHAR(30) NOT NULL,
	Email NVARCHAR(40) NOT NULL,
	Picture NVARCHAR(50) NOT NULL,
	EquipmentId INT NOT NULL REFERENCES Equipment(EquipmentId)
) 
GO

