--1) Print the storeid and number of orders for the store
select stores.stor_id,count(sales.stor_id)'count' from stores join sales on stores.stor_id =sales.stor_id group by stores.stor_id

--2) print the numebr of orders for every title
select title_id,count(title_id) 'count' from sales group by title_id;

--3) print the publisher name and book name
select publishers.pub_name,titles.title from publishers join titles on publishers.pub_id=titles.pub_id;

--4) Print the author full name for al the authors
select au_fname+' '+au_lname 'full name' from authors;

--5) Print the price or every book with tax (price+price*12.36/100)
select  title, 2*price*12.36/100 'price with tax' from titles;

--6) Print the author name, title name
select authors.au_fname+' '+authors.au_lname 'full name',titles.title from authors join titleauthor on authors.au_id=titleauthor.au_id join titles on titles.title_id=titleauthor.title_id; 

--7) print the author name, title name and the publisher name
select a.au_fname+' '+a.au_lname 'full name',t.title,p.pub_name from authors a join titleauthor ta on a.au_id=ta.au_id join titles t on t.title_id= ta.title_id join publishers p on t.pub_id=p.pub_id;

--8) Print the average price of books pulished by every publicher
select publishers.pub_name, avg(price) from titles join publishers on publishers.pub_id=titles.pub_id group by titles.pub_id,publishers.pub_name; 

--9) print the books published by 'Marjorie'
select authors.au_fname+' '+authors.au_lname 'full name', titles.title from authors join titleauthor on authors.au_id =titleauthor.au_id join titles on titleauthor.title_id=titles.title_id where au_fname='Marjorie' ;

--10) Print the order numbers of books published by 'New Moon Books'
select p.pub_name,s.ord_num from publishers p join titles t on p.pub_id=t.pub_id join sales s on s.title_id=t.title_id where p.pub_name='New Moon Books' ;

--11) Print the number of orders for every publisher
select p.pub_name,count(s.ord_num) from publishers p join titles t on p.pub_id=t.pub_id join sales s on s.title_id=t.title_id group by p.pub_name;

--12) print the order number , book name, quantity, price and the total price for all orders
select s.ord_num,t.title,s.qty,t.price,s.qty*t.price 'Total price' from sales s join titles t on s.title_id=t.title_id ;

--13) print he total order quantity fro every book
select t.title,sum(s.qty) 'Tota order quantity' from titles t join sales s on t.title_id=s.title_id group by s.title_id,t.title;

--14) print the total ordervalue for every book
select t.title,sum(s.qty)*t.price 'Tota order value' from titles t join sales s on t.title_id=s.title_id group by s.title_id,t.title,t.price;

--15) print the orders that are for the books published by the publisher for which 'Paolo' works for
select titles.title,sales.ord_num from authors join titleauthor on authors.au_id=titleauthor.au_id join titles on titles.title_id=titleauthor.title_id join sales on sales.title_id=titles.title_id where authors.au_fname ='Paolo';