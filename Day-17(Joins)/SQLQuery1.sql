select * from Suppliers;
--select product names from the supplier Tokyo Traders
select * from Products

select * from Products where SupplierID= (select SupplierID from Suppliers where CompanyName='Tokyo Traders');
--get all the products from the category that has 'ea' in the description
select * from products where CategoryID in (select CategoryID from Categories where Description like '%ea%')
--select the product id and the quantity ordered by customrs from France
select * from Products
select * from Customers
select OrderID ,Quantity from [Order Details] where OrderID in (select OrderID from Orders where CustomerID in (select CustomerID from Customers where Country='France'));
--Get the products that are priced above the average price of all the products
select * from Products where UnitPrice > (select avg(UnitPrice) from Products);
select * from Orders
select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

--Select the maximum priced product in every category
select * from Products;

select * from products o1 where UnitPrice=( select max(UnitPrice) from Products o2 where  o1.CategoryID=o2.CategoryID); 

--select the order number for the maximum fright paid by every customer
select * from Orders o1  where Freight=( select max(Freight) from Orders o2 where o1.CustomerId=o2.CustomerID);

select * from Categories;
select * from Products
select categoryName,ProductName from Categories 
join Products on Categories.CategoryID = Products.CategoryID



--Get the Supplier company name, contact person name, Product name and the stock ordered
select Suppliers.CompanyName,Suppliers.ContactName ,Products.ProductName,Products.UnitsInStock from Suppliers join Products on Suppliers.SupplierID=Products.SupplierID;

 --Print the order id, customername and the fright cost for all teh orders
 select o.OrderId,c.ContactName ,o.Freight from Orders o join Customers c on o.CustomerID=c.CustomerID;


  --product name, quantity sold, Discount Price, Order Id, Fright for all orders


 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join [Order Details] od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID
  --check***************************
select * from Suppliers
select * from Orders;
select * from Products;
select * from Suppliers;
select * from Customers
select * from [Order Details]
--check****************************


  --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)

 select c.ContactName,p.ProductName,od.Quantity,o.Freight, od.UnitPrice*od.Quantity+o.Freight "Total prize"  from Customers c join Orders o on c.CustomerID=o.CustomerID  join [Order Details] od on od.OrderID=o.OrderID  join Products p on od.ProductID=p.ProductID;   

 select c.ContactName,count(od.Quantity )from Customers  c join Orders o on c.CustomerID=o.CustomerID join [Order Details] od on o.OrderID=od.OrderID group by od.OrderID, c.ContactName;
 select * from Customers
 