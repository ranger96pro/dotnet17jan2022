use master

use pubs

--qn 1
select * from authors

--qn 2
select concat(au_fname,' ',au_lname) 'Author Name' from authors

select * from titles

--qn 3
select avg(price) 'Average Price',SUM(price) 'Total Price' from titles


--qn 4
select avg(price) 'Average Price' from titles where pub_id = '0736'

--qn 5 
select * from titles where advance between 3200 and 5000

--qn 6
select * from titles t where t.type = 'psychology' or t.type = 'mod_cook'

--qn 7
select * from titles where pubdate <= '1991-6-9'

--qn 8
select * from authors where state = 'CA'

--qn 9 
select avg(price) 'Average Price' ,type
from titles 
group by type

--qn 10
select sum(price) 'Total price' ,pub_id
from titles 
group by pub_id

--qn 11
select MIN(pubdate),type from titles group by type

--qn 12
select sum(royalty) 'Total Royalty' , t.pub_id,p.pub_name 
from titles t join publishers p
on t.pub_id = p.pub_id
group by t.pub_id,p.pub_name

--qn 13
select * from titles order by pubdate

--qn 14
select * from titles
order by pub_id,pubdate

--qn 15
select * from titles
where title_id in (
select title_id from titleauthor where au_id in (select au_id from authors where state = 'CA')
)

--qn 16
select * from authors where au_id in
(
select au_id from titleauthor where title_id in 
(
select title_id from titles 
where royalty > (select avg(royalty) from titles)
)
)

--qn 17
select count(city),city from publishers
group by city
having count(city)>1

--qn 18
select sum(qty),title_id from sales group by title_id

--qn 19
select count(title_id) 'Total title sold',ord_num from sales group by ord_num

--qn 20
select title,s.ord_date from titles t join sales s on t.title_id = s.title_id 

--qn 21
select title,p.pub_name from titles t join publishers p on t.pub_id = p.pub_id

--qn 22
select title,publishers.pub_name from titles right outer join publishers on titles.pub_id = publishers.pub_id

--qn 23
select COUNT(title_id) 'Number of author',title_id from titleauthor group by title_id 

--qn 24
select t.title, CONCAT( a.au_lname,' ',a.au_fname) 'Author name'
from 
titleauthor ta join titles t on ta.title_id = t.title_id
join
authors a on a.au_id = ta.au_id

--qn 25
select t.title, CONCAT( a.au_lname,' ',a.au_fname) 'Author name',p.pub_name
from 
titleauthor ta join titles t on ta.title_id = t.title_id
join
authors a on a.au_id = ta.au_id
join publishers p on t.pub_id = p.pub_id

--qn 26

select t.title, CONCAT( a.au_lname,' ',a.au_fname) 'Author name',p.pub_name,s.ord_date,s.ord_num
from 
titleauthor ta join titles t on ta.title_id = t.title_id
join
authors a on a.au_id = ta.au_id
join publishers p on t.pub_id = p.pub_id
join sales s on s.title_id = ta.title_id

--qn 27
select t.title,ss.stor_name from 
sales s join titles t on s.title_id = t.title_id
join stores ss on ss.stor_id = s.stor_id

--qn 28
select s.stor_id,st.stor_name
from sales s join stores st on s.stor_id = st.stor_id
group by s.stor_id,st.stor_name
having count(s.stor_id) > 1 

--qn 29
select MIN(s.ord_date)'First order date',t.title 
from sales s 
right outer join titles t on s.title_id = t.title_id
group by t.title

--qn 30

select * from sales cross join authors