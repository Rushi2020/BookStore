create procedure DeleteWishlist
(
 @WishlistId int
)
as
begin 
	delete from Wishlist where WishlistId=@WishlistId
end 