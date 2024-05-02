select * from Products;
--Avreage price of products supplied by supplier 2
select AVG(UnitsInstock) 'Average supply' from Products where SupplierID=2;


select SupplierID, Avg(UnitPrice) 'avg' from Products group by SupplierID;
select SupplierID,CategoryID ,sum(UnitPrice) "sentha" from Products group by SupplierID,CategoryID order by SupplierID;
--Select category ID and Sum of products avaible if the total number of products is 
--greater than 10
select CategoryID,sum(UnitsInStock)  from Products group by CategoryID having sum(UnitsInStock)>10;
--Get the products sorted by the price. Fetch only those products that will be discontiued
select *  from Products where Discontinued=1 order by UnitPrice;

select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by 2;

select ProductName,
Rank() over( order by UnitPrice desc) "Price Rank"
from Products order by ProductName desc;
select * from Customers;
--Rank the customer based on the country name in ascending order
create database pugs
select * ,Rank() over (order by Country) "Country Rank" from Customers;