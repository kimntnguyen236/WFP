Create proc spGetCustomers
AS 
SELECT * FROM Customer

exec spGetCustomers

Create proc spAddstomer
@cusID varchar(50),
@cusName varchar(50),
@address varchar(50),
@phone varchar(50)
as 
begin
insert Customer Values (@cusID,@cusName,@address,@phone)
end

---------------------------

Create proc spDelCustomer
@cusID varchar(50)
as 
begin
delete from Customer where CustomerID=@cusID
end

SELECT * FROM Books order by Edition desc 