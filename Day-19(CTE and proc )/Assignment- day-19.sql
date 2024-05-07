select * from stores;
select * from sales;
select * from publishers;
select * from titleauthor;
select * from authors;
select * from pub_info;
select * from roysched;
select * from titles;
select * from employee
select * from jobs
--1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

Create proc proc_GetBookAndPublishers(@Firstname varchar(20))
as
begin
 select t.title,p.pub_name from authors a 
join titleauthor ta on a.au_id =ta.au_id 
join titles t on ta.title_id=t.title_id 
join publishers p on t.pub_id=p.pub_id 
where a.au_fname=@Firstname;
end

exec proc_GetBookAndPublishers 'Anne';
--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
 
Create proc proc_EmployeeSoldDetails(@Firstname varchar(20))
as
begin
select t.title,t.price,s.qty from employee e 
join titles t on e.pub_id=t.pub_id 
join sales s on s.title_id=t.title_id where e.fname=@Firstname; 
end
exec proc_EmployeeSoldDetails 'Pedro';

--3) Create a query that will print all names from authors and employees
select fname+' '+lname as 'Name' from employee
union
select au_fname+' '+au_lname from authors
--4) Create a  query that will float the data from sales,titles, publisher and 
--authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order
select top 5 t.title,a.au_fname,p.pub_name,t.price*s.qty 'Total Price' ,s.qty  from titles t 
join titleauthor ta on t.title_id=ta.title_id
join authors a on a.au_id=ta.au_id
join sales s on s.title_id=t.title_id 
join publishers p on p.pub_id=t.pub_id order by t.price*s.qty desc;


 
