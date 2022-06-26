create procedure deleteBook
(
@BookId int
)
as
begin 
     delete from BookTable where  BookId=@BookId	 
end 

select * from BookTable