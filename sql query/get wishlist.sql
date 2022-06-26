create procedure GetWishlist
@id int
As
Begin
select WishList.WishListId, WishList.id, WishList.BookId, BookTable.BookName, BookTable.AuthorName,
BookTable.Description, BookTable.DiscountPrice, BookTable.OriginalPrice, BookTable.Rating, BookTable.ReviewCount,
BookTable.Image, BookTable.BookCount from WishList inner join BookTable on WishList.BookId=BookTable.BookId
where WishList.id=@id
End


select * from WishList 
select * from UserSignup
select * from BookTable