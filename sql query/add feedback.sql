create procedure AddFeedback
(
 @id int,
 @BookId int,
 @Comments varchar(900),
 @OverallRating int
)
as
	declare @AverageRating int
begin 
insert into Feedback (id,BookId,Comments,OverallRating) values (@id,@BookId,@Comments,@OverallRating)
					select @AverageRating=avg(@OverallRating) from Feedback where BookId=@BookId
					update BookTable set Rating=@AverageRating,ReviewCount=ReviewCount+1 where BookId=@BookId
	
	end