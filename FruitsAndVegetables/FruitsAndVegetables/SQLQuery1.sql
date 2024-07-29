create database FruitsAndVegetables

use FruitsAndVegetables

create Table Plants
(
Id int not null primary key identity(1,1),
[Name] nvarchar(30) not null check([Name]!=''),
[Type] nvarchar(30) not null check([Type]='Fruit' or [Type]='Vegetable'),
Color nvarchar(30) not null check(Color!=''),
CalorieContent int not null check(CalorieContent>=0)
)

insert into Plants
values
('Tomato', 'Vegetable', 'Red', 18),
('Cucumber', 'Vegetable', 'Green', 16),
('Carrot', 'Vegetable', 'Orange', 41),
('Apple', 'Fruit', 'Green', 52),
('Banana', 'Fruit', 'Yellow', 89),
('Spinach', 'Vegetable', 'Green', 23),
('Strawberry', 'Fruit', 'Red', 32),
('Zucchini', 'Vegetable', 'Green', 17),
('Blueberry', 'Fruit', 'Blue', 57),
('Lettuce', 'Vegetable', 'Green', 15),
('Bell Pepper', 'Vegetable', 'Red', 31),
('Peach', 'Fruit', 'Yellow', 39),
('Broccoli', 'Vegetable', 'Green', 55),
('Grape', 'Fruit', 'Purple', 67),
('Onion', 'Vegetable', 'White', 40),
('Pineapple', 'Fruit', 'Brown', 50),
('Radish', 'Vegetable', 'Pink', 16),
('Mango', 'Fruit', 'Yellow', 60),
('Eggplant', 'Vegetable', 'Purple', 25),
('Watermelon', 'Fruit', 'Green', 30),
('Asparagus', 'Vegetable', 'Green', 20),
('Kiwi', 'Fruit', 'Brown', 61),
('Cauliflower', 'Vegetable', 'White', 25),
('Cabbage', 'Vegetable', 'Green', 25),
('Raspberry', 'Fruit', 'Red', 52),
('Pomegranate', 'Fruit', 'Red', 83),
('Celery', 'Vegetable', 'Green', 16),
('Sweet Potato', 'Vegetable', 'Orange', 86),
('Blackberry', 'Fruit', 'Black', 43),
('Passion Fruit', 'Fruit', 'Purple', 97),
('Kale', 'Vegetable', 'Green', 49),
('Chili Pepper', 'Vegetable', 'Red', 40)