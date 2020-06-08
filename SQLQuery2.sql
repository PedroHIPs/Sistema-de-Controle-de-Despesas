create table despesa (
codigo int identity(1,1) primary key,
descr varchar(50) not null,
tipo varchar(20) not null,
valor float not null check(valor >0),
dia date);

select * from despesa;