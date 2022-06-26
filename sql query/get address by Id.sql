create procedure GetAddressById
(
 @id int
)
as
begin 
		select * from Address where id=@id
end