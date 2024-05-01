create database company;
use company;


create table Employee(
EmployeeId int  constraint emp_pk_id primary key,
Employee_name varchar(20) not null,
Salary int,
Boss_id int null constraint fk_employee_boss references Employee(EmployeeId),
)

create table Department(
Department_name varchar(20) constraint pk_department primary key,
Floor_no int,
Phone bigint not null,
Employee_id int constraint fk_department_employeeid references Employee(EmployeeId) not null
);

alter table Employee
add Department_name  varchar(20) null constraint fk_employee_departmentname references Department(Department_name);
create table Item(
Item_name varchar(30) constraint pk_item primary key,
Item_type varchar(5),
item_color varchar(10)
)
create table Sales(
Sales_id  int identity(201,1) constraint pk_sales primary key,
Item_name varchar(30) constraint fk_sales_itemname references Item(Item_name),
Department_name varchar(20) constraint fk_sales_departmentname references Department(Department_name) 
)

INSERT INTO Employee (EmployeeId, Employee_name, Salary, Boss_id)
VALUES
(1, 'Alice', 75000, NULL),
(2, 'Ned', 45000, 1),
(3, 'Andrew', 25000, 2),
(4, 'Clare', 22000, 2),
(5, 'Todd', 38000, 1),
(6, 'Nancy', 22000, 5),
(7, 'Brier', 43000, 1),
(8, 'Sarah', 56000, 7),
(9, 'Sophie', 35000, 1),
(10, 'Sanjay', 15000, 3),
(11, 'Rita', 15000, 4),
(12, 'Gigi', 16000, 4),
(13, 'Maggie', 11000, 4),
(14, 'Paul', 15000, 3),
(15, 'James', 15000, 3),
(16, 'Pat', 15000, 3),
(17, 'Mark', 15000, 3);
INSERT INTO Department (Department_name, Floor_no, Phone, Employee_id)
VALUES
('Management', 5, 34, 1),
('Books', 1, 81, 4),
('Clothes', 2, 24, 4),
('Equipment', 3, 57, 3),
('Furniture', 4, 14, 3),
('Navigation', 1, 41, 3),
('Recreation', 2, 29, 4),
('Accounting', 5, 35, 5),
('Purchasing', 5, 36, 7),
('Personnel', 5, 37, 9),
('Marketing', 5, 38, 2);

UPDATE Employee
SET Department_name = 'Management'
WHERE EmployeeId = 1;

UPDATE Employee
SET Department_name = 'Marketing'
WHERE EmployeeId IN (2, 3, 4);

UPDATE Employee
SET Department_name = 'Accounting'
WHERE EmployeeId IN (5, 6);

UPDATE Employee
SET Department_name = 'Purchasing'
WHERE EmployeeId IN (7, 8);

UPDATE Employee
SET Department_name = 'Personnel'
WHERE EmployeeId = 9;

UPDATE Employee
SET Department_name = 'Navigation'
WHERE EmployeeId = 10;

UPDATE Employee
SET Department_name = 'Books'
WHERE EmployeeId IN (11, 12, 13);

UPDATE Employee
SET Department_name = 'Equipment'
WHERE EmployeeId IN (14, 15, 16, 17);


INSERT INTO Item (Item_name, Item_type, item_color)
VALUES
('Pocket Knife-Nile', 'E', 'Brown'),
('Pocket Knife-Avon', 'E', 'Brown'),
('Compass', 'N', NULL),
('Geo positioning system', 'N', NULL),
('Elephant Polo stick', 'R', 'Bamboo'),
('Camel Saddle', 'R', 'Brown'),
('Sextant', 'N', NULL),
('Map Measure', 'N', NULL),
('Boots-snake proof', 'C', 'Green'),
('Pith Helmet', 'C', 'Khaki'),
('Hat-polar Explorer', 'C', 'White'),
('Exploring in 10 Easy Lessons', 'B', NULL),
('Hammock', 'F', 'Khaki'),
('How to win Foreign Friends', 'B', NULL),
('Map case', 'E', 'Brown'),
('Safari Chair', 'F', 'Khaki'),
('Safari cooking kit', 'F', 'Khaki'),
('Stetson', 'C', 'Black'),
('Tent - 2 person', 'F', 'Khaki'),
('Tent -8 person', 'F', 'Khaki');
SET IDENTITY_INSERT Sales ON;

INSERT INTO Sales (Sales_id, Item_name, Department_name)
VALUES
(101, 'Boots-snake proof', 'Clothes'),
(102, 'Pith Helmet', 'Clothes'),
(103, 'Sextant', 'Navigation'),
(104, 'Hat-polar Explorer', 'Clothes'),
(105, 'Pith Helmet', 'Equipment'),
(106, 'Pocket Knife-Nile', 'Clothes'),
(107, 'Pocket Knife-Nile', 'Recreation'),
(108, 'Compass', 'Navigation'),
(109, 'Geo positioning system', 'Navigation'),
(110, 'Map Measure', 'Navigation'),
(111, 'Geo positioning system', 'Books'),
(112, 'Sextant', 'Books'),
(113, 'Pocket Knife-Nile', 'Books'),
(114, 'Pocket Knife-Nile', 'Navigation'),
(115, 'Pocket Knife-Nile', 'Equipment'),
(116, 'Sextant', 'Clothes'),
(117, 'Sextant', 'Equipment'),
(118, 'Sextant', 'Recreation'),
(119, 'Sextant', 'Furniture'),
(120, 'Pocket Knife-Nile', 'Furniture'),
(121, 'Exploring in 10 easy lessons', 'Books'),
(122, 'How to win foreign friends', 'Books'),
(123, 'Compass', 'Books'),
(124, 'Pith Helmet', 'Books'),
(125, 'Elephant Polo stick', 'Recreation'),
(126, 'Camel Saddle', 'Recreation');
select * from Sales;

SET IDENTITY_INSERT Sales OFF;
