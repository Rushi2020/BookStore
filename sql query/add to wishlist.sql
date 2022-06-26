create procedure AddBookToWishlist
(
 @id int,
 @BookId int
)
as
begin 
		insert into Wishlist(id,BookId) values (@id,@BookId)
end