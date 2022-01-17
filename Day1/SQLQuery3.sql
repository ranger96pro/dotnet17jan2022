use master

create database db17janQuestion

use db17janQuestion

create table DEPARTMENT
(Deptname varchar(15) check (Deptname in ('Management','Marketing','Accounting','Purchasing','Personnel','Navigation','Books','Clothes','Equipment','Furniture','Recreation')) primary key,
Deptfloor int,
DeptPhone int
)

create table EMP
(Empno int identity(1,1) primary key,
Empname varchar(20) not null,
Empsalary int,
Department varchar(15) references DEPARTMENT(Deptname) not null,
Bossno int references Emp(Empno) not null
)


alter table DEPARTMENT add MgrId int references EMP(Empno) not null

create table ITEM
(Itemname varchar(255) primary key,
itemtype char,
itemcolor varchar(15)
)

create table SALES
(Salesno int identity(101,1) primary key,
Saleqty int,
itemname varchar(255) references ITEM(Itemname) not null,
Deptname varchar(15) references DEPARTMENT(Deptname) not null
)


alter table DEPARTMENT drop column MgrId

drop table DEPARTMENT

sp_Help DEPARTMENT

select * from item
insert into ITEM(Itemname,itemtype,itemcolor) values ('Pocket Knife-Nile','E','Brown')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Pocket Knife-Avon','E','Brown')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Compass','N','')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Geo positioning system','N','')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Elephant Polo stick','R','Bamboo')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Camel Saddle','R','Brown')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Sextant','N','')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Map Measure','N','')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Boots-snake proof','C','Green')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Pith Helmet','C','Khaki')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Hat-polar Explorer','C','White')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Exploring in 10 Easy Lessons','B','')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Hammock','F','Khaki')
insert into ITEM(Itemname,itemtype,itemcolor) values ('How to win Foreign Friends','B','')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Map case','E','Brown')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Safari Chair','F','Khaki')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Safari cooking kit','F','Khaki')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Stetson','C','Black')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Tent - 2 person','F','Khaki')
insert into ITEM(Itemname,itemtype,itemcolor) values ('Tent -8	 person','F','Khaki')

insert into EMP(Empname,Empsalary,Department,Bossno) values ('Alice',75000,'Management','')