alter procedure GetCart
(
 @id int
)
as
begin 
	select CartTable.CartId,
	CartTable.BookId,
 CartTable.id,
	  CartTable.OrderQuantity,
	   CartTable.CartId,
	   BookTable.BookName,
	   BookTable.AuthorName,
	   BookTable.Image,
	   BookTable.DiscountPrice,
	   BookTable.OriginalPrice,
	   BookTable.Description
	   From CartTable 
	   inner join BookTable 
	   on CartTable.BookId=BookTable.BookId
	   where id=@id;


end 