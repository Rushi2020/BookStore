create procedure AddBookToCart
(
 @id int,
 @BookId int,
 @OrderQuantity int
)
as
begin
insert into CartTable (id,BookId,OrderQuantity) values (@id,@BookId,@OrderQuantity);
End
