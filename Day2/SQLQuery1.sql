use Northwind

select * from Products

select ProductName from Products


select ProductName, QuantityPerUnit from Products


select ProductName Product_Name, QuantityPerUnit Quantity_In_every_Unit from Products

select * from Products where UnitPrice >= 15 and UnitPrice <= 25

select * from Products where UnitPrice between 15 and 25

select * from Products where UnitPrice >= 15 and SupplierID = 17

select * from Products where SupplierID = 15

select * from Products where UnitsOnOrder < 5

select * from Products where SupplierID = 15 or UnitsOnOrder < 5

select * from Products where SupplierID > 5 and SupplierID < 10

select * from Products where SupplierID in(8,12,13,18)

select * from Products where SupplierID not in(8,12,13,18)

select * from Products where ProductName = 'Ikura'

select * from Products where ProductName like '%cha%'
select * from Products where ProductName like '%cha'
select * from Products where ProductName like 'cha%'
--% any character be4 and after depending on position

select * from Products where ProductName like '_on%'
--_ replace any 1 character

select avg(unitsinstock) Average_Stock from Products


select avg(unitsinstock) Average_Stock,
sum(unitsinstock) 'Total number of units' 
from Products


select avg(UnitPrice) 'Average price of products that are supplied by Id 2,6,9' from Products where SupplierID in (2,6,9)

select count(supplierid) from products

select count(distinct supplierid) from products

select * from products order by supplierid

select * from products order by supplierid desc


select * from products order by supplierid, UnitsInStock
select * from products order by supplierid, UnitsInStock desc

select * from products where productname like '%e%' order by supplierid 

select supplierid , count(productid) from products group by SupplierID


select supplierid, count(productid) 'Number of products'
from products
where UnitsInStock > 0 
group by SupplierID
order by 2


select supplierid, count(productid) 'Number of products'
from products
where UnitsInStock > 0 
group by SupplierID
having count(productid) > 2
order by count(productid)

select * from Invoices

select Salesperson, round(avg(unitprice),2) Average_Price
from Invoices
where ShipCountry = 'france' and CustomerName like '%e%'
group by Salesperson
having avg(unitprice) > 3
order by Salesperson

select * from suppliers

select * from suppliers 
where Country = 'Japan'

select * from Products where SupplierID in (select SupplierID from Suppliers where country = 'Japan')

select supplierid from suppliers 
where companyname = 'tokyo traders'

select * from products where supplierid = (select supplierid from suppliers 
where companyname = 'tokyo traders')
select * from products where supplierid in (select supplierid from suppliers 
where Country = 'germany')

--use in when have multiple results and use = when only 1 result

select SupplierID, avg(unitsinstock) Average_Unit_in_Stock
from Products
where SupplierID in (select SupplierID from Suppliers where Region is not null)
group by SupplierID
having avg(unitsinstock) > 3
order by avg(unitsinstock)

select *
from products
where CategoryID in (select CategoryID from Categories where CategoryName like '%pro%') and UnitsInStock > 0
order by UnitPrice

select * from [Order Details]
where productid in (select ProductID from products where CategoryID in (select CategoryID from Categories where CategoryName like '%pro%'))

select * from products where productid not in (select distinct productid from [Order Details])

select productname,[Order Details].unitprice,quantity,[Order Details].unitprice*quantity 'product price'
from products join [Order Details]
on products.ProductID = [Order Details].ProductID

select productname,od.unitprice,quantity, od.unitprice*quantity 'product price'
from products p inner join [Order Details] od
on p.ProductID = od.ProductID
order by productname,quantity

select contactname 'Customer Name', orderdate 'Date' 
from customers c join orders o 
on c.CustomerID = o.CustomerID
order by 1

select contactname 'Customer Name', orderdate 'Date' 
from customers c left outer join orders o 
on c.CustomerID = o.CustomerID
order by 1

select * from Customers

select * from Orders

select concat(firstname,' ',lastname) Empolyee_Name , count(o.OrderID) 'Number orders'
from Employees e join Orders o
on e.EmployeeID = o.EmployeeID
group by concat(firstname,' ',lastname)
having count(o.orderid) > 50
order by 2

select * 
from [Order Details]

select * 
from Orders

select * 
from Customers

select * 
from Products

select c.contactname 'Customer Name', o.orderid,p.productname, od.UnitPrice*od.Quantity 'Price'
from Customers c left outer join orders o 
on c.customerid = o.CustomerID
left outer join [Order Details] od on od.OrderID = o.OrderID
left outer join Products p on p.ProductID = od.ProductID
order by price


select c.contactname 'Customer Name', o.orderid,p.productname, od.UnitPrice*od.Quantity 'Price'
from products p join [Order Details] od
on p.ProductID = od.ProductID
join orders o on od.OrderID = o.OrderID
right outer join Customers c on c.CustomerID = o.CustomerID
order by price

select * from Region cross join Shippers

select * from Employees
select employeeid,reportsto 
from Employees

select emp.EmployeeID 'Employee ID',emp.FirstName 'Employee Name' , mgr.EmployeeID 'Manager Id',mgr.FirstName 'Manager Name'
from Employees emp join Employees mgr
on emp.ReportsTo = mgr.EmployeeID