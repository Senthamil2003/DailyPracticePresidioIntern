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

exec proc_GetBookAndPublishers 'Dean';
--2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
 
Create proc proc_EmployeeSoldDetails(@Firstname varchar(20))
as
begin
select  t.title,sum(t.price) 'price',sum(s.qty) 'quantity',sum(s.qty*t.price) 'Total Cost' from employee e 
join titles t on e.pub_id=t.pub_id 
join sales s on s.title_id=t.title_id where e.fname=@Firstname group by e.fname,t.title;
end
exec proc_EmployeeSoldDetails 'Pedro' ;

--3) Create a query that will print all names from authors and employees
select fname+' '+lname as 'Name' from employee
union
select au_fname+' '+au_lname from authors
--4) Create a  query that will float the data from sales,titles, publisher and 
--authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order

--select sum(qty) from sales where title_id='PS2091'
--select t.title_id, t.title,STRING_AGG(Concat(a.au_fname ,' ', a.au_fname),', ') 'Author Name' ,sum(s.qty)*max(t.price),sum(s.qty),max(price),min(price) 
--from titleauthor ta 
--join authors a on a.au_id=ta.au_id
--join titles t on t.title_id=ta.title_id
--join sales s on s.title_id=t.title_id
--group by s.ord_num, t.title_id,t.title order by sum(s.qty)*max(t.price) desc;

--select s.ord_num, t.title,a.au_fname+' '+ a.au_lname 'fullname',p.pub_name,t.price*s.qty 'Total Price' ,s.qty  from titles t 
--join titleauthor ta on t.title_id=ta.title_id
--join authors a on a.au_id=ta.au_id
--join sales s on s.title_id=t.title_id 
--join publishers p on p.pub_id=t.pub_id where t.title='Is Anger the Enemy?' order by t.price*s.qty desc;

SELECT
    aggregated.title_id,
    aggregated.title,
    aggregated.Author_Name,
	max(aggregated.prize),
	max(aggregated.prize)*sum(sales.qty)
   
FROM
    (
        SELECT
            t.title_id,
            t.title,
            STRING_AGG(CONCAT(a.au_fname, ' ', a.au_lname), ', ') AS Author_Name,
            t.price AS prize
        FROM
            titles t
            JOIN titleauthor ta ON t.title_id = ta.title_id
            JOIN authors a ON ta.au_id = a.au_id
        GROUP BY
            t.title_id,
            t.title,
			t.price
    ) AS aggregated
JOIN
    sales ON aggregated.title_id = sales.title_id
GROUP BY sales.title_id ,aggregated.prize,aggregated.Author_Name,aggregated.title,aggregated.title_id 
order by max(aggregated.prize)*sum(sales.qty) desc;

select t1.title, p.pub_name, t1.Name, t.price, sum(s.qty)'Quantity', sum(t.price*s.qty)'Total Price' from
(select t.title_id, t.title, STRING_AGG(Concat(a.au_fname ,' ', a.au_fname),', ') 'Name' from titles t join titleauthor ta on ta.title_id = t.title_id 
join authors a on ta.au_id=a.au_id group by t.title,t.title_id) as t1 join titles t on t1.title_id=t.title_id
join sales s on s.title_id = t.title_id
join publishers p on t.pub_id=p.pub_id
group by t1.title,p.pub_name,t1.Name,t.price order by sum(t.price*s.qty) desc;



 
