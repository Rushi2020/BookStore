create procedure updateBook
(
@BookId int,
@BookName varchar(50),
@AuthorName varchar(50),
@DiscountPrice int,
@OriginalPrice int,
@Description varchar(500),
@Rating float,
@Image varchar(200), 
@ReviewCount int, 
@BookCount int
)
as
begin 
     update BookTable set BookName=@BookName,
	 AuthorName=@AuthorName,
	 DiscountPrice=@DiscountPrice,
	 OriginalPrice=@OriginalPrice, 
	 Description=@Description,
	 Rating=@Rating, 
	 Image=@Image, 
	 ReviewCount=@ReviewCount,
	 BookCount=@BookCount 
	 where BookId = @BookId
end 