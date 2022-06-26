create table CartTable
(
CartId int identity (1,1) primary key, 
id int foreign key (id) references UserSignup(id),
BookId int foreign key (BookId) references BookTable(BookId),
OrderQuantity int default 1
)
select * from CartTable

select * from BookTable

select * from UserSignup
