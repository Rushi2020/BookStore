create procedure GetFeedback
(
 @BookId int
)
as
begin 
	select Feedback.FeedbackId,Feedback.id,Feedback.BookId,Feedback.Comments,Feedback.OverallRating,UserSignup.FullName,UserSignup.EmailId from UserSignup inner join Feedback on Feedback.id = UserSignup.id where BookId=@BookId
end 

Select * from Feedback
select * from BookTable
select * from Orders
select * from CartTable
select * from Address
select * from UserSignup