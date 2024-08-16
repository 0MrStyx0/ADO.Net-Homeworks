CREATE DATABASE OfficeSupplies

USE OfficeSupplies

CREATE TABLE ProductsTypes
(
    ProductTypeID INT PRIMARY KEY IDENTITY(1,1),
    ProductTypeName NVARCHAR(30) NOT NULL CHECK(ProductTypeName!='')
)

CREATE TABLE Products
(
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(30) NOT NULL CHECK(ProductName!=''),
    ProductTypeID INT REFERENCES ProductsTypes(ProductTypeID),
    Quantity INT NOT NULL CHECK(Quantity >= 0),
    CostPrice DECIMAL(10, 2) NOT NULL CHECK(CostPrice >= 0)
)

CREATE TABLE SalesManagers
(
    ManagerID INT PRIMARY KEY IDENTITY(1,1),
    ManagerName NVARCHAR(40) NOT NULL CHECK(ManagerName!='')
)

CREATE TABLE Clients
(
    ClientID INT PRIMARY KEY IDENTITY(1,1),
    ClientName NVARCHAR(40) NOT NULL CHECK(ClientName!='')
)

CREATE TABLE Sales
(
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT REFERENCES Products(ProductID),
    ManagerID INT REFERENCES SalesManagers(ManagerID),
    ClientID INT REFERENCES Clients(ClientID),
    QuantitySold INT NOT NULL,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    SaleDate DATE NOT NULL CHECK(SaleDate<=GETDATE())
)

INSERT INTO ProductsTypes (ProductTypeName) VALUES
('Pens'),
('Pencils'),
('Notepads'),
('Notebooks'),
('Cartridges'),
('Scissors')

INSERT INTO Products (ProductName, ProductTypeID, Quantity, CostPrice) VALUES
('Blue Pen', 1, 100, 1.50),
('Black Pen', 1, 150, 1.50),
('Gel Pen', 1, 200, 2.00),
('Pencil HB', 2, 300, 0.75),
('Colored Pencil', 2, 250, 1.00),
('Notepad А5', 3, 80, 3.00),
('Notepad А4', 3, 60, 4.50),
('Notebook 48 sheets', 4, 120, 2.00),
('Notebook 96 sheets', 4, 90, 3.50),
('Cartridge for Printer', 5, 50, 25.00),
('Scissors 8"', 6, 40, 5.00),
('Paper Clips', 6, 500, 0.10),
('Notepad "Note For Pad!"', 3, 70, 2.50),
('Handle for Plastic', 1, 80, 2.20),
('Eraser', 2, 180, 0.50),
('Checked notebook', 4, 110, 3.00),
('Notebook "Flash"', 3, 40, 4.00),
('Glue stick', 6, 30, 2.00),
('Markers', 2, 120, 5.00),
('Document folder', 6, 90, 3.50),
('Ruler', 6, 200, 1.00),
('Cardboard sheet', 6, 150, 0.20),
('PVA glue', 6, 45, 2.50),
('Stickers', 3, 200, 1.00),
('Colored paper', 6, 300, 0.30);

INSERT INTO SalesManagers (ManagerName) VALUES
('James Cameron'),
('Stella Bridge'),
('Ankor Deadman'),
('Sam Porter');

INSERT INTO Clients (ClientName) VALUES
('Company A'),
('Company B'),
('Company C'),
('Company D'),
('Company E'),
('Company F'),
('Company G');

INSERT INTO Sales (ProductID, ManagerID, ClientID, QuantitySold, UnitPrice, SaleDate) VALUES
(1, 1, 1, 10, 2.50, '2023-10-10'),
(2, 1, 2, 15, 3.50, '2023-10-11'),
(3, 2, 1, 5, 4.00, '2023-10-12'),
(4, 3, 3, 20, 1.75, '2023-10-13'),
(5, 3, 4, 25, 2.00, '2023-10-14'),
(6, 4, 5, 12, 3.50, '2023-10-15'),
(7, 1, 6, 8, 5.50, '2023-10-16'),
(8, 2, 7, 5, 3.00, '2023-10-17'),
(9, 2, 1, 18, 4.50, '2023-10-18'),
(10, 3, 2, 10, 30.00, '2023-10-19'),
(11, 4, 3, 7, 7.00, '2023-10-20'),
(12, 1, 4, 30, 1.10, '2023-10-21'),
(13, 2, 5, 25, 3.50, '2023-10-22'),
(14, 3, 6, 14, 2.00, '2023-10-23'),
(15, 4, 7, 22, 4.00, '2023-10-24'),
(16, 1, 1, 10, 5.00, '2023-10-25'),
(17, 2, 2, 12, 3.20, '2023-10-26'),
(18, 3, 3, 9, 8.00, '2023-10-27'),
(19, 4, 4, 11, 2.50, '2023-10-28'),
(20, 1, 5, 21, 2.20, '2023-10-29'),
(21, 2, 6, 17, 4.50, '2023-10-30'),
(22, 3, 7, 30, 5.50, '2023-10-31'),
(23, 4, 1, 22, 1.30, '2023-11-01'),
(24, 1, 2, 13, 2.00, '2023-11-02'),
(25, 2, 3, 16, 3.75, '2023-11-03'),
(1, 3, 5, 10, 1.50, '2023-11-04'),
(2, 4, 6, 14, 3.20, '2023-11-05'),
(3, 1, 7, 8, 4.40, '2023-11-06'),
(4, 2, 1, 21, 1.95, '2023-11-07'),
(5, 3, 2, 10, 4.20, '2023-11-08'),
(6, 4, 3, 9, 5.20, '2023-11-09'),
(7, 1, 4, 19, 1.80, '2023-11-10'),
(8, 2, 5, 12, 2.10, '2023-11-11')


select top 1 p.ProductName, sum(s.QuantitySold) as TotalUnitsSold
from Sales s
join Products p on s.ProductID = p.ProductID
group by p.ProductID, p.ProductName
order by TotalUnitsSold desc
