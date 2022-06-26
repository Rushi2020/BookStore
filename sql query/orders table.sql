create table Orders(
OrdersId int identity (1,1) primary key,
Order_Date DateTime Not null,
BookQuantity int not null,
DiscountPrice float not null,
OriginalPrice float not null,
id int not null foreign key (id) references UserSignup(id), 
AddressId int not null foreign key (AddressId) references Address (AddressId), 
BookId  int not null foreign key (BookId) references BookTable (BookId),
)

drop table Orders