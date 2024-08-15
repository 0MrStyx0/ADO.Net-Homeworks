create database Storage

use Storage

create table ProductTypes
(
Id int primary key identity(1,1),
[Name] nvarchar(30) not null check([Name]!='')
)

create table Suppliers
(
Id int primary key identity(1,1),
[Name] nvarchar(30) not null check([Name]!='')
)

create table Products
(
Id int primary key identity(1,1),
[Name] nvarchar(30) not null check([Name]!=''),
TypeId int not null references ProductTypes(Id),
SuppliersId int not null references Suppliers(Id),
[Count] int not null check([Count]>=0) default 0,
Price money not null check(Price>=0) default 0,
DeliveryDate date not null check(DeliveryDate<=getdate())
)

INSERT INTO ProductTypes 
VALUES 
('Electronics'),
('Furniture'),
('Clothing'),
('Books'),
('Toys')

INSERT INTO Suppliers
VALUES 
('Supplier A'),
('Supplier B'),
('Supplier C'),
('Supplier D')

INSERT INTO Products
VALUES 
('Smartphone', 1, 1, 100, 699.99, '2023-10-10'),
('Laptop', 1, 2, 50, 999.99, '2023-10-09'),
('Office Chair', 2, 3, 200, 149.99, '2023-10-08'),
('Dining Table', 2, 4, 30, 399.99, '2023-10-07'),
('T-Shirt', 3, 1, 150, 19.99, '2023-10-06'),
('Jeans', 3, 2, 100, 49.99, '2023-10-05'),
('Mystery Novel', 4, 3, 75, 14.99, '2023-10-04'),
('Cookbook', 4, 4, 60, 24.99, '2023-10-03'),
('Action Figure', 5, 1, 250, 29.99, '2023-10-02'),
('Puzzle', 5, 2, 120, 15.99, '2023-10-01'),
('Wireless Earbuds', 1, 3, 80, 89.99, '2023-09-30'),
('Sofa', 2, 4, 45, 599.99, '2023-09-29'),
('Sweater', 3, 1, 90, 39.99, '2023-09-28'),
('Novel', 4, 2, 110, 9.99, '2023-09-27'),
('Building Blocks', 5, 3, 200, 39.99, '2023-09-26'),
('Board Game', 5, 4, 60, 29.99, '2023-09-25'),
('Smartwatch', 1, 1, 50, 199.99, '2023-09-24'),
('Coffee Table', 2, 2, 80, 149.99, '2023-09-23'),
('Dress', 3, 3, 70, 59.99, '2023-09-22'),
('Stationery Set', 4, 4, 120, 9.99, '2023-09-21')

select s.Id, s.[Name], t.total
from Suppliers s
join (select SuppliersId, sum([Count]) as total from Products group by SuppliersId) t on s.Id=t.SuppliersId
where t.total=(select max(total) from (select sum([Count]) as total from Products group by SuppliersId) subquery)

select s.Id, s.[Name], t.total
from Suppliers s
join (select SuppliersId, sum([Count]) as total from Products group by SuppliersId) t on s.Id=t.SuppliersId
where t.total=(select min(total) from (select sum([Count]) as total from Products group by SuppliersId) subquery)

select pt.Id, pt.[Name], t.total
from ProductTypes pt
join (select TypeId, sum([Count]) as total from Products group by TypeId) t on pt.Id=t.TypeId
where t.total=(select max(total) from (select sum([Count]) as total from Products group by TypeId) subquery)

select pt.Id, pt.[Name], t.total
from ProductTypes pt
join (select TypeId, sum([Count]) as total from Products group by TypeId) t on pt.Id=t.TypeId
where t.total=(select min(total) from (select sum([Count]) as total from Products group by TypeId) subquery)
