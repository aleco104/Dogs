DROP TABLE Products
DROP TABLE Categories
DROP TABLE Manufacturers
DROP TABLE TargetAnimals

CREATE TABLE Categories
(
	CategoryId int not null identity primary key,
	CategoryName nvarchar(50) not null unique
)

CREATE TABLE Manufacturers
(
	ManufacturerId int not null identity primary key,
	ManufacturerName nvarchar(50) not null unique
)

CREATE TABLE TargetAnimals
(
	AnimalId int not null identity primary key,
	AnimalName nvarchar(50) not null unique
)

CREATE TABLE Products
(
	ProductId int not null identity primary key,
	ProductName nvarchar(50) not null unique,
	Price money not null,
	CategoryId int null references Categories(CategoryId),
	ManufacturerId int null references Manufacturers(ManufacturerId),
	AnimalId int null references TargetAnimals(AnimalId)
)