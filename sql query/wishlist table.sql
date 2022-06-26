create table WishList(wishListId int primary key identity(1,1),
id int Foreign Key References UserSignup(id),
BookId int Foreign Key References Booktable(BookId))