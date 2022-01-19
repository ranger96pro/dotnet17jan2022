use master

use pubs

--qn 1 
select au_fname,au_lname from authors

--qn 2
select * from titles order by title desc

--qn 3
select ta.au_id,count(ta.title_id),a.au_fname,a.au_lname
from titleauthor ta left outer join authors a on ta.au_id = a.au_id 
group by ta.au_id,a.au_fname,a.au_lname

--qn 4
select t.title,a.au_fname,a.au_lname
from titleauthor ta left outer join authors a on ta.au_id = a.au_id 
join titles t on ta.title_id = t.title_id

--qn 5

select sum(advance) 'Total Advance',p.pub_name
from titles t join publishers p on t.pub_id = p.pub_id
group by t.pub_id,p.pub_name

--qn 6
select t.title,p.pub_name,a.au_fname,a.au_lname, sum(price * qty) 'Sale Amount'
from sales s join titles t on s.title_id = t.title_id
join publishers p on t.pub_id = p.pub_id
join titleauthor ta on ta.title_id = t.title_id
join authors a on ta.au_id = a.au_id
group by s.title_id,t.title,p.pub_name,ta.au_id,a.au_fname,a.au_lname

--qn 7
select price from titles where title like '%s'

--qn 8
select title from titles where title like '%and%'

--qn 9
select e.fname,e.lname,p.pub_name 
from employee e join publishers p on e.pub_id = p.pub_id

--qn 10
select p.pub_name,count(p.pub_name)
from employee e join publishers p on e.pub_id = p.pub_id
group by p.pub_name
having count(p.pub_name) > 2

--qn 11
select CONCAT(a.au_fname,' ',a.au_lname)'Author Name' 
from authors a join titleauthor ta on a.au_id = ta.au_id
join titles t on ta.title_id = t.title_id
join publishers p on p.pub_id = t.pub_id
where p.pub_name = 'Algodata Infosystems'

--qn 12
select * from employee e join publishers p on e.pub_id = p.pub_id where p.pub_name = 'Algodata Infosystems'

--qn 14
create table tblqn14Employee
(id int identity(100,1) primary key,
name varchar(255),
age int,
phone int not null,
gender char check(gender in ('M','F'))
)

create table tblqn14Salary
(id int identity(1,100) primary key,
base int,
hra int,
da int,
deductions int
)

create table tblqn14EmployeeSalary
(id int identity(1,1),
employee_id int references tblqn14Employee(id),
salary_id int references tblqn14Salary(id),
tDate date,
primary key(id,employee_id,salary_id,tDate)
)

alter table tblqn14Employee add email varchar(100)

insert into tblqn14Employee values ('Person A',10,123456789,'M','personA@gmail.com')
insert into tblqn14Employee values ('Person B',15,234567891,'F','personB@gmail.com')
insert into tblqn14Employee values ('Person C',20,345678912,'M','personC@gmail.com')

insert into tblqn14Salary values (1000,100,200,50)
insert into tblqn14Salary values (1100,110,210,60)
insert into tblqn14Salary values (1200,120,220,70)

select * from tblqn14Employee
select * from tblqn14Salary
select * from tblqn14EmployeeSalary

insert into tblqn14EmployeeSalary values (100,1,'2022-01-19')
insert into tblqn14EmployeeSalary values (101,101,'2022-01-19')
insert into tblqn14EmployeeSalary values (102,201,'2022-01-19')

create proc proc_qn14totalsalary(@eId int,@tDate date)
as
begin
	declare
	@empID int,
	@transDate date,
	@totalSal int,
	@baseSal int,
	@hra int,
	@da int,
	@deduct int,
	@salId int
	set @empID = @eId
	set @transDate = @tDate
	set @salId = (select salary_id from tblqn14EmployeeSalary where employee_id = @empID and tDate = @tDate)
	set @baseSal = (select base from tblqn14Salary where id = @salId)
	set @hra = (select hra from tblqn14Salary where id = @salId)
	set @da = (select da from tblqn14Salary where id = @salId)
	set @deduct = (select deductions from tblqn14Salary where id = @salId)
	set @totalSal = @baseSal + @hra + @da - @deduct
	print 'Total Salary: ' + cast(@totalSal as varchar(20))
end

exec proc_qn14totalsalary 100,'2022-01-19'

select avg(base+hra+da-deductions) from tblqn14Salary where id = 1

create proc proc_qn14Avgsalary(@eId int,@tDate date)
as
begin
	declare
	@empID int,
	@transDate date,
	@avgSal int,
	@baseSal int,
	@hra int,
	@da int,
	@deduct int,
	@salId int
	set @empID = @eId
	set @transDate = @tDate
	set @salId = (select salary_id from tblqn14EmployeeSalary where employee_id = @empID and tDate = @tDate)
	set @avgSal = (select avg(base+hra+da-deductions) from tblqn14Salary where id = @salId)
	print 'Average Salary: ' + cast(@avgSal as varchar(20))
end


exec proc_qn14Avgsalary 100,'2022-01-19'

create proc proc_qn14totaltaxpayable(@eId int)
as
begin
	declare
	@empID int,
	@transDate date,
	@totalSal int,
	@baseSal int,
	@hra int,
	@da int,
	@deduct int,
	@salId int
	set @empID = @eId
	set @salId = (select salary_id from tblqn14EmployeeSalary where employee_id = @empID)
	set @baseSal = (select base from tblqn14Salary where id = @salId)
	set @hra = (select hra from tblqn14Salary where id = @salId)
	set @da = (select da from tblqn14Salary where id = @salId)
	set @deduct = (select deductions from tblqn14Salary where id = @salId)
	set @totalSal = @baseSal + @hra + @da - @deduct
	if(@totalSal < 100000)
		print '0%'
	else if(@totalSal > 100000 and @totalSal < 200000)
		print '5%'
	else if(@totalSal > 200000 and @totalSal < 350000)
		print '6%'
	else
		print '7.5%'
end

exec proc_qn14totaltaxpayable 100

--qn 15
create function funcQn15(@basic int,@hra int,@da int)
return @sumOftheThree Table(totalSum int)
as
begin
	Declare
	@sum int
	set @sum = @basic+@hra+@da
	insert into @sumOftheThree values (@sum)
	return
end

