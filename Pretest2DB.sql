create database SupperShoppe
go
use SupperShoppe
go
drop database SupperShoppe
create table Category(
	CatCode varchar(50) primary key,
	CatDescription varchar(100),
)
go

create table [User](
	UserName varchar(50) primary key,
	[Password] varchar(50),
	[Status] int
)
go

create table Items(
	ItemCode varchar(50) primary key,
	ItemDesc varchar(100),
	ItemCat varchar(50),
	Price varchar(50),
	Qoh varchar(50),
	Comp varchar(50)
)
go

insert into [User](UserName,[Password],[Status])
values
('Admin','123',1),
('FPT','Aptech',1),
('FPT1','Arena',0),
('User','123',0)

insert into Category(CatCode,CatDescription)
values
('EdbOil','Edible Oil'),
('FacePowders','All brands of face powders'),
('Perfumes','Perfumes,spray etc.'),
('ToiletSoaps','All Toilet soaps')
select * from Items

ALTER TABLE Items
  ADD DisplayNumber AS  RIGHT('000' + CAST(number AS VARCHAR(3)) , 3) PERSISTED