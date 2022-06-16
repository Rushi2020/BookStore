create Procedure addBooks 

(
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
     insert into BookTable values (@BookName, @AuthorName, @DiscountPrice, @OriginalPrice, @Description, @Rating, @Image, @ReviewCount, @BookCount)	 
end